using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace validação
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Validação do NOME (textBox1): Permite apenas letras e espaços, e avança com Enter
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("SÓ PERMITE LETRAS", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (e.KeyChar == (char)13) // Tecla Enter
            {
                if (textBox1.Text.Trim() != "")
                {
                    textBox2.Focus();
                }
                else
                {
                    MessageBox.Show("O NOME NÃO FOI DIGITADO...", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Validação da IDADE (textBox2): Permite apenas números, e avança com Enter
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("SÓ PERMITE NÚMEROS", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (e.KeyChar == (char)13) // Tecla Enter
            {
                if (textBox2.Text.Trim() != "")
                {
                    textBox3.Focus();
                }
                else
                {
                    MessageBox.Show("A IDADE NÃO FOI DIGITADA...", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Validação do CPF (textBox3): Avança com Enter
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Tecla Enter
            {
                if (textBox3.Text.Trim() != "")
                {
                    BTN_enviar.Focus();
                }
                else
                {
                    MessageBox.Show("O CPF NÃO FOI DIGITADO...", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        // Ação do Botão ENVIAR: Verifica se todos os campos estão preenchidos
        private void BTN_enviar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("PREENCHA TODOS OS CAMPOS!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("DADOS ENVIADOS COM SUCESSO!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}