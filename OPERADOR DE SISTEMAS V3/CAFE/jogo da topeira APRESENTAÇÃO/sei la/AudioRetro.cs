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
        private static readonly Efeito[] acertos = new Efeito[3];
        private static int estiloAcerto;
        private static Efeito menu;
        private static Efeito inicio;
        private static Efeito pausa;
        private static Efeito vitoria;

        // 0: moeda de 8 bits; 1: anel de 16 bits; 2: caixa de aventura.
        // São timbres próprios, não gravações retiradas de jogos comerciais.
        public static int EstiloAcerto
        {
            get { return estiloAcerto; }
            set { estiloAcerto = Math.Max(0, Math.Min(2, value)); }
        }

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
            int estilo = EstiloAcerto;
            Tocar(ref acertos[estilo], delegate { return CriarSomAcerto(estilo); });
        }

        public static void Menu()
        {
            Tocar(ref menu, CriarMenu);
        }

        public static void Vitoria()
        {
            Tocar(ref vitoria, CriarVitoria);
        }

        public static void Inicio() { Tocar(ref inicio, CriarSomInicio); }
        public static void Pausa() { Tocar(ref pausa, CriarPausa); }

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
                foreach (Efeito acerto in acertos) if (acerto != null) acerto.Player.Stop();
                if (menu != null) menu.Player.Stop();
                if (inicio != null) inicio.Player.Stop();
                if (pausa != null) pausa.Player.Stop();
                if (vitoria != null) vitoria.Player.Stop();
            }
            catch (InvalidOperationException) { indisponivel = true; }
            catch (ExternalException) { indisponivel = true; }
        }

        // Chamada quando o aplicativo termina: libera tanto o reprodutor quanto o WAV em memória.
        public static void Liberar()
        {
            Parar();
            for (int i = 0; i < acertos.Length; i++)
            {
                if (acertos[i] != null) acertos[i].Dispose();
                acertos[i] = null;
            }
            if (menu != null) menu.Dispose();
            if (inicio != null) inicio.Dispose();
            if (pausa != null) pausa.Dispose();
            if (vitoria != null) vitoria.Dispose();
            menu = inicio = pausa = vitoria = null;
            indisponivel = false;
        }

        // Uma onda quadrada suave lembra o console antigo, sem agudos excessivos.
        private static double Pulso(double fase)
        {
            return (Math.Sin(fase) + Math.Sin(fase * 3) / 3 + Math.Sin(fase * 5) / 5) / 1.54;
        }

        public static byte[] CriarSomAcerto(int estilo)
        {
            if (estilo == 1) return CriarAnel();
            if (estilo == 2) return CriarCaixa();
            // Dois tons curtos em subida: a sensação de coletar uma moeda.
            return CriarWav(0.23, delegate(double t)
            {
                bool segunda = t >= 0.065;
                double local = segunda ? t - 0.065 : t;
                double fim = segunda ? 0.165 : 0.065;
                double envelope = Math.Min(1, local / 0.003) * Math.Pow(Math.Max(0, 1 - local / fim), 0.65);
                return Pulso(2 * Math.PI * (segunda ? 1568 : 1174.66) * local) * envelope * 0.53;
            });
        }

        private static byte[] CriarAnel()
        {
            // Modulação de frequência dá o brilho metálico característico de um item coletável.
            return CriarWav(0.30, delegate(double t)
            {
                double envelope = Math.Min(1, t / 0.003) * Math.Pow(1 - t / 0.30, 1.8);
                double baseFase = 2 * Math.PI * 1480 * t;
                double brilho = Math.Sin(baseFase + 1.1 * Math.Exp(-t * 18) * Math.Sin(baseFase * 1.5));
                return (brilho + 0.24 * Math.Sin(2 * Math.PI * 2220 * t)) * envelope * 0.46;
            });
        }

        private static byte[] CriarCaixa()
        {
            // Ruído filtrado e dois tons graves formam uma pancada curta de madeira.
            uint semente = 137;
            double filtro = 0;
            return CriarWav(0.19, delegate(double t)
            {
                semente = unchecked(semente * 1664525u + 1013904223u);
                double ruido = (semente / (double)UInt32.MaxValue) * 2 - 1;
                filtro = filtro * 0.55 + ruido * 0.45;
                double envelope = Math.Min(1, t / 0.002) * Math.Pow(1 - t / 0.19, 2);
                double madeira = Math.Sin(2 * Math.PI * 185 * t) + 0.42 * Math.Sin(2 * Math.PI * 470 * t);
                return (madeira * 0.37 + filtro * 0.34) * envelope;
            });
        }

        public static byte[] CriarSomInicio()
        {
            // Varredura ascendente curta: o "pulo" que confirma o início da aventura.
            const double duracao = 0.25;
            return CriarWav(duracao, delegate(double t)
            {
                double fase = 2 * Math.PI * (260 * t + 1700 * t * t);
                double envelope = Math.Sin(Math.PI * t / duracao);
                return Pulso(fase) * envelope * 0.43;
            });
        }

        private static byte[] CriarPausa()
        {
            return CriarWav(0.14, delegate(double t)
            {
                double fase = 2 * Math.PI * (800 * t - 1600 * t * t);
                return Pulso(fase) * Math.Sin(Math.PI * t / 0.14) * 0.28;
            });
        }

        // Pequeno sinal ao selecionar uma opção do menu, sem som longo sobre a apresentação.
        private static byte[] CriarMenu()
        {
            return CriarWav(0.065, delegate(double t)
            {
                double envelope = Math.Sin(Math.PI * t / 0.065);
                return Pulso(2 * Math.PI * 880 * t) * envelope * 0.28;
            });
        }

        // Uma melodia ascendente curta, criada para este jogo, marca a conquista das 30 toupeiras.
        private static byte[] CriarVitoria()
        {
            double[] notas = { 392, 493.88, 587.33, 783.99, 659.25, 880, 1174.66, 1568 };
            return CriarWav(2.70, delegate(double t)
            {
                int indice = Math.Min((int)(t / 0.25), notas.Length - 1);
                double inicio = indice * 0.25;
                double tempoNota = t - inicio;
                double duracaoNota = indice == notas.Length - 1 ? 0.95 : 0.25;
                double envelope = Math.Min(1, tempoNota / 0.012)
                    * Math.Max(0, 1 - tempoNota / duracaoNota);
                double fase = 2 * Math.PI * notas[indice] * tempoNota;
                // Melodia de pulso e baixo senoidal: duas vozes num mesmo WAV.
                return (Pulso(fase) * 0.43 + Math.Sin(fase * 0.25) * 0.15) * envelope;
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
