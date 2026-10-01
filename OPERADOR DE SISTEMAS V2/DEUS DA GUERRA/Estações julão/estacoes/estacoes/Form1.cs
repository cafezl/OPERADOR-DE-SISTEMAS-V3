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
            pictureBox1.BackgroundImage = Properties.Resources.imagem2; // essa bomba aqui muda a imagem de algum picturebox

        }

        private void rad_verao_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.imagem4;//essa tambem
        }

        private void rad_outono_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.imagem1;//essa tambem

        }

        private void rad_inverno_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.imagem3;//essa tambem
        }
    }
}
