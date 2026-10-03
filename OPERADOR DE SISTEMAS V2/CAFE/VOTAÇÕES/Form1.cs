using System;
using System.Windows.Forms;

namespace VOTAÇÕES
{
    public partial class frm_Primeiro : Form
    {
        public frm_Primeiro()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(frm_Primeiro_FormClosed);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Altere para button1_Click
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 segundaTela = new Form2();
            segundaTela.Show();
            this.Hide();
        }

        private void frm_Primeiro_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Frm_primeiro_formClosed(object sender, EventArgs e)
        {

        }

        private void frm_Primeiro_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frm_Primeiro_FormClosed_1(object sender, FormClosedEventArgs e)
        {

        }
    }
}