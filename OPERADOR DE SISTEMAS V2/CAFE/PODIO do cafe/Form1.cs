using System;
using System.Windows.Forms;

namespace VOTAÇÕES
{
    public partial class frm_Primeiro : Form
    {
        public frm_Primeiro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // [Deus da Guerra -> CAFE: abre a segunda etapa do fluxo de três telas]
            Form2 segundaTela = new Form2();
            segundaTela.Show();
            this.Hide();
        }

        private void frm_Primeiro_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
