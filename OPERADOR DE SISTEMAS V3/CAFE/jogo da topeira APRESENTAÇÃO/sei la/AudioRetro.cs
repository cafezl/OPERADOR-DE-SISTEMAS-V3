using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Media;

namespace sei_la
{
    // Um misturador envia música e efeitos juntos ao Windows. Um acerto não corta a música
    // nem desativa os próximos acertos, como podia acontecer com vários SoundPlayer.
    public static class AudioRetro
    {
        private const int Taxa = 22050;
        private static readonly object trava = new object();
        private static readonly List<Voz> efeitos = new List<Voz>();
        private static SaidaAudio saida;
        private static MediaPlayer faixaPlayer;
        private static short[] musica, menuMusical, partidaMusical;
        private static readonly Dictionary<string, short[]> sons = new Dictionary<string, short[]>();
        private static int posicaoMusica, volumeMusica = 18, volumeEfeitos = 80;
        private static bool ativo = true, musicaPausada;
        public static string UltimoErro { get; private set; }

        // Mantido para abrir preferências antigas; agora o acerto sempre usa a mesma pisada.
        public static int EstiloAcerto { get; set; }
        public static int VolumeMusica
        {
            get { lock (trava) return volumeMusica; }
            set
            {
                lock (trava)
                {
                    volumeMusica = Math.Max(0, Math.Min(100, value));
                    if (faixaPlayer != null) faixaPlayer.Volume = volumeMusica / 100.0;
                }
            }
        }
        public static int VolumeEfeitos
        {
            get { lock (trava) return volumeEfeitos; }
            set { lock (trava) volumeEfeitos = Math.Max(0, Math.Min(100, value)); }
        }
        public static bool Ativo
        {
            get { lock (trava) return ativo; }
            set
            {
                lock (trava)
                {
                    ativo = value;
                    if (!value) efeitos.Clear();
                    if (faixaPlayer != null)
                    {
                        if (!value) faixaPlayer.Pause();
                        else if (!musicaPausada) faixaPlayer.Play();
                    }
                    else if (value && musica != null) GarantirSaida();
                }
            }
        }

        public static void Acerto() { Tocar("acerto", delegate { return CriarSomAcerto(0); }); }
        public static void Menu() { Tocar("menu", delegate { return CriarTom(0.065, 880, 0.24); }); }
        public static void Inicio() { Tocar("inicio", CriarSomInicio); }
        public static void Pausa() { Tocar("pausa", delegate { return CriarTom(0.12, 440, 0.25); }); }
        public static void Vitoria() { PararMusica(); Tocar("vitoria", CriarSomVitoria); }

