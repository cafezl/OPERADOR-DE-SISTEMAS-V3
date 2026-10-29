using System;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace sei_la
{
    // Perfis deste computador: não envia CPF, senha ou progresso para a internet.
    internal static class PerfisJogador
    {
        private const int IteracoesSenha = 600000;
        private static string pastaDados = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Cafe", "IlhaDaToupeira");
        private static string idAtual = "visitante";
        private static string nomeAtual = "Visitante";

        public static string IdAtual { get { return idAtual; } }
        public static string NomeAtual { get { return nomeAtual; } }
        public static bool EstaLogado { get { return idAtual != "visitante"; } }
        internal static string PastaDados { get { return pastaDados; } }
        private static string CaminhoPerfis { get { return Path.Combine(PastaDados, "perfis.xml"); } }

        public static bool Cadastrar(string nome, string cpf, string senha, out string erro)
        {
            erro = "";
            nome = NormalizarNome(nome);
            if (!NomeValido(nome)) { erro = "Use um nome de 3 a 40 caracteres, com letras, números, espaços, ponto, hífen ou sublinhado."; return false; }
            if (!CpfValido(cpf)) { erro = "Confira o CPF: preencha os 11 números e os dígitos verificadores."; return false; }
            if (senha == null || senha.Length < 6 || senha.Length > 128)
            { erro = "A senha deve ter entre 6 e 128 caracteres."; return false; }
            try
            {
                Directory.CreateDirectory(PastaDados);
                // Uma segunda janela não pode sobrescrever um cadastro que está sendo gravado.
                using (FileStream trava = new FileStream(Path.Combine(PastaDados, "perfis.lock"),
                    FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                {
                    XElement perfis = LerPerfis();
                    if (Buscar(perfis, nome) != null) { erro = "Esse nome já possui um cadastro. Escolha Entrar ou use outro nome."; return false; }
                    byte[] sal = new byte[16];
                    using (RandomNumberGenerator aleatorio = RandomNumberGenerator.Create()) aleatorio.GetBytes(sal);
                    byte[] hash = DerivarSenha(senha, sal, IteracoesSenha);
                    string id = Guid.NewGuid().ToString("N");
                    // O CPF participa da validação do formulário, mas não é necessário guardá-lo.
                    perfis.Add(new XElement("perfil", new XAttribute("id", id),
                        new XElement("nome", nome), new XElement("sal", Convert.ToBase64String(sal)),
                        new XElement("hash", Convert.ToBase64String(hash)), new XElement("iteracoes", IteracoesSenha)));
                    Array.Clear(hash, 0, hash.Length);
                    GravarPerfis(perfis);
                    Ativar(id, nome);
                    return true;
                }
            }
            catch (Exception falha)
            {
                if (!FalhaDeDados(falha)) throw;
                erro = "Não foi possível cadastrar neste computador. Confira a permissão da pasta ou tente novamente.";
                return false;
            }
        }

        public static bool Entrar(string nome, string senha, out string erro)
        {
            erro = "";
            nome = NormalizarNome(nome);
            if (!NomeValido(nome) || senha == null || senha.Length < 6 || senha.Length > 128)
            { erro = "Nome ou senha incorretos."; return false; }
            try
            {
                XElement perfil = Buscar(LerPerfis(), nome);
                if (perfil == null) { erro = "Nome ou senha incorretos."; return false; }
                Guid id;
                int iteracoes;
                byte[] sal = Convert.FromBase64String((string)perfil.Element("sal") ?? "");
                byte[] esperado = Convert.FromBase64String((string)perfil.Element("hash") ?? "");
                if (!Guid.TryParseExact((string)perfil.Attribute("id"), "N", out id) || sal.Length != 16 || esperado.Length != 32 ||
                    !Int32.TryParse((string)perfil.Element("iteracoes"), out iteracoes) || iteracoes < 100000 || iteracoes > 1000000)
                    throw new InvalidDataException("Cadastro inválido.");
                byte[] recebido = DerivarSenha(senha, sal, iteracoes);
                // Compara todos os bytes, sem parar no primeiro diferente.
                int diferenca = 0;
                for (int i = 0; i < recebido.Length; i++) diferenca |= recebido[i] ^ esperado[i];
                Array.Clear(recebido, 0, recebido.Length);
                if (diferenca != 0) { erro = "Nome ou senha incorretos."; return false; }
                Ativar(id.ToString("N"), (string)perfil.Element("nome"));
                return true;
            }
            catch (Exception falha)
            {
                if (!FalhaDeDados(falha)) throw;
                erro = "Não foi possível ler o cadastro local. Seus arquivos não foram substituídos.";
                return false;
            }
        }

        public static void Sair() { Ativar("visitante", "Visitante"); }

        private static void Ativar(string id, string nome)
        {
            idAtual = id;
            nomeAtual = nome;
            ProgressoJogo.Carregar(); // Cada jogador retoma somente o próprio progresso.
        }

        // Aceita a entrada com a máscara 000.000.000-00 ou somente os números.
        public static bool CpfValido(string cpf)
        {
            if (String.IsNullOrWhiteSpace(cpf)) return false;
            string numeros = "";
            foreach (char c in cpf)
            {
                if (c >= '0' && c <= '9') numeros += c;
                else if (c != '.' && c != '-' && !Char.IsWhiteSpace(c)) return false;
            }
            if (numeros.Length != 11 || numeros.All(c => c == numeros[0])) return false;
            for (int posicao = 9; posicao <= 10; posicao++)
            {
                int soma = 0;
                for (int i = 0; i < posicao; i++) soma += (numeros[i] - '0') * (posicao + 1 - i);
                int digito = (soma * 10) % 11;
                if (digito == 10) digito = 0;
                if (digito != numeros[posicao] - '0') return false;
            }
            return true;
        }

        private static string NormalizarNome(string nome)
        {
            try
            {
                return String.Join(" ", (nome ?? "").Normalize(NormalizationForm.FormKC)
                    .Split((char[])null, StringSplitOptions.RemoveEmptyEntries));
            }
            catch (ArgumentException) { return ""; }
        }

        private static bool NomeValido(string nome)
        {
            return nome.Length >= 3 && nome.Length <= 40 && nome.Any(Char.IsLetterOrDigit) &&
                nome.All(c => Char.IsLetterOrDigit(c) || c == ' ' || c == '_' || c == '-' || c == '.');
        }

        private static XElement Buscar(XElement perfis, string nome)
        {
            return perfis.Elements("perfil").FirstOrDefault(p =>
                String.Equals((string)p.Element("nome"), nome, StringComparison.OrdinalIgnoreCase));
        }

        private static byte[] DerivarSenha(string senha, byte[] sal, int iteracoes)
        {
            // Sal aleatório + PBKDF2: a senha nunca aparece em texto no XML.
            using (var derivador = new Rfc2898DeriveBytes(senha, sal, iteracoes, HashAlgorithmName.SHA256))
                return derivador.GetBytes(32);
        }

        private static XElement LerPerfis()
        {
            if (!File.Exists(CaminhoPerfis)) return new XElement("perfis", new XAttribute("versao", 1));
            if (new FileInfo(CaminhoPerfis).Length > 1024 * 1024) throw new InvalidDataException("Cadastro muito grande.");
            var opcoes = new XmlReaderSettings { DtdProcessing = DtdProcessing.Prohibit, XmlResolver = null };
            using (XmlReader leitor = XmlReader.Create(CaminhoPerfis, opcoes))
            {
                XElement perfis = XElement.Load(leitor);
                if (perfis.Name != "perfis") throw new InvalidDataException("Cadastro inválido.");
                return perfis;
            }
        }

        private static void GravarPerfis(XElement perfis)
        {
            string temporario = CaminhoPerfis + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try
            {
                perfis.Save(temporario);
                if (File.Exists(CaminhoPerfis)) File.Replace(temporario, CaminhoPerfis, null);
                else File.Move(temporario, CaminhoPerfis);
            }
            finally
            {
                try { if (File.Exists(temporario)) File.Delete(temporario); }
                catch (IOException) { }
                catch (UnauthorizedAccessException) { }
            }
        }

        private static bool FalhaDeDados(Exception erro)
        {
            return erro is IOException || erro is UnauthorizedAccessException || erro is SecurityException ||
                erro is XmlException || erro is ArgumentException || erro is FormatException ||
                erro is CryptographicException || erro is NotSupportedException;
        }
    }
}
