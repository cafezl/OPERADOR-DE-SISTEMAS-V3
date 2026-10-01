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
    public partial class frmCadastro : Form
    {
        public frmCadastro()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            try
            {
                using (MySqlConnection conexao = Conexao.Abrir())
                {
                    string sql =
                        "INSERT INTO usuarios " +
                        "(nome, email, senha) " +
                        "VALUES (@nome, @email, @senha)";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);

                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@email", email);
                    comando.Parameters.AddWithValue("@senha", senha);

                    comando.ExecuteNonQuery();
                }

                MessageBox.Show(
                    "Cadastro realizado!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show(
                    "Esse email ja esta cadastrado.",
                    "Atencao",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
