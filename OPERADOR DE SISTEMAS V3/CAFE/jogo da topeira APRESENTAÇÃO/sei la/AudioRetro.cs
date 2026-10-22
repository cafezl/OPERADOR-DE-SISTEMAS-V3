using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;

namespace sei_la
{
    // Sintetiza efeitos originais: não baixa áudio e não precisa de caixas de som para o jogo funcionar.
    // SoundPlayer aceita WAV PCM, um formato simples que o próprio Windows consegue reproduzir.
    public static class AudioRetro
    {
        private const int AmostrasPorSegundo = 22050;
        private static bool ativo = true;
        private static bool indisponivel;
        private static Efeito acerto;
        private static Efeito menu;
        private static Efeito vitoria;

        // A opção de som também interrompe um efeito que já esteja tocando.
        public static bool Ativo
        {
            get { return ativo; }
            set
            {
                ativo = value;
                if (!ativo) Parar();
            }
        }

        public static void Acerto()
        {
            Tocar(ref acerto, CriarAcerto);
        }

        public static void Menu()
        {
            Tocar(ref menu, CriarMenu);
        }

        public static void Vitoria()
        {
            Tocar(ref vitoria, CriarVitoria);
        }

        // O mesmo áudio pode acompanhar a exportação da cena para um vídeo offline.
        public static byte[] CriarSomVitoria()
        {
            return CriarVitoria();
        }

        // Os efeitos ficam em memória depois do primeiro uso. Play toca sem travar a janela.
        // Um novo efeito substitui o anterior; muitos cliques nunca criam uma fila de sons atrasados.
        private static void Tocar(ref Efeito efeito, Func<byte[]> gerar)
        {
            if (!ativo || indisponivel) return;
            try
            {
                if (efeito == null) efeito = new Efeito(gerar());
                efeito.Player.Play();
            }
            catch (InvalidOperationException) { indisponivel = true; }
            catch (IOException) { indisponivel = true; }
            catch (ExternalException) { indisponivel = true; }
        }

        public static void Parar()
        {
            try
            {
                if (acerto != null) acerto.Player.Stop();
                if (menu != null) menu.Player.Stop();
                if (vitoria != null) vitoria.Player.Stop();
            }
            catch (InvalidOperationException) { indisponivel = true; }
            catch (ExternalException) { indisponivel = true; }
        }

        // Chamada quando o aplicativo termina: libera tanto o reprodutor quanto o WAV em memória.
        public static void Liberar()
        {
            Parar();
            if (acerto != null) acerto.Dispose();
            if (menu != null) menu.Dispose();
            if (vitoria != null) vitoria.Dispose();
            acerto = menu = vitoria = null;
            indisponivel = false;
        }

        // Dois pulsos de frequência descendente dão a sensação de "nhac"/bolha sendo engolida.
        // A onda senoidal deixa o efeito macio; o harmônico acrescenta o timbre de fliperama.
        private static byte[] CriarAcerto()
        {
            const double duracao = 0.16;
            double fase = 0;
            return CriarWav(duracao, delegate(double t)
            {
                double progresso = t / duracao;
                double frequencia = 780 * Math.Pow(0.20, progresso) + 100 * Math.Sin(progresso * Math.PI * 4);
                fase += 2 * Math.PI * frequencia / AmostrasPorSegundo;
                double boca = 0.45 + 0.55 * Math.Abs(Math.Sin(progresso * Math.PI * 2));
                double envelope = Math.Min(1, t / 0.005) * Math.Pow(1 - progresso, 0.55);
                return (Math.Sin(fase) + 0.23 * Math.Sin(fase * 2)) * boca * envelope * 0.55;
            });
        }

        // Pequeno sinal ao selecionar uma opção do menu, sem som longo sobre a apresentação.
        private static byte[] CriarMenu()
        {
            return CriarWav(0.065, delegate(double t)
            {
                double envelope = Math.Sin(Math.PI * t / 0.065);
                return Math.Sin(2 * Math.PI * 880 * t) * envelope * 0.28;
            });
        }

        // Uma melodia ascendente curta, criada para este jogo, marca a conquista das 30 toupeiras.
        private static byte[] CriarVitoria()
        {
            double[] notas = { 523.25, 659.25, 783.99, 1046.50, 783.99, 1046.50, 1318.51 };
            return CriarWav(2.45, delegate(double t)
            {
                int indice = Math.Min((int)(t / 0.25), notas.Length - 1);
                double inicio = indice * 0.25;
                double tempoNota = t - inicio;
                double duracaoNota = indice == notas.Length - 1 ? 0.95 : 0.25;
                double envelope = Math.Min(1, tempoNota / 0.012)
                    * Math.Max(0, 1 - tempoNota / duracaoNota);
                double fase = 2 * Math.PI * notas[indice] * tempoNota;
                // Harmônicos suaves lembram um console antigo sem usar uma onda muito estridente.
                return (Math.Sin(fase) + 0.20 * Math.Sin(fase * 3)
                    + 0.12 * Math.Sin(fase * 0.5)) * envelope * 0.42;
            });
        }

        // Cabeçalho RIFF/WAVE + amostras de 16 bits. Cada amostra descreve a posição do alto-falante.
        private static byte[] CriarWav(double duracao, Func<double, double> amostra)
        {
            int quantidade = (int)(duracao * AmostrasPorSegundo);
            using (MemoryStream arquivo = new MemoryStream(44 + quantidade * 2))
            using (BinaryWriter escritor = new BinaryWriter(arquivo))
            {
                escritor.Write(new[] { (byte)'R', (byte)'I', (byte)'F', (byte)'F' });
                escritor.Write(36 + quantidade * 2);
                escritor.Write(new[] { (byte)'W', (byte)'A', (byte)'V', (byte)'E' });
                escritor.Write(new[] { (byte)'f', (byte)'m', (byte)'t', (byte)' ' });
                escritor.Write(16);             // Tamanho do cabeçalho PCM.
                escritor.Write((short)1);        // PCM: áudio sem compressão.
                escritor.Write((short)1);        // Um canal (mono).
                escritor.Write(AmostrasPorSegundo);
                escritor.Write(AmostrasPorSegundo * 2);
                escritor.Write((short)2);
                escritor.Write((short)16);
                escritor.Write(new[] { (byte)'d', (byte)'a', (byte)'t', (byte)'a' });
                escritor.Write(quantidade * 2);
                for (int i = 0; i < quantidade; i++)
                {
                    double valor = Math.Max(-1, Math.Min(1, amostra((double)i / AmostrasPorSegundo)));
                    escritor.Write((short)(valor * short.MaxValue));
                }
                return arquivo.ToArray();
            }
        }

        // O stream precisa continuar aberto enquanto SoundPlayer usa os bytes do efeito.
        private sealed class Efeito : IDisposable
        {
            private readonly MemoryStream dados;
            public SoundPlayer Player { get; private set; }

            public Efeito(byte[] wav)
            {
                dados = new MemoryStream(wav, false);
                Player = new SoundPlayer(dados);
                try { Player.Load(); }
                catch
                {
                    Player.Dispose();
                    dados.Dispose();
                    throw;
                }
            }

            public void Dispose()
            {
                Player.Dispose();
                dados.Dispose();
            }
        }
    }
}
