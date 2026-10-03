using System;
using System.Windows.Forms;

namespace VOTAÇÕES
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form3_FormClosed);

            // CÓDIGO DE SEGURANÇA: Força o "button1" a chamar a função de clique
            Control[] meusBotoes = this.Controls.Find("button1", true);
            if (meusBotoes.Length > 0)
            {
                meusBotoes[0].Click += new EventHandler(btn_tela1_Click);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_tela1_Click(object sender, EventArgs e)
        {
            // O nome correto da sua primeira tela é frm_Primeiro!
            frm_Primeiro primeiraTela = new frm_Primeiro();
            primeiraTela.Show();
            this.Hide();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}