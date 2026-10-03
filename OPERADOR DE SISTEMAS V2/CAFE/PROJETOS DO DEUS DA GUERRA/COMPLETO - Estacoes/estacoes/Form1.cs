// [Deus da Guerra -> CAFE: projeto de estações com fotos sazonais do CAFE]
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estacoes
{
    public partial class frm_Estacoes : Form
    {
        public frm_Estacoes()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gpr_estacoes_Enter(object sender, EventArgs e)
        {

        }

        private void rad_primavera_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_primavera.Checked)
            {
                pictureBox1.BackgroundImage = Properties.Resources.imagem2;
            }
        }

        private void rad_verao_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_verao.Checked)
            {
                pictureBox1.BackgroundImage = Properties.Resources.imagem4;
            }
        }

        private void rad_outono_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_outono.Checked)
            {
                pictureBox1.BackgroundImage = Properties.Resources.imagem1;
            }
        }

        private void rad_inverno_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_inverno.Checked)
            {
                pictureBox1.BackgroundImage = Properties.Resources.imagem3;
            }
        }
    }
}
