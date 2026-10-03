// [Deus da Guerra -> CAFE: tela do primeiro lugar com o troféu do projeto VOTAÇÕES]
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
    public partial class frm_primeiro : Form
    {
        public frm_primeiro()
        {
            InitializeComponent();
        }

        private void btn_tela2_Click(object sender, EventArgs e)
        {
            frm_segundo segundo = new frm_segundo(); // instanciando (criando) um objeto
            segundo.Show();// chamando a tela renomeada como "segundo"
            Hide();// fecha a tela anterior 
        }

        private void frm_primeiro_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frm_primeiro_Load(object sender, EventArgs e)
        {

        }
    }
}