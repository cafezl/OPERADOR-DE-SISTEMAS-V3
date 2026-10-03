using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace preimeiro
{
    public partial class frm_terceira : Form
    {
        public frm_terceira()
        {
            InitializeComponent();
        }

        private void btn_tela1_Click(object sender, EventArgs e)
        {
            frm_primeiro primeiro = new frm_primeiro();// instanciando (criando) um objeto
            primeiro.Show();// chamando a tela renomeada como "primeiro"
            Hide();// fecha a tela anterior 
        }

        private void frm_terceira_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}