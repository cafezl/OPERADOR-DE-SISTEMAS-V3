using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace PrimeiroProjeto
{
    internal static class SenhaHasher
    {
        private const string Prefixo = "PBKDF2-SHA1";
        private const int Iteracoes = 120000;
        private const int TamanhoDoSal = 16;
        private const int TamanhoDoHash = 32;

        public static string Gerar(string senha)
        {
            if (senha == null)
            {
                throw new ArgumentNullException("senha");
            }

            byte[] sal = new byte[TamanhoDoSal];
            using (RandomNumberGenerator gerador = RandomNumberGenerator.Create())
            {
                gerador.GetBytes(sal);
            }

            byte[] hash;
            using (Rfc2898DeriveBytes derivador = new Rfc2898DeriveBytes(senha, sal, Iteracoes))
            {
                hash = derivador.GetBytes(TamanhoDoHash);
            }

            return Prefixo + "$" + Iteracoes.ToString(CultureInfo.InvariantCulture) + "$" +
                Convert.ToBase64String(sal) + "$" + Convert.ToBase64String(hash);
        }

        public static bool Verificar(string senha, string valorSalvo)
        {
            if (senha == null || string.IsNullOrEmpty(valorSalvo))
            {
                return false;
            }

            string[] partes = valorSalvo.Split('$');
            if (partes.Length != 4 || partes[0] != Prefixo)
            {
                // Aceita cadastros antigos em texto puro para que possam ser migrados no próximo login.
                return CompararEmTempoConstante(Encoding.UTF8.GetBytes(senha), Encoding.UTF8.GetBytes(valorSalvo));
            }

            int iteracoesSalvas;
            if (!int.TryParse(partes[1], NumberStyles.None, CultureInfo.InvariantCulture, out iteracoesSalvas) ||
                iteracoesSalvas < 10000 || iteracoesSalvas > 1000000)
            {
                return false;
            }

            try
            {
                byte[] sal = Convert.FromBase64String(partes[2]);
                byte[] hashSalvo = Convert.FromBase64String(partes[3]);
                if (sal.Length != TamanhoDoSal || hashSalvo.Length != TamanhoDoHash)
                {
                    return false;
                }

                byte[] hashCalculado;
                using (Rfc2898DeriveBytes derivador = new Rfc2898DeriveBytes(senha, sal, iteracoesSalvas))
                {
                    hashCalculado = derivador.GetBytes(TamanhoDoHash);
                }

                return CompararEmTempoConstante(hashCalculado, hashSalvo);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool PrecisaMigrar(string valorSalvo)
        {
            return string.IsNullOrEmpty(valorSalvo) || !valorSalvo.StartsWith(Prefixo + "$", StringComparison.Ordinal);
        }

        private static bool CompararEmTempoConstante(byte[] primeiro, byte[] segundo)
        {
            if (primeiro == null || segundo == null || primeiro.Length != segundo.Length)
            {
                return false;
            }

            int diferenca = 0;
            for (int i = 0; i < primeiro.Length; i++)
            {
                diferenca |= primeiro[i] ^ segundo[i];
            }

            return diferenca == 0;
        }
    }
}
