using System;
using System.Drawing;
using System.Windows.Forms;

namespace sei_la
{
    public partial class Form1 : Form
    {
        private Image gifMenu;
        private bool animandoMenu = false;
        private Button botaoSetaAtual; // guarda qual botão a seta está em cima

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // evita flicker na animação
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Resize += Form1_Resize; // registra o evento de redimensionar
            MoverSeta(btnStart); // setinha começa no START, igual ao Crash
            IniciarGifAnimado();
        }

        // ---------- ANIMA O GIF DO FUNDO (FUNDO.gif) ----------
        private void IniciarGifAnimado()
        {
            gifMenu = Properties.Resources.FUNDO_gif;

            if (gifMenu != null && ImageAnimator.CanAnimate(gifMenu))
            {
                ImageAnimator.Animate(gifMenu, OnFrameChanged);
                animandoMenu = true;
            }
        }

        private void OnFrameChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.IsHandleCreated && !this.IsDisposed && !this.Disposing)
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        this.Invalidate(true);
                    });
                }
            }
            catch
            {
            }
        }

        // Desenha o frame atual do GIF no fundo (estica junto com a janela)
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (animandoMenu && gifMenu != null)
            {
                ImageAnimator.UpdateFrames(gifMenu);
                e.Graphics.DrawImage(gifMenu, this.ClientRectangle);
            }
            else
            {
                base.OnPaintBackground(e);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (animandoMenu && gifMenu != null)
            {
                ImageAnimator.StopAnimate(gifMenu, OnFrameChanged);
            }
            base.OnFormClosing(e);
        }

        // ---------- REPOSICIONA A SETA QUANDO ESTICA A TELA ----------
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (botaoSetaAtual != null)
                MoverSeta(botaoSetaAtual);
        }

        // Move a setinha verde ▶ pro botão que o mouse está em cima
        private void MoverSeta(Button botao)
        {
            botaoSetaAtual = botao; // salva o botão atual
            lblSeta.Location = new Point(botao.Left - 35, botao.Top + 5);
            lblSeta.BringToFront();
        }

        private void Menu_MouseEnter(object sender, EventArgs e)
        {
            MoverSeta((Button)sender);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Form2 jogo = new Form2();
            this.Hide();
            jogo.FormClosed += (s, args) => this.Show();
            jogo.Show();
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nenhum jogo salvo encontrado!\nComece um novo jogo no START.",
                "Load Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("🔑 Password secreta: TOUPEIRA30",
                "Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("🔨 Cursor: Martelo do Thor\n🦫 Toupeiras: 30\n🎬 Vídeo de recompensa no final",
                "Options", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblSeta_Click(object sender, EventArgs e)
        {
        }
    }
}