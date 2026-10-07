// Puxando as ferramentas básicas do C# pra gente usar (tipo os bloquinhos iniciais do jogo)
using System;
// Puxando a biblioteca que cria as janelas, botões e caixas de texto na tela do PC
using System.Windows.Forms;

// O namespace é tipo a pasta principal do seu projeto onde vc guarda tudo dessa calculadora
namespace calculadora
{
    // Aqui é a nossa janela do app. A gente herda (:) de 'Form' pq o Windows já dá uma janela pronta pra gente brincar
    public partial class frm_calculadora : Form
    {
        // Esse é o "construtor". É a primeira parada que roda quando vc dá dois cliques pra abrir o app
        public frm_calculadora()
        {
            // Isso aqui desenha a tela mágica. Se apagar isso, seu app abre mas fica invisível kkk
            InitializeComponent();
        }

        // -------------------------------------------------------------------------
        // Saca só: essa função é um filtro anti-vacilo. 
        // Vc não quer que seu app crashe pq o usuário digitou "abacate" no lugar de número, né?
        // O 'out' significa: "mano, pega essas variáveis vazias e cospe elas com os números certos pra mim"
        // -------------------------------------------------------------------------
        private bool ValidarEntradas(out double num1, out double num2)
        {
            // Zera tudo por precaução antes de começar
            num1 = 0;
            num2 = 0;

            // O 'TryParse' tenta forçar o texto a virar um número com vírgula (double). 
            // Se o usuário digitou letra ou deixou vazio, o TryParse dá 'false'.
            // Esse ponto de exclamação (!) no começo significa "Se der RUIM".
            if (!double.TryParse(txt_primeiro.Text, out num1) || !double.TryParse(txt_segundo.Text, out num2))
            {
                // Deu ruim! Solta um pop-up na tela xingando (com educação) o usuário
                MessageBox.Show("Por favor, insira números válidos em ambos os campos.", "Erro de Digitação", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Retorna false pra avisar o resto do código: "deu B.O., para a conta aí!"
                return false;
            }

            // Se passou do IF, é pq os números tão suave. Retorna true e segue o baile.
            return true;
        }

        // -------------------------------------------------------------------------
        // Quando vc clica no botão de SOMAR
        // -------------------------------------------------------------------------
        private void btn_soma_Click(object sender, EventArgs e)
        {
            // Chama o nosso filtro ali de cima. Só entra aqui se o filtro retornar true (tudo certo)
            if (ValidarEntradas(out double n1, out double n2))
            {
                // Faz a soma! Mas ó um detalhe: esse '(int)' força o resultado a perder as vírgulas.
                // Tipo, se a soma der 5.8, ele corta e vira 5. Loucura né? Mas é o que tá escrito aí.
                int resultado = (int)(n1 + n2);

                // Mostra o resultado num pop-up daora. Esse '$' deixa a gente colocar a variável direto no texto
                MessageBox.Show($"O resultado da soma é: {resultado}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // -------------------------------------------------------------------------
        // Quando vc clica no botão de SUBTRAIR
        // -------------------------------------------------------------------------
        private void btn_subtracao_Click(object sender, EventArgs e)
        {
            // Filtro de novo pra ver se ninguem digitou letra
            if (ValidarEntradas(out double n1, out double n2))
            {
                // Faz a conta de menos. Aqui ele não corta os números quebrados, deixa como double mesmo
                double resultado = n1 - n2;

                // Joga na tela!
                MessageBox.Show($"O resultado da subtração é: {resultado}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // -------------------------------------------------------------------------
        // Quando vc clica no botão de MULTIPLICAR
        // -------------------------------------------------------------------------
        private void btn_multiplicacao_Click(object sender, EventArgs e)
        {
            // Já tá ligado né? Passando no filtro anti-vacilo...
            if (ValidarEntradas(out double n1, out double n2))
            {
                // Multiplica um pelo outro
                double resultado = n1 * n2;

                // Exibe pro usuário
                MessageBox.Show($"O resultado da multiplicação é: {resultado}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // -------------------------------------------------------------------------
        // Quando vc clica no botão de DIVIDIR
        // -------------------------------------------------------------------------
        private void btn_divisao_Click(object sender, EventArgs e)
        {
            // Filtro rodando...
            if (ValidarEntradas(out double n1, out double n2))
            {
                // Aqui tem uma treta: e se o cara tentar dividir por zero? 
                // O PC não sabe resolver isso e o app crasha. Então a gente previne.
                if (n2 == 0)
                {
                    // Se o número de baixo (n2) for zero, dá bronca com ícone de erro
                    MessageBox.Show("Não é possível dividir por zero!", "Erro Matemático", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Se não for zero, tá liberado, faz a divisão suave
                    double resultado = n1 / n2;
                    MessageBox.Show($"O resultado da divisão é: {resultado}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // -------------------------------------------------------------------------
        // Quando vc clica no botão de LIMPAR (pra fazer uma conta nova)
        // -------------------------------------------------------------------------
        private void btn_limpar_Click(object sender, EventArgs e)
        {
            // Apaga os textos das duas caixinhas
            txt_primeiro.Clear();
            txt_segundo.Clear();

            // Mó adianto de vida: o Focus() joga o tracinho de digitar de volta pro primeiro campo
            // Assim vc não precisa pegar o mouse pra clicar lá e digitar a próxima conta.
            txt_primeiro.Focus();
        }
    }
}