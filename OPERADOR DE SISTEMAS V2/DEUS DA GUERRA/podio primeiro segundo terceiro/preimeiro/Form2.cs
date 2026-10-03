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
    public partial class frm_segundo : Form
    {
        public frm_segundo()
        {
            InitializeComponent();
        }

        private void btn_tela3_Click(object sender, EventArgs e)
        {
            frm_terceira terceira = new frm_terceira(); // instanciando (criando) um objeto
            terceira.Show();// chamando a tela renomeada como "terceira"
            Hide();// fecha a tela anterior 
        }

        private void frm_segundo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}