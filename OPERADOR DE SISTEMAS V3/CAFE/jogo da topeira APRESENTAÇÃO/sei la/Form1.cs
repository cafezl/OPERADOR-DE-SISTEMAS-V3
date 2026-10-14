using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace sei_la
{
    public partial class Form1 : Form
    {
        private int nivel = 1;
        private int nivelAlvo = 30;
        private Random random = new Random();
        private Cursor cursorMartelo;

        public Form1()
        {
            InitializeComponent();
            ConfigurarCursorMartelo();
            ConfigurarBotaoToupeira();
        }

        private void ConfigurarCursorMartelo()
        {
            try
            {
                string caminhoCursor = Path.Combine(Application.StartupPath, "Thor's Hammer.cur");

                if (!File.Exists(caminhoCursor))
                {
                    string pastaProjeto = Directory.GetParent(Application.StartupPath).FullName;
                    caminhoCursor = Path.Combine(pastaProjeto, "Thor's Hammer.cur");
                }

                if (File.Exists(caminhoCursor))
                {
                    cursorMartelo = new Cursor(caminhoCursor);
                    this.Cursor = cursorMartelo;
                    btnMovel.Cursor = cursorMartelo;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    btnMovel.Cursor = Cursors.Default;
                }
            }
            catch
            {
                this.Cursor = Cursors.Default;
                btnMovel.Cursor = Cursors.Default;
            }
        }

        private void ConfigurarBotaoToupeira()
        {
            btnMovel.Text = "";
            btnMovel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            btnMovel.BackgroundImage = global::sei_la.Properties.Resources.Captura_de_tela_2026_10_13_210608;
            btnMovel.BackgroundImageLayout = ImageLayout.Stretch;
            btnMovel.FlatAppearance.BorderSize = 0;
            btnMovel.FlatStyle = FlatStyle.Flat;
        }

        private void btnMovel_Click(object sender, EventArgs e)
        {
            nivel++;
            lblLevel.Text = "Nível: " + nivel + " / " + nivelAlvo;

            if (nivel >= nivelAlvo)
            {
                MostrarVideo();
            }
            else
            {
                lblInfo.Text = "✅ ACERTEI! Faltam " + (nivelAlvo - nivel) + " toupeiras!";
                MoverBotaoAleatorio();
            }
        }

        private void MoverBotaoAleatorio()
        {
            int posX = random.Next(50, 650);
            int posY = random.Next(100, 350);
            btnMovel.Location = new Point(posX, posY);
        }

        private void MostrarVideo()
        {
            btnMovel.Visible = false;
            lblInfo.Text = "🏆 PARABÉNS! Você pegou todas as 30 toupeiras!";
            lblLevel.Text = "🎮 JOGO CONCLUÍDO! 🎮";
            pnlVideo.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlVideo.Visible = false;
            nivel = 1;
            lblLevel.Text = "Nível: 1 / " + nivelAlvo;
            lblInfo.Text = "🔨 MARTELE AS TOPEIRAS PARA LIBERAR O PRÊMIO!";
            btnMovel.Visible = true;
            MoverBotaoAleatorio();
        }
    }
}