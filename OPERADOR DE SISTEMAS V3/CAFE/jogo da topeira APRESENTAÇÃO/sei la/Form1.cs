using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace sei_la
{
    // Apenas dois Forms: este menu troca painéis; Form2 contém a partida.
    public partial class Form1 : Form
    {
        private CenarioMenu cenario;
        private readonly List<AreaControle> areas = new List<AreaControle>();
        private Button[] opcoesMenu;
        private Button acaoEnter;
        private string pagina = "inicio";
        private bool telaCheia, carregando, processandoConta;
        private Rectangle limitesAnteriores;
        private FormBorderStyle bordaAnterior;
        private FormWindowState estadoAnterior;
        private Timer timerCarga;
        private bool recursosLiberados;

        public Form1()
        {
            InitializeComponent();
            // Os controles antigos do Designer dão lugar às páginas do mesmo menu.
            while (Controls.Count > 0) Controls[0].Dispose();
            BackgroundImage = null;
            AutoScaleMode = AutoScaleMode.None;
            DoubleBuffered = true;
            KeyPreview = true;
            MinimumSize = new Size(820, 560);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ilha da Toupeira • Café";
            Rectangle tela = Screen.PrimaryScreen.WorkingArea;
            ClientSize = new Size(Math.Min(1100, tela.Width - 48), Math.Min(690, tela.Height - 80));
            cenario = new CenarioMenu { Dock = DockStyle.Fill };
            Controls.Add(cenario);
            Resize += delegate { AjustarLayout(); };
            MostrarInicio();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProgressoJogo.Carregar();
            AplicarAudioSalvo();
            AudioRetro.MusicaMenu();
            MostrarInicio();
        }

        private void AplicarAudioSalvo()
        {
            AudioRetro.VolumeMusica = ProgressoJogo.VolumeMusica;
            AudioRetro.VolumeEfeitos = ProgressoJogo.VolumeEfeitos;
            AudioRetro.Ativo = ProgressoJogo.SomAtivo;
        }

        // Cada posição usa a mesma escala do cenário. A janela nunca estica só os botões.
        private T Colocar<T>(T controle, int x, int y, int w, int h, float tamanho = 15) where T : Control
        {
            cenario.Controls.Add(controle);
            areas.Add(new AreaControle { Controle = controle, Retangulo = new Rectangle(x, y, w, h), Tamanho = tamanho });
            AjustarLayout();
            return controle;
        }

        private void AjustarLayout()
        {
            if (cenario == null || cenario.Width == 0 || cenario.Height == 0) return;
            float escala = Math.Min(cenario.Width / 1100f, cenario.Height / 690f);
            int dx = (int)((cenario.Width - 1100 * escala) / 2), dy = (int)((cenario.Height - 690 * escala) / 2);
            foreach (AreaControle item in areas)
            {
                Rectangle r = item.Retangulo;
                item.Controle.SetBounds(dx + (int)(r.X * escala), dy + (int)(r.Y * escala),
                    Math.Max(1, (int)(r.Width * escala)), Math.Max(1, (int)(r.Height * escala)));
                float pontos = Math.Max(9, item.Tamanho * escala);
                if (item.Fonte == null || Math.Abs(item.Fonte.Size - pontos) > 0.1)
                {
                    Font anterior = item.Fonte;
                    item.Fonte = new Font(item.Controle is BotaoAventura ? "Arial Black" : "Segoe UI", pontos,
                        item.Controle is Button ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Pixel);
                    item.Controle.Font = item.Fonte;
                    if (anterior != null) anterior.Dispose();
                }
            }
            cenario.Invalidate();
        }

        private void LimparPagina(string nome)
        {
            acaoEnter = null;
            opcoesMenu = null;
            foreach (AreaControle item in areas)
            {
                item.Controle.Dispose();
                if (item.Fonte != null) item.Fonte.Dispose();
            }
            areas.Clear();
            pagina = nome;
            cenario.Interior = nome != "inicio" && nome != "carga";
        }

        private Label Texto(string texto, int x, int y, int w, int h, float tamanho = 17, bool ouro = false)
        {
            return Colocar(new Label { Text = texto, BackColor = Color.Transparent,
                ForeColor = ouro ? Color.FromArgb(255, 215, 100) : Color.FromArgb(230, 237, 231),
                TextAlign = ContentAlignment.MiddleLeft }, x, y, w, h, tamanho);
        }

        private Button Botao(string texto, int x, int y, int w, int h, Action acao, bool principal = false)
        {
            Button botao = new Button { Text = texto, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand,
                BackColor = principal ? Color.FromArgb(158, 66, 28) : Color.FromArgb(29, 51, 58),
                ForeColor = Color.FromArgb(255, 225, 155), UseVisualStyleBackColor = false };
            botao.FlatAppearance.BorderColor = Color.FromArgb(170, 125, 60);
            botao.Click += delegate { AudioRetro.Menu(); acao(); };
            return Colocar(botao, x, y, w, h, 16);
        }

        private void CabecalhoPagina(string titulo, string subtitulo)
        {
            Texto(titulo, 290, 112, 530, 50, 32, true);
            Texto(subtitulo, 290, 161, 530, 35, 15);
        }

        private void Voltar()
        {
            // Sair das opções sem salvar desfaz somente a prévia dos volumes.
            AplicarAudioSalvo();
            MostrarInicio();
        }

        private void MostrarInicio()
        {
            LimparPagina("inicio");
            string[] nomes = { "START", "A LENDA DA ILHA", "PASSWORD", "OPTIONS" };
            Action[] acoes = { delegate { Comecar(0, false); }, MostrarHistoria, delegate { MostrarConta(false); }, MostrarOpcoes };
            opcoesMenu = new Button[4];
            for (int i = 0; i < nomes.Length; i++)
            {
                Action executar = acoes[i];
                Button b = Colocar(new BotaoAventura { Text = nomes[i] }, 90, 310 + i * 65, 470, 60, 31);
                b.Click += delegate { AudioRetro.Menu(); executar(); };
                b.Enter += delegate { AudioRetro.Menu(); };
                opcoesMenu[i] = b;
            }
            Texto(PerfisJogador.NomeAtual + "  •  " + ProgressoJogo.AcertosSalvos + "/" + EstadoPartida.Meta + " salvos  •  recorde " + ProgressoJogo.Recorde,
                110, 603, 880, 30, 17, true);
            Texto("↑ ↓ e Enter ou mouse  •  F11: tela cheia  •  Esc: voltar", 110, 640, 900, 28, 15);
            opcoesMenu[0].Focus();
        }

        private void MostrarHistoria()
        {
            LimparPagina("historia");
            CabecalhoPagina("A LENDA DA ILHA", "Toda aventura começa com um problema pequeno...");
            Colocar(new TextBox { Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical,
                BorderStyle = BorderStyle.FixedSingle, BackColor = Color.FromArgb(24, 43, 49), ForeColor = Color.Wheat,
                Text = "No coração da ilha existe um jardim que alimenta seus moradores. Mas, numa noite, túneis começaram a aparecer por toda parte.\r\n\r\nAs toupeiras encontraram as sementes escondidas sob o antigo templo. Agora surgem em lugares diferentes e ninguém consegue cuidar da plantação.\r\n\r\nVocê recebeu o martelo do guardião. Sua missão é mandar 50 toupeiras de volta às tocas, recuperar 5.000 pontos e devolver a tranquilidade ao jardim.\r\n\r\nObserve, mire e acerte. A ilha conta com você." }, 290, 212, 520, 242, 19);
            Botao("VER VÍDEO • O GOSTO DA FELICIDADE", 290, 462, 520, 39, AbrirVideoFelicidade);
            Button continuar = Botao("CONTINUAR • " + ProgressoJogo.AcertosSalvos + "/" + EstadoPartida.Meta + "", 290, 514, 255, 43,
                delegate { Comecar(ProgressoJogo.AcertosSalvos, false); }, true);
            continuar.Enabled = ProgressoJogo.AcertosSalvos > 0;
            Botao("NOVA AVENTURA", 560, 514, 250, 43, delegate { Comecar(0, false); });
            Botao("VOLTAR", 435, 568, 230, 40, Voltar);
        }

        private void AbrirVideoFelicidade()
        {
            string caminho = Path.Combine(Application.StartupPath, "midia", "video-felicidade.mp4");
            if (!File.Exists(caminho))
            {
                MessageBox.Show(this, "Não encontrei o vídeo na pasta midia. Recompile a solução para copiá-lo.",
                    "Vídeo da felicidade", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                Process.Start(new ProcessStartInfo(caminho) { UseShellExecute = true });
            }
            catch (Win32Exception)
            {
                MessageBox.Show(this, "Não foi possível abrir o player de vídeo deste computador.",
                    "Vídeo da felicidade", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MostrarConta(bool cadastrar)
        {
            LimparPagina("conta");
            CabecalhoPagina("PASSWORD", "Seu perfil e sua aventura, salvos neste computador.");
            if (PerfisJogador.EstaLogado)
            {
                Texto("Bem-vindo, " + PerfisJogador.NomeAtual + "!", 300, 238, 510, 50, 25, true);
                Texto("Progresso: " + ProgressoJogo.AcertosSalvos + "/" + EstadoPartida.Meta + " toupeiras\nRecorde: " + ProgressoJogo.Recorde + " pontos",
                    300, 304, 510, 80, 21);
                Botao("CONTINUAR AVENTURA", 300, 414, 500, 45, delegate { Comecar(ProgressoJogo.AcertosSalvos, false); }, true);
                Botao("SAIR DO PERFIL", 300, 477, 500, 40, delegate
                { PerfisJogador.Sair(); ProgressoJogo.Carregar(); AplicarAudioSalvo(); MostrarConta(false); });
                Botao("VOLTAR", 435, 550, 230, 40, Voltar);
                return;
            }
            Botao("ENTRAR", 300, 205, 240, 36, delegate { MostrarConta(false); }, !cadastrar);
            Botao("CADASTRAR", 560, 205, 240, 36, delegate { MostrarConta(true); }, cadastrar);
            Texto("Nome do jogador", 300, 252, 500, 24, 16);
            TextBox nome = Colocar(new TextBox { MaxLength = 40, BorderStyle = BorderStyle.FixedSingle }, 300, 280, 500, 32, 19);
            TextBox cpf = null;
            if (cadastrar)
            {
                Texto("CPF • digite os 11 números", 300, 320, 500, 24, 16);
                cpf = Colocar(new TextBox { MaxLength = 14, BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.FromArgb(249, 247, 239), ForeColor = Color.FromArgb(26, 35, 37),
                    AccessibleName = "CPF (11 números)" }, 300, 347, 500, 32, 19);
                TextBox campoCpfFormatar = cpf;
                cpf.TextChanged += delegate { FormatarCpf(campoCpfFormatar); };
                cpf.KeyDown += TratarEdicaoCpf;
            }
            int ySenha = cadastrar ? 387 : 325;
            Texto("Senha" + (cadastrar ? " • pelo menos 6 caracteres" : ""), 300, ySenha, 500, 24, 16);
            TextBox senha = Colocar(new TextBox { MaxLength = 128, UseSystemPasswordChar = true, BorderStyle = BorderStyle.FixedSingle,
                AccessibleName = "Senha" }, 300, ySenha + 27, 500, 32, 19);
            Label aviso = Texto("", 300, 453, 500, 41, 15, true);
            TextBox campoCpf = cpf;
            acaoEnter = Botao(cadastrar ? "CRIAR PERFIL" : "ENTRAR NA ILHA", 300, 500, 500, 43, async delegate
            {
                processandoConta = true;
                string nomeDigitado = nome.Text, cpfDigitado = campoCpf == null ? "" : campoCpf.Text, senhaDigitada = senha.Text;
                foreach (Control controle in cenario.Controls) if (controle is Button || controle is TextBoxBase) controle.Enabled = false;
                aviso.Text = "Verificando seu perfil...";
                string erro = "";
                bool sucesso = await Task.Run(() => cadastrar ? PerfisJogador.Cadastrar(nomeDigitado, cpfDigitado, senhaDigitada, out erro)
                    : PerfisJogador.Entrar(nomeDigitado, senhaDigitada, out erro));
                if (IsDisposed) return;
                processandoConta = false;
                foreach (Control controle in cenario.Controls) controle.Enabled = true;
                if (!sucesso) { aviso.Text = erro; return; }
                senha.Clear();
                ProgressoJogo.Carregar();
                AplicarAudioSalvo();
                MostrarConta(false);
            }, true);
            Botao("VOLTAR", 435, 556, 230, 38, Voltar);
            nome.Focus();
        }

        // Formata um TextBox comum para que o usuário consiga digitar ou colar o CPF sem a máscara bloquear as teclas.
        private bool atualizandoCpf;

        private void FormatarCpf(TextBox campo)
        {
            if (atualizandoCpf) return;
            int posicao = Math.Min(campo.SelectionStart, campo.Text.Length);
            int digitosAntes = ContarDigitos(campo.Text.Substring(0, posicao));
            string digitos = ApenasDigitos(campo.Text);
            if (digitos.Length > 11) digitos = digitos.Substring(0, 11);
            string formatado = FormatarDigitosCpf(digitos);
            if (campo.Text == formatado) return;

            atualizandoCpf = true;
            campo.Text = formatado;
            campo.SelectionStart = PosicaoAposDigitos(formatado, digitosAntes);
            campo.SelectionLength = 0;
            atualizandoCpf = false;
        }

        private void TratarEdicaoCpf(object sender, KeyEventArgs e)
        {
            TextBox campo = sender as TextBox;
            if (campo == null || campo.SelectionLength != 0 ||
                (e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete)) return;

            int antes = ContarDigitos(campo.Text.Substring(0, Math.Min(campo.SelectionStart, campo.Text.Length)));
            int indice = e.KeyCode == Keys.Back ? antes - 1 : antes;
            string digitos = ApenasDigitos(campo.Text);
            if (indice < 0 || indice >= digitos.Length) return;

            e.Handled = true;
            e.SuppressKeyPress = true;
            digitos = digitos.Remove(indice, 1);
            string formatado = FormatarDigitosCpf(digitos);
            atualizandoCpf = true;
            campo.Text = formatado;
            campo.SelectionStart = PosicaoAposDigitos(formatado, e.KeyCode == Keys.Back ? indice : antes);
            campo.SelectionLength = 0;
            atualizandoCpf = false;
        }

        private static string ApenasDigitos(string texto)
        {
            var resultado = new System.Text.StringBuilder(11);
            foreach (char caractere in texto)
            {
                if (Char.IsDigit(caractere))
                {
                    resultado.Append(caractere);
                    if (resultado.Length == 11) break;
                }
            }
            return resultado.ToString();
        }

        private static int ContarDigitos(string texto)
        {
            int quantidade = 0;
            foreach (char caractere in texto) if (Char.IsDigit(caractere)) quantidade++;
            return quantidade;
        }

        private static string FormatarDigitosCpf(string digitos)
        {
            var texto = new System.Text.StringBuilder(14);
            for (int i = 0; i < digitos.Length; i++)
            {
                if (i == 3 || i == 6) texto.Append('.');
                else if (i == 9) texto.Append('-');
                texto.Append(digitos[i]);
            }
            return texto.ToString();
        }

        private static int PosicaoAposDigitos(string texto, int quantidade)
        {
            if (quantidade <= 0) return 0;
            int encontrados = 0;
            for (int i = 0; i < texto.Length; i++)
            {
                if (Char.IsDigit(texto[i]) && ++encontrados == quantidade) return i + 1;
            }
            return texto.Length;
        }

        private void MostrarOpcoes()
        {
            LimparPagina("opcoes");
            CabecalhoPagina("OPTIONS", "Ajuste a música e as pancadas separadamente.");
            CheckBox som = Colocar(new CheckBox { Text = "Áudio ativado", Checked = AudioRetro.Ativo,
                BackColor = Color.Transparent, ForeColor = Color.Wheat }, 300, 207, 500, 33, 18);
            Label txtMusica = Texto("MÚSICA • " + AudioRetro.VolumeMusica + "%", 300, 250, 500, 28, 20, true);
            TrackBar musica = Colocar(new TrackBar { Minimum = 0, Maximum = 100, TickFrequency = 10,
                Value = AudioRetro.VolumeMusica, AutoSize = false, BackColor = Color.FromArgb(24, 43, 49) }, 300, 282, 500, 42);
            Label txtEfeitos = Texto("EFEITOS • " + AudioRetro.VolumeEfeitos + "%", 300, 332, 500, 28, 20, true);
            TrackBar efeitos = Colocar(new TrackBar { Minimum = 0, Maximum = 100, TickFrequency = 10,
                Value = AudioRetro.VolumeEfeitos, AutoSize = false, BackColor = Color.FromArgb(24, 43, 49) }, 300, 365, 500, 42);
            som.CheckedChanged += delegate { AudioRetro.Ativo = som.Checked; };
            musica.ValueChanged += delegate { AudioRetro.VolumeMusica = musica.Value; txtMusica.Text = "MÚSICA • " + musica.Value + "%"; };
            efeitos.ValueChanged += delegate { AudioRetro.VolumeEfeitos = efeitos.Value; txtEfeitos.Text = "EFEITOS • " + efeitos.Value + "%"; };
            Botao("OUVIR PANCADA", 300, 424, 240, 40, delegate { AudioRetro.Acerto(); });
            Botao("TELA CHEIA • F11", 560, 424, 240, 40, AlternarTelaCheia);
            Botao("SALVAR OPÇÕES", 300, 482, 240, 42, delegate
            {
                ProgressoJogo.SalvarAudio(som.Checked, 0, musica.Value, efeitos.Value);
                MostrarInicio();
            }, true);
            Botao("VER FINAL • DEMO", 560, 482, 240, 42, delegate
            { AplicarAudioSalvo(); Comecar(EstadoPartida.Meta - 3, true); });
            Botao("VOLTAR", 435, 550, 230, 40, Voltar);
        }

        private void Comecar(int acertos, bool demonstracao)
        {
            if (carregando) return;
            carregando = true;
            LimparPagina("carga");
            Texto("PREPARANDO A TRILHA...", 100, 358, 500, 50, 27, true);
            Texto("Mire a cabeça do martelo. Cada acerto vale 100 pontos.", 100, 420, 490, 65, 18);
            ProgressBar barra = Colocar(new ProgressBar { Minimum = 0, Maximum = 100 }, 100, 500, 460, 22);
            AudioRetro.Inicio();
            timerCarga = new Timer { Interval = 80 };
            timerCarga.Tick += delegate
            {
                barra.Value = Math.Min(100, barra.Value + 20);
                if (barra.Value < 100) return;
                timerCarga.Stop(); timerCarga.Dispose(); timerCarga = null;
                if (!demonstracao && acertos == 0) ProgressoJogo.SalvarAcertos(0);
                Form2 jogo = new Form2(acertos, demonstracao) { IniciarEmTelaCheia = telaCheia };
                jogo.FormClosed += delegate
                {
                    if (IsDisposed) return;
                    carregando = false;
                    AplicarAudioSalvo();
                    MostrarInicio(); Show(); Activate();
                    AudioRetro.MusicaMenu();
                };
                Hide(); jogo.Show();
            };
            timerCarga.Start();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F11) { AlternarTelaCheia(); return true; }
            if (processandoConta) return true;
            if (carregando) return base.ProcessCmdKey(ref msg, keyData);
            if (keyData == Keys.Escape && pagina != "inicio") { Voltar(); return true; }
            if (keyData == Keys.Enter && acaoEnter != null) { acaoEnter.PerformClick(); return true; }
            if (pagina == "inicio" && opcoesMenu != null && (keyData == Keys.Up || keyData == Keys.Down))
            {
                int indice = Array.FindIndex(opcoesMenu, b => b.Focused);
                opcoesMenu[(indice + (keyData == Keys.Up ? 3 : 1) + 4) % 4].Focus();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void AlternarTelaCheia()
        {
            if (!telaCheia)
            {
                estadoAnterior = WindowState;
                limitesAnteriores = WindowState == FormWindowState.Normal ? Bounds : RestoreBounds;
                bordaAnterior = FormBorderStyle;
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
                Bounds = Screen.FromControl(this).Bounds;
            }
            else { FormBorderStyle = bordaAnterior; Bounds = limitesAnteriores; WindowState = estadoAnterior; }
            telaCheia = !telaCheia;
            AjustarLayout();
        }

        // Eventos mantidos para o arquivo Designer do Visual Studio.
        private void btnStart_Click(object sender, EventArgs e) { Comecar(0, false); }
        private void btnLoadGame_Click(object sender, EventArgs e) { MostrarHistoria(); }
        private void btnPassword_Click(object sender, EventArgs e) { MostrarConta(false); }
        private void btnOptions_Click(object sender, EventArgs e) { MostrarOpcoes(); }
        private void Menu_MouseEnter(object sender, EventArgs e) { }

        private void LiberarRecursosMenu()
        {
            if (recursosLiberados) return;
            recursosLiberados = true;
            if (timerCarga != null) { timerCarga.Stop(); timerCarga.Dispose(); }
            foreach (AreaControle area in areas) if (area.Fonte != null) area.Fonte.Dispose();
            AudioRetro.PararMusica();
        }

        private sealed class AreaControle
        {
            public Control Controle;
            public Rectangle Retangulo;
            public float Tamanho;
            public Font Fonte;
        }
    }
}
