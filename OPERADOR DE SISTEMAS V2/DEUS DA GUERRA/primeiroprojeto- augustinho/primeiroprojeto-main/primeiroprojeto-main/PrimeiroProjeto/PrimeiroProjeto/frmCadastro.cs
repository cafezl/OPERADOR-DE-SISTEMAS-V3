using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeiroProjeto
{
    public partial class frmCadastro : Form
    {
        public frmCadastro()
        {
            InitializeComponent();
            txtSenha.UseSystemPasswordChar = true;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show(
                    "Preencha nome, email e senha.",
                    "Dados incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                new MailAddress(email);
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Digite um email válido.",
                    "Email inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            try
            {
                using (MySqlConnection conexao = Conexao.Abrir())
                {
                    string sql =
                        "INSERT INTO usuarios " +
                        "(nome, email, senha) " +
                        "VALUES (@nome, @email, @senha)";

                    using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue("@nome", nome);
                        comando.Parameters.AddWithValue("@email", email);
                        comando.Parameters.AddWithValue("@senha", SenhaHasher.Gerar(senha));
                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Cadastro realizado!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show(
                        "Esse email já está cadastrado.",
                        "Email duplicado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtEmail.Focus();
                }
                else
                {
                    MessageBox.Show(
                        "Não foi possível salvar o cadastro. Confira a conexão e a tabela do banco de dados.\n\nDetalhes: " + ex.Message,
                        "Erro no banco de dados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
