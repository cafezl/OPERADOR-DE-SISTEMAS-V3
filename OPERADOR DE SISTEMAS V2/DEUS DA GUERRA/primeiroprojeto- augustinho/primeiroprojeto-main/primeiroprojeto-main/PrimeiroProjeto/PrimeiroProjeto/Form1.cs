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
        public Form1()
        {
            InitializeComponent();
            txtSenha.UseSystemPasswordChar = true;
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
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(senha))
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
                        "SELECT nome, senha FROM usuarios " +
                        "WHERE email = @email";

                    string nome = null;
                    string senhaSalva = null;
                    using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue("@email", email);
                        using (MySqlDataReader leitor = comando.ExecuteReader())
                        {
                            if (leitor.Read())
                            {
                                nome = leitor.GetString(leitor.GetOrdinal("nome"));
                                senhaSalva = leitor.GetString(leitor.GetOrdinal("senha"));
                            }
                        }
                    }

                    // Verifica se encontrou o usuário
                    if (nome != null && SenhaHasher.Verificar(senha, senhaSalva))
                    {
                        if (SenhaHasher.PrecisaMigrar(senhaSalva))
                        {
                            const string atualizarSenha = "UPDATE usuarios SET senha = @senha WHERE email = @email";
                            using (MySqlCommand comandoAtualizacao = new MySqlCommand(atualizarSenha, conexao))
                            {
                                comandoAtualizacao.Parameters.AddWithValue("@senha", SenhaHasher.Gerar(senha));
                                comandoAtualizacao.Parameters.AddWithValue("@email", email);
                                comandoAtualizacao.ExecuteNonQuery();
                            }
                        }

                        frmPrincipal principal = new frmPrincipal();
                        principal.DefinirBoasVindas(nome);
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
                    "Não foi possível acessar o banco de dados. Confira se o MySQL está ligado e se o banco 'primeiroprojeto' foi criado.\n\nDetalhes: " + ex.Message,
                    "Erro no banco de dados",
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
