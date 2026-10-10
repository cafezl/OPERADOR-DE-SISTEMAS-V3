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

        // --- BOTÃO 1: Alerta de Sim ou Não ---
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult retorno = MessageBox.Show("VAMOS ESTUDAR C# ?", "SOU O TITULO DA MENSAGEM", MessageBoxButtons.YesNo);

            if (retorno == DialogResult.Yes)
            {
                MessageBox.Show("CLICOU EM SIM");
            }
            else if (retorno == DialogResult.No)
            {
                MessageBox.Show("CLICOU EM NÃO");
            }
        }

        // --- BOTÃO 2: Alerta Crítico (Com som e ícone de Warning/Aviso) ---
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OUVIU O SOM DO WINDOWS ?", "SOU UM ALERTA CRÍTICO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // --- BOTÃO 3: Alerta Simples (Apenas texto) ---
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MENSAGEM SIMPLES APENAS COM TEXTO");
        }

        // --- BOTÃO 4: Alerta Simples com Título ---
        private void button4_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("MENSAGEM COM TEXTO", "ESSE É O TITULO DA MENSAGEM");
        }

        // --- BOTÃO 5: Alerta com Sim, Não ou Cancelar ---
        private void button5_Click_1(object sender, EventArgs e)
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
            }
        }
    }
}
