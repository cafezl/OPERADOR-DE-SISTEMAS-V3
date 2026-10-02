using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Recarga
{
    public partial class Form1 : Form
    {// OS botões precisam aparecer valores diferentes para cada operadora selecionada. 
        private readonly Button[] botoesRecarga;
        private readonly Label[] labelsValidade;
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

            for (int i = 0; i < botoesRecarga.Length; i++)
            {
                botoesRecarga[i].Text = valoresDemonstracao[i];
                labelsValidade[i].Text = "Consulte a operadora";
                if (i < 6)
                {
                    botoesRecarga[i].Click += SelecionarRecarga;
                }
            }

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

            txt_OperadoraSe.Text = opcao.Text;
            AtualizarValoresRecarga(opcao.Text);
            AplicarTemaDaOperadora(opcao.Text);
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
            }
        }

        private void AplicarTemaDaOperadora(string operadora)
        {
            Color corFormulario;
            Color corCampo;
            Color corTexto;

            switch (operadora.ToUpperInvariant())
            {
                case "VIVO":
                    corFormulario = Color.Purple;
                    corCampo = Color.Purple;
                    corTexto = Color.White;
                    break;
                case "CLARO":
                    corFormulario = Color.DarkRed;
                    corCampo = Color.Red;
                    corTexto = Color.White;
                    break;
                case "TIM":
                    corFormulario = Color.DarkBlue;
                    corCampo = Color.Blue;
                    corTexto = Color.White;
                    break;
                case "OI":
                    corFormulario = Color.DarkOrange;
                    corCampo = Color.Orange;
                    corTexto = Color.Black;
                    break;
                default:
                    corFormulario = SystemColors.Control;
                    corCampo = SystemColors.Window;
                    corTexto = SystemColors.WindowText;
                    break;
            }

            BackColor = corFormulario;
            txt_OperadoraSe.BackColor = corCampo;
            txt_OperadoraSe.ForeColor = corTexto;
        }

        private void AtualizarBotoesRecarga()
        {
            bool dadosValidos = !string.IsNullOrWhiteSpace(txt_Nome.Text)
                && !string.IsNullOrWhiteSpace(txt_OperadoraSe.Text)
                && txt_DDD.Text.Length == 2
                && (txt_Numero.Text.Length == 8 || txt_Numero.Text.Length == 9);

            foreach (Button botao in botoesRecarga)
            {
                botao.Enabled = dadosValidos;
            }
        }

        private void CampoNumerico_TextChanged(object sender, EventArgs e)
        {
            TextBox campo = sender as TextBox;
            if (campo == null)
            {
                return;
            }

            string somenteDigitos = new string(campo.Text.Where(char.IsDigit).ToArray());
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

            txt_Valor.Text = botao.Text;
            label7.Text = "Valor escolhido (demonstração)";
            MessageBox.Show(
                this,
                "Seleção de demonstração registrada para " + txt_OperadoraSe.Text + ".\n" +
                "Número: (" + txt_DDD.Text + ") " + txt_Numero.Text + "\n" +
                "Valor: " + botao.Text + "\n\n" +
                "Esta tela não realiza pagamento nem recarga real.",
                "Recarga de demonstração",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SelecionarOperadora(radioButton1);


         

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SelecionarOperadora(radioButton2);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SelecionarOperadora(radioButton3);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            SelecionarOperadora(radioButton4);
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
            label7.Text = "Selecione o valor de recarga";
            AtualizarBotoesRecarga();
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void label16_Click(object sender, EventArgs e)
        {
        }

        private void lbl_nome_Click(object sender, EventArgs e)
        {
        }

        private void btn1_Click(object sender, EventArgs e)
        {

        }

        private void btn3_Click(object sender, EventArgs e)
        {

        }

        private void lbl_VAL1_Click(object sender, EventArgs e)
        {

        }
    }
}
