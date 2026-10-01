using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace framewoek
{
    public partial class frm_Mundo: Form
    {
        public frm_Mundo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Óla mundo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit(); // Esse aqui fecha o software
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