        public static void MusicaMenu()
        {
            lock (trava)
            {
                FecharFaixa();
                musicaPausada = false;
                string caminho = CaminhoMidia("musica-menu.mp3");
                if (File.Exists(caminho) && AbrirFaixa(caminho)) return;
                SelecionarMusica(ObterTemaMenuReserva());
            }
        }
        public static void MusicaJogo()
        {
            lock (trava)
            {
                FecharFaixa();
                if (partidaMusical == null)
                {
                    try { partidaMusical = LerWav(File.ReadAllBytes(CaminhoMidia("musica-partida.wav"))); }
                    catch (IOException) { UltimoErro = "A música da partida não foi encontrada na pasta midia."; musica = null; return; }
                    catch (UnauthorizedAccessException) { UltimoErro = "Não foi possível abrir a música da partida."; musica = null; return; }
                }
                SelecionarMusica(partidaMusical);
            }
        }
        private static short[] ObterTemaMenuReserva()
        {
            if (menuMusical == null) menuMusical = LerWav(CriarMusicaMenu());
            return menuMusical;
        }
        private static bool AbrirFaixa(string caminho)
        {
            MediaPlayer player = null;
            try
            {
                player = new MediaPlayer();
                player.Volume = volumeMusica / 100.0;
                faixaPlayer = player;
                player.MediaOpened += delegate(object sender, EventArgs args)
                {
                    lock (trava)
                    {
                        if (Object.ReferenceEquals(faixaPlayer, player) && ativo && !musicaPausada) player.Play();
                    }
                };
                player.MediaEnded += delegate(object sender, EventArgs args)
                {
                    lock (trava)
                    {
                        if (Object.ReferenceEquals(faixaPlayer, player))
                        {
                            player.Position = TimeSpan.Zero;
                            if (ativo && !musicaPausada) player.Play();
                        }
                    }
                };
                player.MediaFailed += delegate(object sender, ExceptionEventArgs args)
                {
                    lock (trava)
                    {
                        if (!Object.ReferenceEquals(faixaPlayer, player)) return;
                        UltimoErro = "Não foi possível abrir a música enviada; usando a faixa de reserva.";
                        FecharFaixa();
                        SelecionarMusica(ObterTemaMenuReserva());
                    }
                };
                musica = null;
                posicaoMusica = 0;
                player.Open(new Uri(caminho, UriKind.Absolute));
                GarantirSaida();
                UltimoErro = "";
                return true;
            }
            catch (InvalidOperationException)
            {
                if (Object.ReferenceEquals(faixaPlayer, player)) FecharFaixa();
                UltimoErro = "Não foi possível abrir a música enviada; usando a faixa de reserva.";
                return false;
            }
            catch (IOException)
            {
                if (Object.ReferenceEquals(faixaPlayer, player)) FecharFaixa();
                UltimoErro = "Não foi possível ler a música enviada; usando a faixa de reserva.";
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                if (Object.ReferenceEquals(faixaPlayer, player)) FecharFaixa();
                UltimoErro = "Não foi possível acessar a música enviada; usando a faixa de reserva.";
                return false;
            }
        }
        private static void FecharFaixa()
        {
            MediaPlayer anterior = faixaPlayer;
            faixaPlayer = null;
            if (anterior == null) return;
            try { anterior.Stop(); }
            catch (InvalidOperationException) { }
            anterior.Close();
        }
        private static void SelecionarMusica(short[] faixa)
        {
            if (!Object.ReferenceEquals(musica, faixa)) { musica = faixa; posicaoMusica = 0; }
            musicaPausada = false;
            GarantirSaida();
        }
        public static void PausarMusica()
        {
            lock (trava)
            {
                musicaPausada = true;
                if (faixaPlayer != null) faixaPlayer.Pause();
            }
        }
        public static void RetomarMusica()
        {
            lock (trava)
            {
                musicaPausada = false;
                if (faixaPlayer != null)
                {
                    if (ativo) faixaPlayer.Play();
                }
                else GarantirSaida();
            }
        }
        public static void PararMusica()
        {
            lock (trava)
            {
                FecharFaixa();
                musica = null;
                posicaoMusica = 0;
            }
        }
        public static void Parar() { lock (trava) efeitos.Clear(); }

        // Cada clique inicia uma voz independente. As pancadas podem se sobrepor sem criar fila.
        private static void Tocar(string nome, Func<byte[]> gerar)
        {
            lock (trava)
            {
                if (!ativo || volumeEfeitos == 0) return;
                short[] som;
                if (!sons.TryGetValue(nome, out som)) { som = LerWav(gerar()); sons.Add(nome, som); }
                if (efeitos.Count == 8) efeitos.RemoveAt(0);
                efeitos.Add(new Voz { Amostras = som });
                GarantirSaida();
            }
        }
        private static void GarantirSaida()
        {
            if (saida != null && !saida.Falhou) return;
            // Uma falha de dispositivo não bloqueia o som para sempre: o próximo clique tenta de novo.
            if (saida != null) { saida.Dispose(); saida = null; }
            try { saida = new SaidaAudio(); UltimoErro = ""; }
            catch (InvalidOperationException) { UltimoErro = "O dispositivo de áudio está indisponível. O próximo acerto tentará novamente."; }
        }
        public static void Liberar()
        {
            SaidaAudio antiga;
            lock (trava)
            {
                FecharFaixa();
                antiga = saida; saida = null; musica = null; efeitos.Clear(); sons.Clear(); menuMusical = partidaMusical = null;
            }
            if (antiga != null) antiga.Dispose();
        }

