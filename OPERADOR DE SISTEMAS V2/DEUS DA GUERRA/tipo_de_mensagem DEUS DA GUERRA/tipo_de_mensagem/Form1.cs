using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tipo_de_mensagem
{
    public partial class frm_tiposdemensagens : Form
    {
        public frm_tiposdemensagens()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult retorno = MessageBox.Show("VAMOS ESTUDAR C# ?", "SOU O TITULO DA MENSAGEM", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                MessageBox.Show("CLICOU EM SIM");
            }
            else if (retorno == DialogResult.No)
            {
                MessageBox.Show("CLICOU EM NÃO"); // BOTÃO 1: Alerta de Sim ou Não
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("OUVIU O SOM DO WINDOWS ?", "SOU UM ALERTA CRÍTICO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            // BOTÃO 2: Alerta Crítico
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("MENSAGEM SIMPLES APENAS COM TEXTO");
            // BOTÃO 3: Alerta Simples 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MENSAGEM COM TEXTO", "ESSE É O TITULO DA MENSAGEM");
            // BOTÃO 4: Alerta Simples com Título
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult retorno = MessageBox.Show("OLA SOU O ELIÉZIO PROF: DE C# DA DOM BOSCO", "EU TENHO UM ÍCONE", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (retorno == DialogResult.Yes)
            {
                MessageBox.Show("CLICOU EM SIM");
            }
            else if (retorno == DialogResult.No)
            {
                MessageBox.Show("CLICOU EM NÃO");
            }
            else if (retorno == DialogResult.Cancel)
            {
                MessageBox.Show("CLICOU EM CANCELAR");
                // BOTÃO 5: Alerta com Sim, Não ou Cancelar
            }
        }
    }
}
