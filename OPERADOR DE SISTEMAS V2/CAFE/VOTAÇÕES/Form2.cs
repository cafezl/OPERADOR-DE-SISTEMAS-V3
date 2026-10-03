using System;
using System.Windows.Forms;

namespace VOTAÇÕES
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btn_tela3_Click(object sender, EventArgs e)
        {
            // [Deus da Guerra -> CAFE: segue da segunda para a terceira etapa]
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