        // Este método roda na thread de áudio. Os controles da tela nunca são acessados aqui.
        private static void Misturar(short[] destino)
        {
            lock (trava)
            {
                for (int i = 0; i < destino.Length; i++)
                {
                    int valor = 0;
                    if (ativo)
                    {
                        if (musica != null && !musicaPausada)
                        {
                            valor += musica[posicaoMusica++] * volumeMusica / 100;
                            if (posicaoMusica == musica.Length) posicaoMusica = 0;
                        }
                        for (int v = efeitos.Count - 1; v >= 0; v--)
                        {
                            Voz voz = efeitos[v];
                            valor += voz.Amostras[voz.Posicao++] * volumeEfeitos / 100;
                            if (voz.Posicao == voz.Amostras.Length) efeitos.RemoveAt(v);
                        }
                    }
                    destino[i] = (short)Math.Max(Int16.MinValue, Math.Min(Int16.MaxValue, valor));
                }
            }
        }
        private sealed class Voz { public short[] Amostras; public int Posicao; }

        private static string CaminhoMidia(string nome)
        {
            string pasta = AppDomain.CurrentDomain.BaseDirectory;
            for (int i = 0; i < 5 && pasta != null; i++)
            {
                string candidato = Path.Combine(pasta, "midia", nome);
                if (File.Exists(candidato)) return candidato;
                DirectoryInfo pai = Directory.GetParent(pasta.TrimEnd(Path.DirectorySeparatorChar));
                pasta = pai == null ? null : pai.FullName;
            }
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "midia", nome);
        }

        public static byte[] CriarSomAcerto(int estilo)
        {
            try { return File.ReadAllBytes(CaminhoMidia("acerto-stomp.wav")); }
            catch (IOException) { return CriarPisadaReserva(); }
            catch (UnauthorizedAccessException) { return CriarPisadaReserva(); }
        }
        private static byte[] CriarPisadaReserva()
        {
            // Se alguém copiar só o EXE, ainda há uma pancada de reserva para o jogo continuar.
            return CriarWav(0.18, delegate(double t)
            { return Math.Sin(2 * Math.PI * (190 * t - 380 * t * t)) * Math.Exp(-t * 20) * 0.65; });
        }
        private static byte[] CriarTom(double tempo, double nota, double volume)
        { return CriarWav(tempo, delegate(double t) { return Math.Sin(2 * Math.PI * nota * t) * Math.Sin(Math.PI * t / tempo) * volume; }); }
        public static byte[] CriarSomInicio()
        { return CriarWav(0.25, delegate(double t) { return Math.Sin(2 * Math.PI * (260 * t + 1700 * t * t)) * Math.Sin(Math.PI * t / 0.25) * 0.43; }); }
        public static byte[] CriarSomVitoria()
        {
            double[] notas = { 392, 493.88, 587.33, 783.99, 659.25, 880, 1174.66, 1568 };
            return CriarWav(2.70, delegate(double t)
            {
                int indice = Math.Min((int)(t / 0.25), notas.Length - 1);
                double local = t - indice * 0.25, duracao = indice == notas.Length - 1 ? 0.95 : 0.25;
                double envelope = Math.Min(1, local / 0.012) * Math.Max(0, 1 - local / duracao);
                double fase = 2 * Math.PI * notas[indice] * local;
                return (Math.Sin(fase) * 0.43 + Math.Sin(fase * 0.25) * 0.15) * envelope;
            });
        }
        private static byte[] CriarMusicaMenu()
        {
            // Pequeno tema original de marimba e baixo, em 16 compassos curtos que se repetem.
            double[] notas = { 440, 523.25, 659.25, 523.25, 392, 493.88, 587.33, 493.88,
                349.23, 440, 523.25, 440, 392, 493.88, 587.33, 392 };
            return CriarWav(8.0, delegate(double t)
            {
                int nota = Math.Min(15, (int)(t / 0.5));
                double local = t - nota * 0.5;
                double fase = 2 * Math.PI * notas[nota] * local;
                double envelope = Math.Min(1, local / 0.008) * Math.Exp(-local * 11) * Math.Min(1, (0.5 - local) / 0.04);
                double baixo = Math.Sin(2 * Math.PI * notas[nota - nota % 4] * 0.25 * local) * Math.Sin(Math.PI * local / 0.5);
                return (Math.Sin(fase) + 0.2 * Math.Sin(fase * 3)) * envelope * 0.32 + baixo * 0.10;
            });
        }

