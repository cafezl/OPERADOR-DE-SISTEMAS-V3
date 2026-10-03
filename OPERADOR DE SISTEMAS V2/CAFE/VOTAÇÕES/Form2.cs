using System;
using System.Windows.Forms;

namespace VOTAÇÕES
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form2_FormClosed);

            // CÓDIGO DE SEGURANÇA: Força o "button3" a chamar a função de clique
            Control[] meusBotoes = this.Controls.Find("button3", true);
            if (meusBotoes.Length > 0)
            {
                meusBotoes[0].Click += new EventHandler(button3_Click);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        // Função que faz a transição para a Tela 3
        private void button3_Click(object sender, EventArgs e)
        {
            Form3 terceiraTela = new Form3();
            terceiraTela.Show();
            this.Hide();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_tela3_Click(object sender, EventArgs e)
        {
            Form3 terceiraTela = new Form3();
            terceiraTela.Show();
            this.Hide();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}