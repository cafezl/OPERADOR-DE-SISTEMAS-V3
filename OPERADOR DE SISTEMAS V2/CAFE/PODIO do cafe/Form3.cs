using System;
using System.Windows.Forms;

namespace VOTAÇÕES
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btn_tela1_Click(object sender, EventArgs e)
        {
            // [Deus da Guerra -> CAFE: volta da terceira etapa para a primeira]
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
