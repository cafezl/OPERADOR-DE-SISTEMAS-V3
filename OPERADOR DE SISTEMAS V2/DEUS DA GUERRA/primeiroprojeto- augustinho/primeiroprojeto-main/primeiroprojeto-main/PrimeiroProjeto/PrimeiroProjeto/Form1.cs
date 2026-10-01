using MySql.Data.MySqlClient;
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
    public partial class Form1 : Form
    {
        public static string NomeCadastrado = "";
        public static string EmailCadastrado = "";
        public static string SenhaCadastrada = "";

        public Form1()
        {
            InitializeComponent();

            this.Resize += (s, e) => CentralizarPainel();
        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void pnlEntrar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CentralizarPainel()
        {
            pnlEntrar.Left = (this.ClientSize.Width - pnlEntrar.Width) / 2;
            pnlEntrar.Top = (this.ClientSize.Height - pnlEntrar.Height) / 2;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text;

            // Validação para campos vazios
            if (email == "" || senha == "")
            {
                MessageBox.Show(
                    "Preencha o email e a senha.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Abre a conexão e faz a busca no banco de dados
                using (MySqlConnection conexao = Conexao.Abrir())
                {
                    string sql =
                        "SELECT nome FROM usuarios " +
                        "WHERE email = @email " +
                        "AND senha = @senha";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@email", email);
                    comando.Parameters.AddWithValue("@senha", senha);

                    object resultado = comando.ExecuteScalar();

                    // Verifica se encontrou o usuário
                    if (resultado != null)
                    {
                        frmPrincipal principal = new frmPrincipal();
                        principal.DefinirBoasVindas(resultado.ToString());
                        principal.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Email ou senha incorretos.",
                            "Erro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        txtSenha.Clear();
                        txtSenha.Focus();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erro ao conectar ao banco de dados: " + ex.Message,
                    "Erro Técnico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void lnkCadastrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCadastro cadastro = new frmCadastro();

            this.Hide();
            cadastro.ShowDialog();
            this.Show();
        }
    }
}
