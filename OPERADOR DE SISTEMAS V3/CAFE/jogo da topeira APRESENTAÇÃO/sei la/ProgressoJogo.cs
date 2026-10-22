using System;
using System.Globalization;
using System.IO;
using System.Security;
using System.Xml;
using System.Xml.Linq;

namespace sei_la
{
    // SALVAMENTO LOCAL: guarda apenas acertos, recorde e opção de som, sem precisar de internet.
    internal static class ProgressoJogo
    {
        public static int AcertosSalvos { get; private set; }
        public static int Recorde { get; private set; }
        public static bool SomAtivo { get; private set; }
        public static int EstiloSom { get; private set; }
        public static string UltimoErro { get; private set; }

        static ProgressoJogo()
        {
            SomAtivo = true;
            EstiloSom = 0;
            UltimoErro = "";
        }

        // AppData é gravável pelo usuário comum: o jogo também funciona em pastas de leitura.
        private static string Caminho
        {
            get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Cafe", "IlhaDaToupeira", "progresso.xml"); }
        }

        public static void Carregar()
        {
            AcertosSalvos = 0;
            Recorde = 0;
            SomAtivo = true;
            EstiloSom = 0;
            UltimoErro = "";
            try
            {
                if (!File.Exists(Caminho)) return;
                // Não aceita DTD/entidades externas: o arquivo é só dados simples do próprio jogo.
                var opcoes = new XmlReaderSettings { DtdProcessing = DtdProcessing.Prohibit, XmlResolver = null };
                using (XmlReader leitor = XmlReader.Create(Caminho, opcoes))
                {
                    XElement raiz = XElement.Load(leitor);
                    if (raiz.Name != "toupeira") throw new XmlException("Formato de progresso desconhecido.");
                    AcertosSalvos = LerNumero(raiz, "acertos", 29);
                    Recorde = LerNumero(raiz, "recorde", 3000);
                    EstiloSom = LerNumero(raiz, "estiloSom", 2);
                    bool som;
                    if (Boolean.TryParse((string)raiz.Element("som"), out som)) SomAtivo = som;
                }
            }
            catch (Exception erro)
            {
                if (!FalhaDeArquivo(erro)) throw;
                // Um arquivo danificado não impede a apresentação; inicia uma partida limpa.
                AcertosSalvos = 0;
                Recorde = 0;
                UltimoErro = "Não foi possível ler o progresso salvo.";
            }
        }

        private static int LerNumero(XElement raiz, string nome, int maximo)
        {
            int valor;
            if (!Int32.TryParse((string)raiz.Element(nome), NumberStyles.Integer, CultureInfo.InvariantCulture, out valor))
                return 0;
            return Math.Max(0, Math.Min(maximo, valor));
        }

        public static void SalvarAcertos(int acertos)
        {
            AcertosSalvos = Math.Max(0, Math.Min(29, acertos));
            Gravar();
        }

        public static void RegistrarVitoria(int pontos)
        {
            Recorde = Math.Max(Recorde, Math.Max(0, Math.Min(3000, pontos)));
            AcertosSalvos = 0; // Uma vitória conclui a partida; LOAD GAME só retoma partidas em andamento.
            Gravar();
        }

        public static void SalvarOpcoes(bool som)
        {
            SomAtivo = som;
            Gravar();
        }

        // Preserva os saves antigos: se estiloSom não existir, o padrão é moeda.
        public static void SalvarAudio(bool som, int estilo)
        {
            SomAtivo = som;
            EstiloSom = Math.Max(0, Math.Min(2, estilo));
            Gravar();
        }

        private static void Gravar()
        {
            string temporario = null;
            try
            {
                string destino = Caminho;
                Directory.CreateDirectory(Path.GetDirectoryName(destino));
                temporario = destino + "." + Guid.NewGuid().ToString("N") + ".tmp";
                var documento = new XElement("toupeira", new XAttribute("versao", 1),
                    new XElement("acertos", AcertosSalvos), new XElement("recorde", Recorde),
                    new XElement("som", SomAtivo), new XElement("estiloSom", EstiloSom));
                documento.Save(temporario);
                // Só substitui o arquivo anterior depois que o novo terminou de ser escrito.
                if (File.Exists(destino)) File.Replace(temporario, destino, null);
                else File.Move(temporario, destino);
                UltimoErro = "";
            }
            catch (Exception erro)
            {
                if (!FalhaDeArquivo(erro)) throw;
                // A partida continua em memória se o PC bloquear o acesso ao disco.
                UltimoErro = "Não foi possível salvar neste computador.";
            }
            finally
            {
                if (temporario != null)
                {
                    try { if (File.Exists(temporario)) File.Delete(temporario); }
                    catch (Exception erro)
                    {
                        if (!FalhaDeArquivo(erro)) throw;
                        // A falha já foi sinalizada em UltimoErro.
                    }
                }
            }
        }

        private static bool FalhaDeArquivo(Exception erro)
        {
            return erro is IOException || erro is UnauthorizedAccessException || erro is SecurityException ||
                erro is XmlException || erro is ArgumentException || erro is NotSupportedException;
        }
    }
}