        // Os WAVs do projeto usam PCM mono de 16 bits, a 22.050 amostras por segundo.
        private static short[] LerWav(byte[] bytes)
        {
            using (BinaryReader leitor = new BinaryReader(new MemoryStream(bytes)))
            {
                if (new string(leitor.ReadChars(4)) != "RIFF") throw new InvalidDataException("WAV inválido.");
                leitor.ReadInt32();
                if (new string(leitor.ReadChars(4)) != "WAVE") throw new InvalidDataException("WAV inválido.");
                bool formatoValido = false;
                while (leitor.BaseStream.Position + 8 <= leitor.BaseStream.Length)
                {
                    string parte = new string(leitor.ReadChars(4)); int tamanho = leitor.ReadInt32();
                    long fim = leitor.BaseStream.Position + tamanho;
                    if (tamanho < 0 || fim > leitor.BaseStream.Length) throw new InvalidDataException("WAV truncado.");
                    if (parte == "fmt " && tamanho >= 16)
                    {
                        int pcm = leitor.ReadInt16(), canais = leitor.ReadInt16(), taxa = leitor.ReadInt32();
                        leitor.ReadInt32(); leitor.ReadInt16(); int bits = leitor.ReadInt16();
                        formatoValido = pcm == 1 && canais == 1 && taxa == Taxa && bits == 16;
                    }
                    else if (parte == "data" && formatoValido && tamanho >= 2)
                    {
                        byte[] dados = leitor.ReadBytes(tamanho); short[] amostras = new short[tamanho / 2];
                        Buffer.BlockCopy(dados, 0, amostras, 0, amostras.Length * 2); return amostras;
                    }
                    leitor.BaseStream.Position = fim + (tamanho & 1);
                }
            }
            throw new InvalidDataException("O áudio deve ser WAV PCM mono de 16 bits e 22050 Hz.");
        }
        private static byte[] CriarWav(double duracao, Func<double, double> amostra)
        {
            int total = (int)(duracao * Taxa);
            using (MemoryStream memoria = new MemoryStream(44 + total * 2))
            using (BinaryWriter w = new BinaryWriter(memoria))
            {
                w.Write(new[] { (byte)'R', (byte)'I', (byte)'F', (byte)'F' }); w.Write(36 + total * 2);
                w.Write(new[] { (byte)'W', (byte)'A', (byte)'V', (byte)'E', (byte)'f', (byte)'m', (byte)'t', (byte)' ' });
                w.Write(16); w.Write((short)1); w.Write((short)1); w.Write(Taxa); w.Write(Taxa * 2); w.Write((short)2); w.Write((short)16);
                w.Write(new[] { (byte)'d', (byte)'a', (byte)'t', (byte)'a' }); w.Write(total * 2);
                for (int i = 0; i < total; i++) w.Write((short)(Math.Max(-1, Math.Min(1, amostra((double)i / Taxa))) * Int16.MaxValue));
                return memoria.ToArray();
            }
        }

