using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeiroProjeto
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        public void DefinirBoasVindas(string nome)
        {
            lblBoasVindas.Text =
            "Bem-vindo, " + nome + "!";
        }


        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resposta =
            MessageBox.Show(
            "Deseja realmente sair?",
               "Confirmacao",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (resposta == DialogResult.No)
            {
                e.Cancel = true;
            }

        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }
    }
}
