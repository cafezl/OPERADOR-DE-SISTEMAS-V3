using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace sei_la
{
    public partial class Form2 : Form
    {
        // ===== TAMANHO DO MARTELO — MEXE AQUI (64, 96, 128, 160...) =====
        private const int TAMANHO_MARTELO = 196;

        private int nivel = 1;
        private int nivelAlvo = 30;
        private int pontos = 0;
        private Random random = new Random();
        private JanelaMartelo martelo;
        private Timer timerCursor;
        private bool cursorEscondido = false;
        private Button btnMovel;
        private Panel pnlVideo;
        private Label lblVideo;
        private Button btnClose;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Resize += Form2_Resize; // toupeira não foge da tela ao esticar
            IniciarCursorMartelo();
            CriarBotaoToupeira();
            CriarPainelVideo();
            AtualizarLabels();
            EsconderCursor();
        }

        // ---------- SOME COM O CURSOR DO WINDOWS ----------
        private void EsconderCursor()
        {
            if (!cursorEscondido)
            {
                Cursor.Hide();
                cursorEscondido = true;
            }
        }

        private void MostrarCursor()
        {
            if (cursorEscondido)
            {
                Cursor.Show();
                cursorEscondido = false;
            }
        }

        // ---------- CURSOR MARTELO COLORIDO E GIGANTE ----------
        private void IniciarCursorMartelo()
        {
            martelo = new JanelaMartelo(CriarMarteloColorido(TAMANHO_MARTELO));
            martelo.Show(this);

            timerCursor = new Timer();
            timerCursor.Interval = 15;
            timerCursor.Tick += TimerCursor_Tick;
            timerCursor.Start();

            this.Activated += (s, e) => { martelo.Visible = true; EsconderCursor(); };
            this.Deactivate += (s, e) => { martelo.Visible = false; MostrarCursor(); };
        }

        private void TimerCursor_Tick(object sender, EventArgs e)
        {
            Point p = Cursor.Position;
            martelo.Location = new Point(p.X - TAMANHO_MARTELO / 2, p.Y - TAMANHO_MARTELO / 2);
            martelo.Visible = this.RectangleToScreen(this.ClientRectangle).Contains(p);
        }

        // Desenha um martelo colorido (cabeça cinza + cabo marrom)
        private Image CriarMarteloColorido(int tam)
        {
            Bitmap bmp = new Bitmap(tam, tam);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Fuchsia);

                g.TranslateTransform(tam / 2f, tam / 2f);
                g.RotateTransform(-45f);

                using (Pen cabo = new Pen(Color.FromArgb(139, 69, 19), tam * 0.12f))
                {
                    cabo.StartCap = LineCap.Round;
                    cabo.EndCap = LineCap.Round;
                    g.DrawLine(cabo, 0, -tam * 0.05f, 0, tam * 0.42f);
                }

                RectangleF cabeca = new RectangleF(-tam * 0.30f, -tam * 0.38f, tam * 0.60f, tam * 0.28f);
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(160, 160, 170)))
                    g.FillRectangle(brush, cabeca);
                using (Pen contorno = new Pen(Color.DarkSlateGray, tam * 0.03f))
                    g.DrawRectangle(contorno, cabeca.X, cabeca.Y, cabeca.Width, cabeca.Height);

                using (Pen brilho = new Pen(Color.WhiteSmoke, tam * 0.04f))
                    g.DrawLine(brilho, cabeca.X + tam * 0.05f, cabeca.Y + tam * 0.06f,
                                       cabeca.X + cabeca.Width - tam * 0.05f, cabeca.Y + tam * 0.06f);
            }
            return bmp;
        }

        // ---------- TIRA O FUNDO BRANCO DA FOTO DA TOUPEIRA ----------
        private Image RemoverFundoBranco(Image imagem)
        {
            Bitmap origem = new Bitmap(imagem);
            Bitmap destino = new Bitmap(origem.Width, origem.Height,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            for (int x = 0; x < origem.Width; x++)
            {
                for (int y = 0; y < origem.Height; y++)
                {
                    Color c = origem.GetPixel(x, y);
                    if (c.R > 235 && c.G > 235 && c.B > 235)
                        destino.SetPixel(x, y, Color.Transparent); // branco vira transparente
                    else
                        destino.SetPixel(x, y, c);
                }
            }
            return destino;
        }

        // ---------- BOTÃO COM A FOTO DA TOUPEIRA (sem caixa branca) ----------
        private void CriarBotaoToupeira()
        {
            btnMovel = new Button();
            btnMovel.Size = new Size(110, 110);
            btnMovel.BackgroundImage = RemoverFundoBranco(global::sei_la.Properties.Resources.topeira);
            btnMovel.BackgroundImageLayout = ImageLayout.Stretch;
            btnMovel.BackColor = Color.Transparent;
            btnMovel.FlatStyle = FlatStyle.Flat;
            btnMovel.FlatAppearance.BorderSize = 0;
            btnMovel.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnMovel.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnMovel.Text = "";
            btnMovel.Click += BtnMovel_Click;
            this.Controls.Add(btnMovel);
            btnMovel.BringToFront();
            MoverBotaoAleatorio();
        }

        private void BtnMovel_Click(object sender, EventArgs e)
        {
            nivel++;
            pontos += 100;

            if (nivel >= nivelAlvo)
            {
                MostrarVideo();
            }
            else
            {
                MoverBotaoAleatorio();
            }
            AtualizarLabels();
        }

        private void MoverBotaoAleatorio()
        {
            int maxX = this.ClientSize.Width - btnMovel.Width - 20;
            int maxY = this.ClientSize.Height - btnMovel.Height - 20;
            btnMovel.Location = new Point(random.Next(20, maxX), random.Next(140, maxY));
        }

        // ---------- Mantém a toupeira na tela quando estica/maximiza ----------
        private void Form2_Resize(object sender, EventArgs e)
        {
            if (btnMovel == null) return;

            int maxX = this.ClientSize.Width - btnMovel.Width - 20;
            int maxY = this.ClientSize.Height - btnMovel.Height - 20;
            if (maxX <= 20 || maxY <= 140) return;

            int x = Math.Min(Math.Max(btnMovel.Left, 20), maxX);
            int y = Math.Min(Math.Max(btnMovel.Top, 140), maxY);
            btnMovel.Location = new Point(x, y);
        }

        // ---------- PAINEL DO VÍDEO ----------
        private void CriarPainelVideo()
        {
            pnlVideo = new Panel();
            pnlVideo.BackColor = Color.Black;
            pnlVideo.Size = new Size(450, 200);
            pnlVideo.Location = new Point(175, 200);
            pnlVideo.Visible = false;

            lblVideo = new Label();
            lblVideo.ForeColor = Color.White;
            lblVideo.Font = new Font("Microsoft Sans Serif", 14F);
            lblVideo.Text = "🎬 VÍDEO DE RECOMPENSA 🎬\n(Aqui vai seu vídeo)";
            lblVideo.TextAlign = ContentAlignment.MiddleCenter;
            lblVideo.Size = new Size(350, 50);
            lblVideo.Location = new Point(50, 50);

            btnClose = new Button();
            btnClose.Text = "Fechar e Reiniciar";
            btnClose.Size = new Size(120, 30);
            btnClose.Location = new Point(165, 130);
            btnClose.Click += BtnClose_Click;

            pnlVideo.Controls.Add(lblVideo);
            pnlVideo.Controls.Add(btnClose);
            this.Controls.Add(pnlVideo);
            pnlVideo.BringToFront();
        }

        private void MostrarVideo()
        {
            btnMovel.Visible = false;
            lblInstrucao.Text = "🏆 PARABÉNS! Você pegou todas as toupeiras!";
            pnlVideo.Visible = true;
            pnlVideo.BringToFront();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            pnlVideo.Visible = false;
            nivel = 1;
            pontos = 0;
            lblInstrucao.Text = "🔨 MARTELE AS TOUPEIRAS! 🔨";
            btnMovel.Visible = true;
            MoverBotaoAleatorio();
            AtualizarLabels();
        }

        // ---------- LABELS ----------
        private void AtualizarLabels()
        {
            lblNivel.Text = "Nível: " + Math.Min(nivel, nivelAlvo) + " / " + nivelAlvo;
            lblPontos.Text = "Pontos: " + pontos;
            lblRestantes.Text = "Toupeiras restantes: " + Math.Max(nivelAlvo - nivel, 0);
        }

        // ---------- CLIQUES DAS LABELS (criados pelo designer) ----------
        private void lblNivel_Click(object sender, EventArgs e) { }
        private void lblPontos_Click(object sender, EventArgs e) { }
        private void lblRestantes_Click(object sender, EventArgs e) { }
        private void lblInstrucao_Click(object sender, EventArgs e) { }

        // ---------- LIMPEZA AO FECHAR ----------
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timerCursor != null) timerCursor.Stop();
            MostrarCursor();
            if (martelo != null)
            {
                martelo.Close();
                martelo.Dispose();
            }
        }
    }

    // ===== Janelinha transparente que segue o mouse e NÃO bloqueia os cliques =====
    public class JanelaMartelo : Form
    {
        public JanelaMartelo(Image imagem)
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            ShowInTaskbar = false;
            TopMost = true;
            BackColor = Color.Fuchsia;
            TransparencyKey = Color.Fuchsia;
            BackgroundImage = imagem;
            ClientSize = imagem.Size;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0084) // WM_NCHITTEST → deixa o clique passar pra toupeira
            {
                m.Result = new IntPtr(-1); // HTTRANSPARENT
                return;
            }
            base.WndProc(ref m);
        }
    }
}