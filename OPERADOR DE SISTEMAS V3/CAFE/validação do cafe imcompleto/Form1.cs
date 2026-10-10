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

        // Validação do CPF (textBox3): Permite apenas números e formata automaticamente
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas números e teclas de controle (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("SÓ PERMITE NÚMEROS", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (e.KeyChar == (char)13) // Tecla Enter
            {
                // O CPF formatado tem exatamente 14 caracteres (XXX.XXX.XXX-XX)
                if (textBox3.Text.Length == 14)
                {
                    BTN_enviar.Focus();
                }
                else
                {
                    MessageBox.Show("O CPF DEVE ESTAR COMPLETO (14 CARACTERES)!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Formatação automática do CPF em tempo real (TextChange)
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Evita loop infinito ao alterar o texto programaticamente
            textBox3.TextChanged -= textBox3_TextChanged;

            // Remove tudo o que não for número
            string soNumeros = new string(textBox3.Text.Where(char.IsDigit).ToArray());

            // Limita a 11 dígitos numéricos
            if (soNumeros.Length > 11)
            {
                soNumeros = soNumeros.Substring(0, 11);
            }

            // Aplica a máscara de acordo com a quantidade de números digitados
            string cpfFormatado = "";
            if (soNumeros.Length > 0)
            {
                cpfFormatado = soNumeros.Substring(0, Math.Min(3, soNumeros.Length));
            }
            if (soNumeros.Length >= 4)
            {
                cpfFormatado += "." + soNumeros.Substring(3, Math.Min(3, soNumeros.Length - 3));
            }
            if (soNumeros.Length >= 7)
            {
                cpfFormatado += "." + soNumeros.Substring(6, Math.Min(3, soNumeros.Length - 6));
            }
            if (soNumeros.Length >= 10)
            {
                cpfFormatado += "-" + soNumeros.Substring(9, Math.Min(2, soNumeros.Length - 9));
            }

            // Atualiza o texto na TextBox e mantém o cursor no final
            textBox3.Text = cpfFormatado;
            textBox3.SelectionStart = textBox3.Text.Length;

            // Reativa o evento
            textBox3.TextChanged += textBox3_TextChanged;
        }

        // Evento para mascarar com asteriscos quando o usuário sai do campo do CPF (Opcional)
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 14)
            {
                // Se quiser ocultar tudo com asteriscos ao sair do campo:
                textBox3.Text = "***.***.***-**";
            }
        }

        // Ação do Botão ENVIAR: Verifica se todos os campos estão preenchidos
        private void BTN_enviar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) || textBox3.Text.Length < 14)
            {
                MessageBox.Show("PREENCHA TODOS OS CAMPOS CORRETAMENTE!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            // Vincula o evento Leave do textBox3 via código para garantir o funcionamento dos asteriscos
            this.textBox3.Leave += new System.EventHandler(this.textBox3_Leave);
        }
    }
}