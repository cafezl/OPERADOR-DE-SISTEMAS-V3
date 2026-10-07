using System;
using System.Globalization;
using System.Windows.Forms;

// Deus da Guerra: versão independente da calculadora usada no curso.
namespace calculadora
{
    public partial class frm_calculadora : Form
    {
        public frm_calculadora()
        {
            InitializeComponent();
        }

        // A validação fica em um só lugar para todas as operações tratarem a entrada igual.
        private bool ValidarEntradas(out decimal num1, out decimal num2)
        {
            num1 = 0m;
            num2 = 0m;

            NumberStyles estilo = NumberStyles.Number;
            bool primeiroValido = decimal.TryParse(txt_primeiro.Text, estilo, CultureInfo.CurrentCulture, out num1);
            bool segundoValido = decimal.TryParse(txt_segundo.Text, estilo, CultureInfo.CurrentCulture, out num2);

            if (!primeiroValido || !segundoValido)
            {
                MessageBox.Show(
                    "Por favor, insira números válidos em ambos os campos.",
                    "Erro de digitação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // O decimal conserva casas decimais e segue a configuração regional do Windows.
        private void ExecutarOperacao(string nome, Func<decimal, decimal, decimal> calcular, bool verificaDivisor = false)
        {
            decimal num1;
            decimal num2;
            if (!ValidarEntradas(out num1, out num2))
            {
                return;
            }

            if (verificaDivisor && num2 == 0m)
            {
                MessageBox.Show(
                    "Não é possível dividir por zero!",
                    "Erro matemático",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                decimal resultado = calcular(num1, num2);
                string mensagem = string.Format(
                    CultureInfo.CurrentCulture,
                    "O resultado da {0} é: {1}",
                    nome,
                    resultado);

                MessageBox.Show(mensagem, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OverflowException)
            {
                MessageBox.Show(
                    "O resultado ultrapassa o limite numérico desta calculadora.",
                    "Resultado fora do limite",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btn_soma_Click(object sender, EventArgs e)
        {
            ExecutarOperacao("soma", (primeiro, segundo) => primeiro + segundo);
        }

        private void btn_subtracao_Click(object sender, EventArgs e)
        {
            ExecutarOperacao("subtração", (primeiro, segundo) => primeiro - segundo);
        }

        private void btn_multiplicacao_Click(object sender, EventArgs e)
        {
            ExecutarOperacao("multiplicação", (primeiro, segundo) => primeiro * segundo);
        }

        private void btn_divisao_Click(object sender, EventArgs e)
        {
            ExecutarOperacao("divisão", (primeiro, segundo) => primeiro / segundo, true);
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            txt_primeiro.Clear();
            txt_segundo.Clear();
            txt_primeiro.Focus();
        }
    }
}