        // Três pequenos buffers mantêm o som contínuo, com latência de aproximadamente 60 ms.
        // Cada buffer permanece alocado e preparado até o encerramento do dispositivo.
        private sealed class SaidaAudio : IDisposable
        {
            private IntPtr dispositivo;
            private readonly AutoResetEvent pronto = new AutoResetEvent(false);
            private readonly IntPtr[] cabecalhos = new IntPtr[3], dados = new IntPtr[3];
            private readonly bool[] enviados = new bool[3];
            private readonly int tamanhoCabecalho = Marshal.SizeOf(typeof(WaveHeader));
            private Thread thread;
            private volatile bool encerrar;
            public bool Falhou { get; private set; }
            public long BuffersEnviados { get; private set; }
            public SaidaAudio()
            {
                try
                {
                    WaveFormat formato = new WaveFormat { FormatTag = 1, Channels = 1, SamplesPerSec = Taxa,
                        AvgBytesPerSec = Taxa * 2, BlockAlign = 2, BitsPerSample = 16 };
                    if (waveOutOpen(out dispositivo, UInt32.MaxValue, ref formato, pronto.SafeWaitHandle.DangerousGetHandle(), IntPtr.Zero, 0x50000) != 0)
                        throw new InvalidOperationException("Não foi possível abrir a saída de som.");
                    for (int i = 0; i < 3; i++)
                    {
                        dados[i] = Marshal.AllocHGlobal(882); cabecalhos[i] = Marshal.AllocHGlobal(tamanhoCabecalho);
                        Marshal.StructureToPtr(new WaveHeader { Data = dados[i], BufferLength = 882 }, cabecalhos[i], false);
                        if (waveOutPrepareHeader(dispositivo, cabecalhos[i], tamanhoCabecalho) != 0) throw new InvalidOperationException("Falha ao preparar áudio.");
                    }
                    thread = new Thread(Reproduzir) { IsBackground = true, Name = "Audio da Ilha" }; thread.Start();
                }
                catch { Dispose(); throw; }
            }
            private void Reproduzir()
            {
                short[] amostras = new short[441];
                while (!encerrar)
                {
                    for (int i = 0; i < 3 && !encerrar; i++)
                    {
                        WaveHeader header = (WaveHeader)Marshal.PtrToStructure(cabecalhos[i], typeof(WaveHeader));
                        if (enviados[i] && (header.Flags & 1) == 0) continue;
                        Misturar(amostras); Marshal.Copy(amostras, 0, dados[i], amostras.Length);
                        if (waveOutWrite(dispositivo, cabecalhos[i], tamanhoCabecalho) != 0) { Falhou = true; return; }
                        enviados[i] = true; BuffersEnviados++;
                    }
                    pronto.WaitOne(20);
                }
            }
            public void Dispose()
            {
                encerrar = true; pronto.Set();
                if (thread != null && !thread.Join(1500)) return;
                if (dispositivo != IntPtr.Zero) waveOutReset(dispositivo);
                for (int i = 0; i < 3; i++)
                {
                    if (cabecalhos[i] != IntPtr.Zero) { if (dispositivo != IntPtr.Zero) waveOutUnprepareHeader(dispositivo, cabecalhos[i], tamanhoCabecalho); Marshal.FreeHGlobal(cabecalhos[i]); cabecalhos[i] = IntPtr.Zero; }
                    if (dados[i] != IntPtr.Zero) { Marshal.FreeHGlobal(dados[i]); dados[i] = IntPtr.Zero; }
                }
                if (dispositivo != IntPtr.Zero) { waveOutClose(dispositivo); dispositivo = IntPtr.Zero; }
                pronto.Dispose();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        private struct WaveFormat { public ushort FormatTag, Channels; public uint SamplesPerSec, AvgBytesPerSec; public ushort BlockAlign, BitsPerSample, ExtraSize; }
        [StructLayout(LayoutKind.Sequential)]
        private struct WaveHeader { public IntPtr Data; public uint BufferLength, BytesRecorded; public UIntPtr User; public uint Flags, Loops; public IntPtr Next; public UIntPtr Reserved; }
        [DllImport("winmm.dll")] private static extern uint waveOutOpen(out IntPtr device, uint id, ref WaveFormat format, IntPtr callback, IntPtr instance, uint flags);
        [DllImport("winmm.dll")] private static extern uint waveOutPrepareHeader(IntPtr device, IntPtr header, int size);
        [DllImport("winmm.dll")] private static extern uint waveOutWrite(IntPtr device, IntPtr header, int size);
        [DllImport("winmm.dll")] private static extern uint waveOutReset(IntPtr device);
        [DllImport("winmm.dll")] private static extern uint waveOutUnprepareHeader(IntPtr device, IntPtr header, int size);
        [DllImport("winmm.dll")] private static extern uint waveOutClose(IntPtr device);
    }
}
