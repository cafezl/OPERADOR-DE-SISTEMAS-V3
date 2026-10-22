using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace sei_la
{
    // Esta janela conecta as regras da partida aos controles, ao som e à animação.
    public partial class Form2 : Form
    {
        private readonly EstadoPartida partida;
        private readonly bool modoApresentacao;
        private readonly Random sorteio = new Random();
        private readonly Timer timerImpacto = new Timer();
        private readonly Timer timerMensagem = new Timer();
        private MarteloCursor martelos;
        private PainelCampo campo;
        private AlvoToupeira toupeira;
        private Panel cabecalho, rodape, painelPausa, painelVitoria;
        private Label lblAjuda, lblSituacao, lblResumo;
        private Button btnSom, btnPausa;
        private ProgressBar progresso;
        private CenaVitoria cena;
        private bool pausado, emImpacto, iniciado;
        private int quadroImpacto;
        private bool telaCheia;
        private Rectangle limitesAnteriores;
        private FormWindowState estadoAnterior;
        private FormBorderStyle bordaAnterior;

        public Form2() : this(0, false) { }

        public Form2(int acertosIniciais, bool apresentacao = false)
        {
            partida = new EstadoPartida(acertosIniciais);
            modoApresentacao = apresentacao;
            InitializeComponent();
            // O timer só anima a pancada. Ele não tira tempo de quem está apresentando.
            timerImpacto.Interval = 45;
            timerImpacto.Tick += AnimarImpacto;
            timerMensagem.Interval = 650;
            timerMensagem.Tick += delegate { timerMensagem.Stop(); AtualizarSituacao(); };
            KeyPreview = true;
            KeyDown += TratarAtalhos;
            MinimumSize = new Size(800, 560);
            ClientSize = new Size(1024, 640);
            Text = "Jogo da Toupeira • Café";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ProgressoJogo.Carregar();
            AudioRetro.Ativo = ProgressoJogo.SomAtivo;
            CriarInterface();
            martelos = new MarteloCursor();
            campo.Cursor = martelos.Repouso;
            toupeira.Cursor = martelos.Repouso;
            iniciado = true;
            Resize += delegate { OrganizarTela(); };
            Deactivate += delegate
            {
                // Alt+Tab ou outra janela pausa a partida, mas deixa o ponteiro do Windows normal.
                if (iniciado && !partida.Venceu && !pausado) Pausar();
            };
            OrganizarTela();
            MoverToupeira();
            AtualizarPlacar();
            if (!modoApresentacao) ProgressoJogo.SalvarAcertos(partida.Acertos);
        }

        private void CriarInterface()
        {
            SuspendLayout();
            BackgroundImage = null;
            BackColor = Color.FromArgb(16, 29, 25);
            cabecalho = new Panel { BackColor = Color.FromArgb(17, 30, 29) };
            rodape = new Panel { BackColor = Color.FromArgb(17, 30, 29) };
            campo = new PainelCampo
            {
                BackgroundImage = Properties.Resources.textura_de_grama,
                BackgroundImageLayout = ImageLayout.Tile,
                TabStop = true
            };
            // Reaproveitamos as labels do Designer; os dados agora vêm do mesmo estado.
            cabecalho.Controls.AddRange(new Control[] { lblNivel, lblPontos, lblRestantes, lblInstrucao });
            foreach (Control item in cabecalho.Controls) item.BackColor = Color.Transparent;
            lblNivel.Font = new Font("Arial", 17, FontStyle.Bold);
            lblPontos.Font = new Font("Arial", 17, FontStyle.Bold);
            lblRestantes.Font = new Font("Arial", 11, FontStyle.Bold);
            lblInstrucao.Font = new Font("Arial", 10, FontStyle.Bold);
            lblInstrucao.ForeColor = Color.FromArgb(173, 218, 188);
            lblInstrucao.Text = modoApresentacao ? "DEMONSTRAÇÃO • faltam 3 acertos para a vitória" : "ILHA DO CAFÉ • 30 acertos para conquistar o troféu";
            btnPausa = CriarBotao("PAUSAR", delegate { Pausar(); });
            btnSom = CriarBotao("", delegate { AlternarSom(); });
            cabecalho.Controls.AddRange(new Control[] { btnPausa, btnSom });
            progresso = new ProgressBar { Minimum = 0, Maximum = EstadoPartida.Meta, Height = 8, TabStop = false };
            lblAjuda = new Label
            {
                AutoSize = false, ForeColor = Color.WhiteSmoke,
                Font = new Font("Arial", 10), TextAlign = ContentAlignment.MiddleLeft,
                Text = "Clique na toupeira • Esc: pausa • M: som • F11: tela cheia"
            };
            lblSituacao = new Label
            {
                AutoSize = false, ForeColor = Color.FromArgb(255, 210, 92),
                Font = new Font("Arial", 10, FontStyle.Bold), TextAlign = ContentAlignment.MiddleRight
            };
            rodape.Controls.AddRange(new Control[] { lblAjuda, lblSituacao });
            toupeira = new AlvoToupeira { Size = new Size(116, 116), TabStop = false, AccessibleName = "Toupeira" };
            toupeira.Click += AcertarToupeira;
            campo.MouseDown += delegate
            {
                // Errar não perde pontos: o feedback orienta sem atrapalhar a demonstração.
                if (!pausado && !partida.Venceu)
                {
                    lblSituacao.Text = "Mire a cabeça do martelo na toupeira!";
                    timerMensagem.Start();
                }
            };
            campo.Controls.Add(toupeira);
            CriarPausa();
            CriarVitoria();
            Controls.AddRange(new Control[] { campo, cabecalho, progresso, rodape, painelPausa, painelVitoria });
            ResumeLayout(false);
        }

        // Botões comuns usam o cursor normal, para o martelo ficar só na área de jogo.
        private static Button CriarBotao(string texto, EventHandler acao)
        {
            Button botao = new Button
            {
                Text = texto, FlatStyle = FlatStyle.Flat, ForeColor = Color.White,
                BackColor = Color.FromArgb(38, 77, 57), Cursor = Cursors.Hand,
                Font = new Font("Arial", 10, FontStyle.Bold), Size = new Size(148, 38)
            };
            botao.FlatAppearance.BorderColor = Color.FromArgb(112, 155, 100);
            botao.Click += acao;
            return botao;
        }

        private void CriarPausa()
        {
            painelPausa = new Panel { Visible = false, BackColor = Color.FromArgb(19, 30, 35), Size = new Size(440, 226) };
            Label titulo = new Label
            {
                Text = "PAUSA", ForeColor = Color.Gold, Font = new Font("Arial", 26, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter, Bounds = new Rectangle(20, 18, 400, 48)
            };
            Label descricao = new Label
            {
                Text = modoApresentacao ? "Modo de apresentação • o progresso não é salvo." : "Seu progresso é salvo a cada acerto.",
                ForeColor = Color.WhiteSmoke, TextAlign = ContentAlignment.MiddleCenter,
                Bounds = new Rectangle(20, 78, 400, 45)
            };
            Button retomar = CriarBotao("CONTINUAR", delegate { Retomar(); });
            Button menu = CriarBotao("VOLTAR AO MENU", delegate { Close(); });
            retomar.Location = new Point(50, 158);
            menu.Location = new Point(242, 158);
            painelPausa.Controls.AddRange(new Control[] { titulo, descricao, retomar, menu });
        }

        private void CriarVitoria()
        {
            painelVitoria = new Panel { Visible = false, BackColor = Color.FromArgb(10, 18, 36) };
            cena = new CenaVitoria { Dock = DockStyle.Fill };
            Panel acoes = new Panel { Dock = DockStyle.Bottom, Height = 100, BackColor = Color.FromArgb(10, 18, 36) };
            lblResumo = new Label
            {
                Dock = DockStyle.Top, Height = 35, ForeColor = Color.Gold,
                TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Arial", 12, FontStyle.Bold)
            };
            FlowLayoutPanel botoes = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom, Height = 58, FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false, Padding = new Padding(10)
            };
            botoes.Controls.Add(CriarBotao("JOGAR DE NOVO", delegate { Reiniciar(); }));
            botoes.Controls.Add(CriarBotao("ABRIR VÍDEO", delegate { AbrirVideo(); }));
            botoes.Controls.Add(CriarBotao("VOLTAR AO MENU", delegate { Close(); }));
            acoes.Controls.Add(lblResumo);
            acoes.Controls.Add(botoes);
            acoes.Resize += delegate { botoes.Padding = new Padding(Math.Max(10, (acoes.Width - 462) / 2), 7, 0, 0); };
            painelVitoria.Controls.Add(cena);
            painelVitoria.Controls.Add(acoes);
        }

        private void AbrirVideo()
        {
            // A mesma cena também acompanha o projeto como MP4 para mostrar fora do jogo.
            string caminho = Path.Combine(Application.StartupPath, "midia", "vitoria-retro.mp4");
            if (!File.Exists(caminho))
            {
                MessageBox.Show(this, "O vídeo fica na pasta midia. Compile novamente a solução para copiá-lo.",
                    "Vídeo da vitória", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                AudioRetro.Parar();
                Process.Start(new ProcessStartInfo(caminho) { UseShellExecute = true });
            }
            catch (Win32Exception)
            {
                MessageBox.Show(this, "Não foi possível abrir o player de vídeo deste computador. A animação continua disponível no jogo.",
                    "Vídeo da vitória", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OrganizarTela()
        {
            if (!iniciado) return;
            // Todas as posições dependem da área útil, inclusive em um projetor menor.
            int w = ClientSize.Width, h = ClientSize.Height;
            cabecalho.SetBounds(0, 0, w, 105);
            progresso.SetBounds(0, 105, w, 8);
            rodape.SetBounds(0, h - 44, w, 44);
            campo.SetBounds(0, 113, w, Math.Max(130, h - 157));
            lblNivel.Location = new Point(20, 14);
            lblPontos.Location = new Point(240, 14);
            lblRestantes.Location = new Point(20, 48);
            lblInstrucao.Location = new Point(20, 78);
            btnPausa.SetBounds(w - 130, 15, 110, 34);
            btnSom.SetBounds(w - 250, 15, 110, 34);
            lblAjuda.SetBounds(14, 0, Math.Max(475, w - 280), 44);
            lblSituacao.SetBounds(w - 260, 0, 246, 44);
            painelPausa.Location = new Point((w - painelPausa.Width) / 2, Math.Max(120, (h - painelPausa.Height) / 2));
            painelVitoria.Bounds = ClientRectangle;
            LimitarToupeira();
        }

        private void AcertarToupeira(object sender, EventArgs e)
        {
            // Este bloqueio impede que um clique duplo conte a mesma toupeira duas vezes.
            if (pausado || emImpacto || partida.Venceu || !partida.Acertar()) return;
            emImpacto = true;
            quadroImpacto = 0;
            toupeira.Atingida = true;
            AudioRetro.Acerto();
            if (!modoApresentacao && !partida.Venceu) ProgressoJogo.SalvarAcertos(partida.Acertos);
            AtualizarPlacar();
            timerImpacto.Start();
        }

        private void AnimarImpacto(object sender, EventArgs e)
        {
            quadroImpacto++;
            // O desenho gira em torno da mão na ponta do cabo, e não no centro.
            campo.Cursor = toupeira.Cursor = martelos.Quadro(quadroImpacto);
            if (quadroImpacto < 4) return;
            timerImpacto.Stop();
            campo.Cursor = toupeira.Cursor = martelos.Repouso;
            emImpacto = false;
            toupeira.Atingida = false;
            if (partida.Venceu) MostrarVitoria();
            else MoverToupeira();
        }

        private void MoverToupeira()
        {
            // Random.Next recebe sempre uma faixa válida, mesmo com janela pequena.
            int maxX = Math.Max(12, campo.ClientSize.Width - toupeira.Width - 12);
            int maxY = Math.Max(12, campo.ClientSize.Height - toupeira.Height - 12);
            Point anterior = toupeira.Location;
            Point nova = anterior;
            for (int tentativa = 0; tentativa < 8; tentativa++)
            {
                nova = new Point(sorteio.Next(12, maxX + 1), sorteio.Next(12, maxY + 1));
                if (Math.Abs(nova.X - anterior.X) + Math.Abs(nova.Y - anterior.Y) >= 140) break;
            }
            toupeira.Location = nova;
        }

        private void LimitarToupeira()
        {
            toupeira.Location = new Point(
                Math.Max(0, Math.Min(toupeira.Left, campo.ClientSize.Width - toupeira.Width)),
                Math.Max(0, Math.Min(toupeira.Top, campo.ClientSize.Height - toupeira.Height)));
        }

        private void AtualizarPlacar()
        {
            lblNivel.Text = "Acertos: " + partida.Acertos + " / " + EstadoPartida.Meta;
            lblPontos.Text = "Pontos: " + partida.Pontos;
            lblRestantes.Text = "Toupeiras restantes: " + partida.Restantes;
            progresso.Value = partida.Acertos;
            btnSom.Text = AudioRetro.Ativo ? "SOM: ON" : "SOM: OFF";
            AtualizarSituacao();
        }

        private void AtualizarSituacao()
        {
            if (modoApresentacao) lblSituacao.Text = "MODO APRESENTAÇÃO";
            else if (!String.IsNullOrEmpty(ProgressoJogo.UltimoErro)) lblSituacao.Text = "Não foi possível salvar";
            else lblSituacao.Text = "Recorde: " + ProgressoJogo.Recorde;
        }

        private void MostrarVitoria()
        {
            // 30 acertos = 3000 pontos. A vitória limpa o save somente no modo normal.
            if (!modoApresentacao) ProgressoJogo.RegistrarVitoria(partida.Pontos);
            toupeira.Visible = false;
            campo.Enabled = false;
            lblResumo.Text = "30 / 30 TOUPEIRAS • " + partida.Pontos + " PONTOS"
                + (modoApresentacao ? " • DEMONSTRAÇÃO" : "");
            painelVitoria.Visible = true;
            painelVitoria.BringToFront();
            cena.Iniciar();
            AudioRetro.Vitoria();
            painelVitoria.Controls[1].Focus();
        }

        private void Reiniciar()
        {
            AudioRetro.Parar();
            cena.Parar();
            painelVitoria.Visible = false;
            partida.Reiniciar();
            if (!modoApresentacao) ProgressoJogo.SalvarAcertos(0);
            campo.Enabled = true;
            toupeira.Visible = true;
            lblInstrucao.Text = modoApresentacao ? "DEMONSTRAÇÃO • nova rodada de 30 toupeiras" : "ILHA DO CAFÉ • 30 acertos para conquistar o troféu";
            AtualizarPlacar();
            MoverToupeira();
            campo.Focus();
        }

        private void Pausar()
        {
            if (pausado || partida.Venceu) return;
            pausado = true;
            timerImpacto.Stop();
            campo.Enabled = false;
            campo.Cursor = toupeira.Cursor = martelos.Repouso;
            painelPausa.Visible = true;
            painelPausa.BringToFront();
            painelPausa.Controls[2].Focus();
        }

        private void Retomar()
        {
            pausado = false;
            painelPausa.Visible = false;
            campo.Enabled = true;
            // Se a pausa aconteceu no meio de uma pancada, conclui a mesma animação.
            if (emImpacto) timerImpacto.Start();
            campo.Focus();
        }

        private void AlternarSom()
        {
            AudioRetro.Ativo = !AudioRetro.Ativo;
            ProgressoJogo.SalvarOpcoes(AudioRetro.Ativo);
            if (AudioRetro.Ativo) AudioRetro.Menu();
            else AudioRetro.Parar();
            AtualizarPlacar();
        }

        private void TratarAtalhos(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (partida.Venceu) Close();
                else if (pausado) Retomar();
                else Pausar();
            }
            else if (e.KeyCode == Keys.M) AlternarSom();
            else if (e.KeyCode == Keys.F11) AlternarTelaCheia();
            else if (e.KeyCode == Keys.R && partida.Venceu) Reiniciar();
            else return;
            e.Handled = true;
            e.SuppressKeyPress = true;
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
            else
            {
                FormBorderStyle = bordaAnterior;
                Bounds = limitesAnteriores;
                WindowState = estadoAnterior;
            }
            telaCheia = !telaCheia;
        }

        // Eventos antigos continuam declarados para o Designer do Visual Studio.
        private void lblNivel_Click(object sender, EventArgs e) { }
        private void lblPontos_Click(object sender, EventArgs e) { }
        private void lblRestantes_Click(object sender, EventArgs e) { }
        private void lblInstrucao_Click(object sender, EventArgs e) { }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            iniciado = false;
            timerImpacto.Stop();
            timerMensagem.Stop();
            if (cena != null) cena.Parar();
            AudioRetro.Parar();
            // Salva também se o usuário fechar nos 180 ms entre o último acerto e a vitória.
            if (!modoApresentacao)
            {
                if (partida.Venceu) ProgressoJogo.RegistrarVitoria(partida.Pontos);
                else ProgressoJogo.SalvarAcertos(partida.Acertos);
            }
        }

        // O Designer chama isto no Dispose: cada recurso nativo tem um dono e é liberado.
        private void LiberarRecursos()
        {
            timerImpacto.Dispose();
            timerMensagem.Dispose();
            if (campo != null) campo.Cursor = Cursors.Default;
            if (toupeira != null) toupeira.Cursor = Cursors.Default;
            if (martelos != null) { martelos.Dispose(); martelos = null; }
        }
    }

    // Buffer duplo evita cintilação da grama quando a toupeira muda de posição.
    internal sealed class PainelCampo : Panel
    {
        public PainelCampo()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }
    }

    internal sealed class AlvoToupeira : Control
    {
        private bool atingida;
        public bool Atingida
        {
            get { return atingida; }
            set { atingida = value; Invalidate(); }
        }

        public AlvoToupeira()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            BackColor = Color.Transparent;
            AccessibleRole = AccessibleRole.PushButton;
            // A região elíptica permite clicar no alvo, sem a caixa branca da foto.
            using (GraphicsPath borda = new GraphicsPath())
            {
                borda.AddEllipse(2, 2, 112, 112);
                Region = new Region(borda);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Brush sombra = new SolidBrush(Color.FromArgb(115, 20, 15, 8)))
                e.Graphics.FillEllipse(sombra, 6, 78, 104, 30);
            using (Pen aro = new Pen(Color.FromArgb(235, 177, 71), 3))
                e.Graphics.DrawEllipse(aro, 3, 3, 109, 109);
            // ColorKey só afeta a exibição. O arquivo original da sua toupeira é preservado.
            using (ImageAttributes cores = new ImageAttributes())
            {
                cores.SetColorKey(Color.FromArgb(236, 236, 236), Color.White);
                e.Graphics.DrawImage(Properties.Resources.topeira, new Rectangle(9, 9, 98, 90),
                    0, 0, Properties.Resources.topeira.Width, Properties.Resources.topeira.Height,
                    GraphicsUnit.Pixel, cores);
            }
            if (atingida)
            {
                using (Brush brilho = new SolidBrush(Color.FromArgb(150, 255, 222, 70)))
                    e.Graphics.FillEllipse(brilho, 6, 6, 104, 104);
                using (Font fonte = new Font("Arial", 24, FontStyle.Bold))
                    TextRenderer.DrawText(e.Graphics, "+100", fonte, ClientRectangle,
                        Color.FromArgb(50, 34, 9), TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}
