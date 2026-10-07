using System;
using System.Globalization;
using System.Windows.Forms;

namespace CalculadoraCafe
{
    public partial class frm_calculadora : Form
    {
        public frm_calculadora()
        {
            InitializeComponent();
        }

        // Café: aceita os números no formato regional do computador, incluindo vírgula decimal.
        private bool ValidarEntradas(out decimal primeiro, out decimal segundo)
        {
            primeiro = 0m;
            segundo = 0m;

            NumberStyles formatoNumerico = NumberStyles.Number;
            bool primeiroValido = decimal.TryParse(txt_primeiro.Text, formatoNumerico, CultureInfo.CurrentCulture, out primeiro);
            bool segundoValido = decimal.TryParse(txt_segundo.Text, formatoNumerico, CultureInfo.CurrentCulture, out segundo);

            if (!primeiroValido || !segundoValido)
            {
                MessageBox.Show(
                    "Digite um número válido em cada campo para continuar.",
                    "Confira os valores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Todas as contas passam por este método para manter a validação e a resposta padronizadas.
        private void Calcular(string operacao, Func<decimal, decimal, decimal> conta, bool divisao = false)
        {
            decimal valorInicial;
            decimal valorFinal;
            if (!ValidarEntradas(out valorInicial, out valorFinal))
            {
                return;
            }

            if (divisao && valorFinal == 0m)
            {
                MessageBox.Show(
                    "Divisão por zero não é permitida.",
                    "Operação inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                decimal resultado = conta(valorInicial, valorFinal);
                string mensagem = string.Format(
                    CultureInfo.CurrentCulture,
                    "Resultado da {0}: {1}",
                    operacao,
                    resultado);

                MessageBox.Show(mensagem, "Calculadora do Café", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OverflowException)
            {
                MessageBox.Show(
                    "Esse cálculo passa do limite que a calculadora consegue representar.",
                    "Valor muito grande",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // Café: a soma mantém as casas decimais do resultado.
        private void btn_soma_Click(object sender, EventArgs e)
        {
            Calcular("soma", (a, b) => a + b);
        }

        // A subtração também aceita valores negativos.
        private void btn_subtracao_Click(object sender, EventArgs e)
        {
            Calcular("subtração", (a, b) => a - b);
        }

        // Multiplicação preserva a precisão decimal usada nas outras operações.
        private void btn_multiplicacao_Click(object sender, EventArgs e)
        {
            Calcular("multiplicação", (a, b) => a * b);
        }

        // O sinalizador ativa a verificação do segundo valor antes da divisão.
        private void btn_divisao_Click(object sender, EventArgs e)
        {
            Calcular("divisão", (a, b) => a / b, true);
        }

        // Limpar deixa os campos prontos para a próxima conta.
        private void btn_limpar_Click(object sender, EventArgs e)
        {
            txt_primeiro.Clear();
            txt_segundo.Clear();
            txt_primeiro.Focus();
        }
    }
}
