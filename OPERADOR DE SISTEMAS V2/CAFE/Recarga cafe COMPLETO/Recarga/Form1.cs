using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Recarga
{
    public partial class Form1 : Form
    {
        private readonly Button[] botoesRecarga;
        private readonly Label[] labelsValidade;

        // Tabela de valores de demonstração por operadora
        private readonly string[] valoresDemonstracao =
        {
            "R$ 10,00", "R$ 15,00", "R$ 20,00", "R$ 25,00",
            "R$ 30,00", "R$ 35,00", "R$ 40,00", "R$ 50,00"
        };

        private readonly Dictionary<string, string[]> valoresPorOperadora =
            new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase)
            {
                { "VIVO", new[] { "R$ 10,00", "R$ 15,00", "R$ 20,00", "R$ 25,00", "R$ 30,00", "R$ 35,00", "R$ 40,00", "R$ 50,00" } },
                { "CLARO", new[] { "R$ 12,00", "R$ 17,00", "R$ 22,00", "R$ 27,00", "R$ 32,00", "R$ 37,00", "R$ 42,00", "R$ 52,00" } },
                { "TIM", new[] { "R$ 13,00", "R$ 18,00", "R$ 23,00", "R$ 28,00", "R$ 33,00", "R$ 38,00", "R$ 43,00", "R$ 53,00" } },
                { "OI", new[] { "R$ 14,00", "R$ 19,00", "R$ 24,00", "R$ 29,00", "R$ 34,00", "R$ 39,00", "R$ 44,00", "R$ 54,00" } }
            };

        public Form1()
        {
            InitializeComponent();

            botoesRecarga = new Button[] { btn1, btn2, btn3, btn4, btn5, btn6, button7, button8 };
            labelsValidade = new Label[] { lbl_VAL1, lbl_VAL2, lbl_VAL3, lbl_VAL4, lbl_VAL5, lbl_VAL6, lbl_VAL7, lbl_VAl8 };

            // Os oito valores-base vêm da tabela de demonstração
            for (int i = 0; i < botoesRecarga.Length; i++)
            {
                botoesRecarga[i].Text = valoresDemonstracao[i];
            }

            // O prazo começa vazio até escolher a operadora
            foreach (Label validade in labelsValidade)
            {
                validade.Text = "--";
            }

            for (int i = 0; i < 6; i++)
            {
                botoesRecarga[i].Click += SelecionarRecarga;
            }

            // Garantindo que os botões 7 e 8 também acionem o evento
            button7.Click += SelecionarRecarga;
            button8.Click += SelecionarRecarga;

            txt_OperadoraSe.ReadOnly = true;
            txt_Valor.ReadOnly = true;
            txt_DDD.MaxLength = 2;
            txt_Numero.MaxLength = 9;
            txt_DDD.TextChanged += CampoNumerico_TextChanged;
            txt_Numero.TextChanged += CampoNumerico_TextChanged;
            txt_Nome.TextChanged += Campo_TextChanged;
        }

        private void AtualizarCamposDaOperadora(bool ativos)
        {
            txt_Nome.Enabled = ativos;
            txt_OperadoraSe.Enabled = ativos;
            txt_DDD.Enabled = ativos;
            txt_Numero.Enabled = ativos;
            txt_Valor.Enabled = ativos;
            lbl_nome.Enabled = ativos;
            lbl_operadoraS.Enabled = ativos;
            lbl_ddd.Enabled = ativos;
            lbl_Celular.Enabled = ativos;
            lbl_ValorRecar.Enabled = ativos;
            lbl_bemvindo.Enabled = ativos;
            label7.Enabled = ativos;

            foreach (Label validade in labelsValidade)
            {
                validade.Enabled = ativos;
            }

            AtualizarBotoesRecarga();
        }

        private void SelecionarOperadora(RadioButton opcao)
        {
            if (!opcao.Checked)
            {
                return;
            }

            // Apaga o número quando o usuário troca de operadora
            txt_Numero.Clear();

            txt_OperadoraSe.Text = opcao.Text;
            AtualizarValoresRecarga(opcao.Text);

            // Altera a cor de fundo do Form inteiro e do campo da operadora de acordo com a escolha
            switch (opcao.Text.ToUpper())
            {
                case "VIVO":
                    this.BackColor = Color.Purple;
                    txt_OperadoraSe.BackColor = Color.Purple;
                    txt_OperadoraSe.ForeColor = Color.White;
                    break;
                case "CLARO":
                    this.BackColor = Color.Red;
                    txt_OperadoraSe.BackColor = Color.Red;
                    txt_OperadoraSe.ForeColor = Color.White;
                    break;
                case "TIM":
                    this.BackColor = Color.Blue;
                    txt_OperadoraSe.BackColor = Color.Blue;
                    txt_OperadoraSe.ForeColor = Color.White;
                    break;
                case "OI":
                    this.BackColor = Color.DarkOrange;
                    txt_OperadoraSe.BackColor = Color.Orange;
                    txt_OperadoraSe.ForeColor = Color.Black;
                    break;
                default:
                    this.BackColor = Color.Black;
                    txt_OperadoraSe.BackColor = Color.Black;
                    txt_OperadoraSe.ForeColor = Color.White;
                    break;
            }

            LimparValorSelecionado();
            AtualizarCamposDaOperadora(true);
            txt_Nome.Focus();
        }

        private void AtualizarValoresRecarga(string operadora)
        {
            string[] valores;
            if (!valoresPorOperadora.TryGetValue(operadora, out valores))
            {
                valores = valoresDemonstracao;
            }

            for (int i = 0; i < botoesRecarga.Length; i++)
            {
                botoesRecarga[i].Text = valores[i];

                // Exibe os dias de validade (exemplo: os 4 primeiros = 30 dias, próximos 2 = 60 dias, etc)
                if (i < 4)
                {
                    labelsValidade[i].Text = "30 dias";
                }
                else if (i < 6)
                {
                    labelsValidade[i].Text = "60 dias";
                }
                else
                {
                    labelsValidade[i].Text = "90 dias";
                }
            }
        }

        private void AtualizarBotoesRecarga()
        {
            bool dddValido = txt_DDD.Text.Length == 2 && txt_DDD.Text[0] != '0';
            bool celularValido = txt_Numero.Text.Length == 9 && txt_Numero.Text[0] == '9';
            bool dadosValidos = !string.IsNullOrWhiteSpace(txt_Nome.Text)
                && !string.IsNullOrWhiteSpace(txt_OperadoraSe.Text)
                && dddValido
                && celularValido;

            foreach (Button botao in botoesRecarga)
            {
                botao.Enabled = dadosValidos;
            }

            if (string.IsNullOrWhiteSpace(txt_OperadoraSe.Text))
            {
                label7.Text = "Selecione uma operadora";
            }
            else if (string.IsNullOrWhiteSpace(txt_Nome.Text))
            {
                label7.Text = "Informe seu nome";
            }
            else if (!dddValido)
            {
                label7.Text = "Informe um DDD com dois dígitos";
            }
            else if (!celularValido)
            {
                label7.Text = "Celular: 9 dígitos, começando com 9";
            }
            else
            {
                label7.Text = "Selecione o valor de recarga";
            }
        }

        private void CampoNumerico_TextChanged(object sender, EventArgs e)
        {
            TextBox campo = sender as TextBox;
            if (campo == null)
            {
                return;
            }

            string somenteDigitos = new string(campo.Text.Where(caractere => caractere >= '0' && caractere <= '9').ToArray());
            if (campo.Text != somenteDigitos)
            {
                int cursor = campo.SelectionStart;
                campo.Text = somenteDigitos;
                campo.SelectionStart = Math.Min(cursor, campo.Text.Length);
            }

            LimparValorSelecionado();
            AtualizarBotoesRecarga();
        }

        private void Campo_TextChanged(object sender, EventArgs e)
        {
            LimparValorSelecionado();
            AtualizarBotoesRecarga();
        }

        private void LimparValorSelecionado()
        {
            txt_Valor.Clear();
            label7.Text = "Selecione o valor de recarga";
        }

        private void SelecionarRecarga(object sender, EventArgs e)
        {
            ConfirmarSelecao(sender as Button);
        }

        private void ConfirmarSelecao(Button botao)
        {
            if (botao == null || !botao.Enabled)
            {
                return;
            }

            // Manda o valor clicado direto pra textbox e avisa
            txt_Valor.Text = botao.Text;
            label7.Text = "Valor escolhido";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SelecionarOperadora(radioButton1);
            if (radioButton1.Checked)
                pictureBox1.Image = Properties.Resources.VIVO;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SelecionarOperadora(radioButton2);
            if (radioButton2.Checked)
                pictureBox1.Image = Properties.Resources.CLARO;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SelecionarOperadora(radioButton3);
            if (radioButton3.Checked)
                pictureBox1.Image = Properties.Resources.TIM;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            SelecionarOperadora(radioButton4);
            if (radioButton4.Checked)
                pictureBox1.Image = Properties.Resources.OI;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ConfirmarSelecao(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ConfirmarSelecao(button8);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_Valor.Clear();
            label7.Text = "Selecione uma operadora";
            AtualizarBotoesRecarga();

            // Inicia o app com TELA PRETA
            this.BackColor = Color.Black;
            txt_OperadoraSe.BackColor = Color.Black;
            txt_OperadoraSe.ForeColor = Color.White;

            // Desmarca todos os RadioButtons reais
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            // -------------------------------------------------------------
            // TRUQUE PARA EVITAR QUE A VIVO SEJA SELECIONADA SOZINHA
            // O WinForms marca o primeiro radiobutton ao focar na tela. 
            // Criamos um botão falso e invisível para absorver essa marcação.
            RadioButton rbFalso = new RadioButton();
            groupBox1.Controls.Add(rbFalso);
            rbFalso.Visible = false;
            rbFalso.Checked = true;
            // -------------------------------------------------------------

            // Limpa a logo
            pictureBox1.Image = null;
            pictureBox1.BackgroundImage = null;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Oculta/desativa as coisas até a pessoa clicar numa operadora
            AtualizarCamposDaOperadora(false);
            groupBox1.Enabled = true; // Para garantir que você pode selecionar a operadora
        }

        // Métodos de eventos associados ao designer
        private void label7_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void label16_Click(object sender, EventArgs e) { }
        private void lbl_nome_Click(object sender, EventArgs e) { }
        private void btn1_Click(object sender, EventArgs e) { }
        private void lbl_VAL1_Click(object sender, EventArgs e) { }
        private void lbl_VAl8_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void txt_Nome_TextChanged(object sender, EventArgs e) { }
        private void txt_OperadoraSe_TextChanged(object sender, EventArgs e) { }
        private void txt_DDD_TextChanged(object sender, EventArgs e) { }
        private void txt_Numero_TextChanged(object sender, EventArgs e) { }
        private void txt_Valor_TextChanged(object sender, EventArgs e) { }
        private void lbl_operadoraS_Click(object sender, EventArgs e) { }
        private void lbl_ddd_Click(object sender, EventArgs e) { }
        private void lbl_Celular_Click(object sender, EventArgs e) { }
        private void lbl_ValorRecar_Click(object sender, EventArgs e) { }
        private void btn2_Click(object sender, EventArgs e) { }
        private void btn3_Click(object sender, EventArgs e) { }
        private void btn4_Click(object sender, EventArgs e) { }
        private void btn5_Click(object sender, EventArgs e) { }
        private void btn6_Click(object sender, EventArgs e) { }
        private void lbl_VAL2_Click(object sender, EventArgs e) { }
        private void lbl_VAL3_Click(object sender, EventArgs e) { }
        private void lbl_VAL4_Click(object sender, EventArgs e) { }
        private void lbl_VAL5_Click(object sender, EventArgs e) { }
        private void lbl_VAL6_Click(object sender, EventArgs e) { }
        private void lbl_VAL7_Click(object sender, EventArgs e) { }
    }
}