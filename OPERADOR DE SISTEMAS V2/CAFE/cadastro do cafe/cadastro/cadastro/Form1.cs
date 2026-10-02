using System;
using System.Drawing;
using System.Windows.Forms;

namespace cadastro
{
	public partial class Frm_Cadastro : Form
	{
		public Frm_Cadastro()
		{
			InitializeComponent();

			btn_Nome.Click += delegate { ExibirCampo("Nome", txt_Nome); };
			btn_Sobrenome.Click += delegate { ExibirCampo("Sobrenome", txt_Sobrenome); };
			btn_Idade.Click += delegate { ExibirCampo("Idade", txt_Idade); };
			btn_Bairro.Click += delegate { ExibirCampo("Bairro", txt_Bairro); };
			btn_Celular.Click += delegate { ExibirCampo("Celular", txt_Celular); };
			btn_Email.Click += delegate { ExibirCampo("Email", txt_Email); };
			btn_DadosCompletos.Click += ExibirDadosCompletos;

			rad_tema1.CheckedChanged += rad_tema1_CheckedChanged;
			rad_tema3.CheckedChanged += rad_tema3_CheckedChanged;
			btnativar.CheckedChanged += btnativar_CheckedChanged;
			btnativar.Checked = true;

			// Mantém o resultado visível e legível quando os dados ocupam várias linhas.
			lblresultados.AutoSize = false;
			lblresultados.Location = new Point(344, 240);
			lblresultados.Size = new Size(600, 230);
			lblresultados.BorderStyle = BorderStyle.FixedSingle;
			lblresultados.TextAlign = ContentAlignment.TopLeft;
		}

		private void ExibirCampo(string nome, TextBox campo)
		{
			lblresultados.Text = nome + ": " + campo.Text.Trim();
		}

		private void ExibirDadosCompletos(object sender, EventArgs e)
		{
			lblresultados.Text =
				"Nome: " + txt_Nome.Text.Trim() + " " + txt_Sobrenome.Text.Trim() + Environment.NewLine +
				"Idade: " + txt_Idade.Text.Trim() + Environment.NewLine +
				"Bairro: " + txt_Bairro.Text.Trim() + Environment.NewLine +
				"Celular: " + txt_Celular.Text.Trim() + Environment.NewLine +
				"Email: " + txt_Email.Text.Trim();
		}

		private void LimparCampos()
		{
			txt_Nome.Clear();
			txt_Sobrenome.Clear();
			txt_Idade.Clear();
			txt_Bairro.Clear();
			txt_Celular.Clear();
			txt_Email.Clear();
			lblresultados.Text = "";
		}

		private void DefinirEdicaoAtiva(bool ativa)
		{
			Control[] controlesDeEdicao =
			{
				txt_Nome, txt_Sobrenome, txt_Idade, txt_Bairro, txt_Celular, txt_Email,
				btn_Nome, btn_Sobrenome, btn_Idade, btn_Bairro, btn_Celular, btn_Email,
				btn_DadosCompletos
			};

			foreach (Control controle in controlesDeEdicao)
			{
				controle.Enabled = ativa;
			}

			// Não desabilite o GroupBox inteiro: o botão "ativar" fica dentro dele.
			grptemas.Enabled = true;
			rad_tema1.Enabled = ativa;
			rad_tema2.Enabled = ativa;
			rad_tema3.Enabled = ativa;
			btnativar.Enabled = true;
		}

		private void AplicarTema(Color cor)
		{
			BackColor = cor;
		}

		private void rad_tema1_CheckedChanged(object sender, EventArgs e)
		{
			if (rad_tema1.Checked) AplicarTema(Color.MistyRose);
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (rad_tema2.Checked) AplicarTema(Color.Honeydew);
		}

		private void rad_tema3_CheckedChanged(object sender, EventArgs e)
		{
			if (rad_tema3.Checked) AplicarTema(Color.Lavender);
		}

		private void btnativar_CheckedChanged(object sender, EventArgs e)
		{
			if (btnativar.Checked) DefinirEdicaoAtiva(true);
		}

		private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
		{
			if (btndesativar.Checked) DefinirEdicaoAtiva(false);
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			if (btnlimpar.Checked)
			{
				LimparCampos();
				btnativar.Checked = true;
			}
		}

		private void Frm_Cadastro_Load(object sender, EventArgs e)
		{
		}

		private void label2_Click(object sender, EventArgs e)
		{
		}

		private void label4_Click(object sender, EventArgs e)
		{
		}

		private void txt_Bairro_TextChanged(object sender, EventArgs e)
		{
		}

		private void grptemas_Enter(object sender, EventArgs e)
		{
		}
	}
}
