using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Recarga
{
    public partial class Form1 : Form
    {
        // Arrays para armazenar os componentes visuais da tela (Botões e Labels)
        // Isso facilita a manipulação de todos eles usando laços de repetição (loops)
        private readonly Button[] botoesRecarga;
        private readonly Label[] labelsValidade;

        // Valores padrão de demonstração caso nenhuma operadora específica seja encontrada
        private readonly string[] valoresDemonstracao =
        {
            "R$ 10,00", "R$ 15,00", "R$ 20,00", "R$ 25,00",
            "R$ 30,00", "R$ 35,00", "R$ 40,00", "R$ 50,00"
        };

        // Dicionário que mapeia o nome de cada operadora (chave) para uma lista de valores (array de strings)
        // O StringComparer.OrdinalIgnoreCase faz com que "VIVO" e "vivo" sejam tratados da mesma forma
        private readonly Dictionary<string, string[]> valoresPorOperadora =
            new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase)
            {
                { "VIVO", new[] { "R$ 10,00", "R$ 15,00", "R$ 20,00", "R$ 25,00", "R$ 30,00", "R$ 35,00", "R$ 40,00", "R$ 50,00" } },
                { "CLARO", new[] { "R$ 12,00", "R$ 17,00", "R$ 22,00", "R$ 27,00", "R$ 32,00", "R$ 37,00", "R$ 42,00", "R$ 52,00" } },
                { "TIM", new[] { "R$ 13,00", "R$ 18,00", "R$ 23,00", "R$ 28,00", "R$ 33,00", "R$ 38,00", "R$ 43,00", "R$ 53,00" } },
                { "OI", new[] { "R$ 19,00", "R$ 19,25", "R$ 24,00", "R$ 29,00", "R$ 34,00", "R$ 39,00", "R$ 46,00", "R$ 54,00" } }
            };

        // Construtor do formulário. É executado quando a tela é criada
        public Form1()
        {
            InitializeComponent(); // Carrega os componentes visuais criados no Designer 

            // Preenche os arrays com as referências dos botões e labels que estão na tela
            botoesRecarga = new Button[] { btn1, btn2, btn3, btn4, btn5, btn6, button7, button8 };
            labelsValidade = new Label[] { lbl_VAL1, lbl_VAL2, lbl_VAL3, lbl_VAL4, lbl_VAL5, lbl_VAL6, lbl_VAL7, lbl_VAl8 };

            // Laço para configurar os textos iniciais dos botões e labels de validade
            for (int i = 0; i < botoesRecarga.Length; i++)
            {
                botoesRecarga[i].Text = valoresDemonstracao[i]; // Define o texto do botão
                labelsValidade[i].Text = "Consulte a operadora"; // Define o texto da label

                // Adiciona o evento de clique 'SelecionarRecarga' para os 6 primeiros botões
                if (i < 6)
                {
                    botoesRecarga[i].Click += SelecionarRecarga;
                }
            }

            // Configurações iniciais dos campos de texto (TextBox)
            txt_OperadoraSe.ReadOnly = true; // Impede digitação no campo da operadora (será preenchido pelo RadioButton)
            txt_Valor.ReadOnly = true;       // Impede digitação no campo valor (será preenchido clicando no botão)
            txt_DDD.MaxLength = 2;           // Limita o DDD a 2 caracteres
            txt_Numero.MaxLength = 9;        // Limita o número de celular a 9 caracteres

            // Associa os eventos de alteração de texto (quando o usuário digita algo) aos métodos validadores
            txt_DDD.TextChanged += CampoNumerico_TextChanged; // Aceitará apenas números
            txt_Numero.TextChanged += CampoNumerico_TextChanged; // Aceitará apenas números
            txt_Nome.TextChanged += Campo_TextChanged; // Dispara validação genérica ao digitar o nome
        }

        // Método auxiliar para ativar (Enabled = true) ou desativar (Enabled = false) os campos do formulário
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

            // Ativa ou desativa todas as labels de validade
            foreach (Label validade in labelsValidade)
            {
                validade.Enabled = ativos;
            }

            // Verifica se os botões de recarga devem ser ativados baseados nos dados preenchidos
            AtualizarBotoesRecarga();
        }

        // Método chamado quando um RadioButton de operadora é clicado
        private void SelecionarOperadora(RadioButton opcao)
        {
            // Se o botão de rádio não estiver marcado, não faz nada
            if (!opcao.Checked)
            {
                return;
            }

            txt_OperadoraSe.Text = opcao.Text; // Preenche o campo de texto com o nome da operadora escolhida
            AtualizarValoresRecarga(opcao.Text); // Muda os valores dos botões baseado na operadora
            AplicarTemaDaOperadora(opcao.Text); // Muda as cores do formulário
            LimparValorSelecionado(); // Limpa a seleção de recarga anterior
            AtualizarCamposDaOperadora(true); // Habilita os campos para o usuário digitar
            txt_Nome.Focus(); // Coloca o cursor de digitação no campo 'Nome'
        }

        // Método que altera os textos (R$) dos botões de acordo com a operadora
        private void AtualizarValoresRecarga(string operadora)
        {
            string[] valores;
            // Tenta buscar os valores no dicionário. Se não achar a operadora, usa os de demonstração
            if (!valoresPorOperadora.TryGetValue(operadora, out valores))
            {
                valores = valoresDemonstracao;
            }

            // Atualiza o texto de cada botão na tela
            for (int i = 0; i < botoesRecarga.Length; i++)
            {
                botoesRecarga[i].Text = valores[i];
            }
        }

        // Altera as cores de fundo (BackColor) e fonte (ForeColor) do formulário dependendo da operadora
        private void AplicarTemaDaOperadora(string operadora)
        {
            Color corFormulario;
            Color corCampo;
            Color corTexto;

            // Verifica qual é a operadora (convertendo para maiúsculo para garantir a igualdade)
            switch (operadora.ToUpperInvariant())
            {
                case "VIVO":
                    corFormulario = Color.Purple;
                    corCampo = Color.Purple;
                    corTexto = Color.White;
                    break;
                case "CLARO":
                    corFormulario = Color.Red;
                    corCampo = Color.DarkRed;
                    corTexto = Color.White;
                    break;
                case "TIM":
                    corFormulario = Color.Blue;
                    corCampo = Color.DarkBlue;
                    corTexto = Color.White;
                    break;
                case "OI":
                    corFormulario = Color.Orange;
                    corCampo = Color.DarkOrange;
                    corTexto = Color.Black;
                    break;
                default: // Caso padrão (se não for nenhuma das de cima)
                    corFormulario = SystemColors.Control;
                    corCampo = SystemColors.Window;
                    corTexto = SystemColors.WindowText;
                    break;
            }

            // Aplica as cores definidas acima aos componentes da tela
            BackColor = corFormulario;
            txt_OperadoraSe.BackColor = corCampo;
            txt_OperadoraSe.ForeColor = corTexto;
        }

        // Verifica se os campos obrigatórios estão preenchidos para liberar (habilitar) os botões de recarga
        private void AtualizarBotoesRecarga()
        {
            // Variável booleana (true/false) que checa se os dados são válidos:
            // Nome não pode estar vazio, Operadora não pode estar vazia, DDD deve ter 2 dígitos, Número deve ter 8 ou 9 dígitos.
            bool dadosValidos = !string.IsNullOrWhiteSpace(txt_Nome.Text)
                && !string.IsNullOrWhiteSpace(txt_OperadoraSe.Text)
                && txt_DDD.Text.Length == 2
                && (txt_Numero.Text.Length == 8 || txt_Numero.Text.Length == 9);

            // Habilita ou desabilita todos os botões de recarga dependendo se os dados são válidos ou não
            foreach (Button botao in botoesRecarga)
            {
                botao.Enabled = dadosValidos;
            }
        }

        // Evento acionado toda vez que o texto dos campos numéricos (DDD ou Número) muda
        private void CampoNumerico_TextChanged(object sender, EventArgs e)
        {
            TextBox campo = sender as TextBox; // Identifica quem disparou o evento
            if (campo == null)
            {
                return;
            }

            // Filtra o texto, mantendo apenas os caracteres que são dígitos (0 a 9)
            string somenteDigitos = new string(campo.Text.Where(char.IsDigit).ToArray());

            // Se o usuário digitou letras/símbolos, o texto vai ser diferente da versão filtrada
            if (campo.Text != somenteDigitos)
            {
                int cursor = campo.SelectionStart; // Salva a posição do cursor
                campo.Text = somenteDigitos; // Substitui o texto só pelos números
                campo.SelectionStart = Math.Min(cursor, campo.Text.Length); // Restaura a posição do cursor para não pular pro começo
            }

            LimparValorSelecionado(); // Limpa seleções anteriores caso o usuário mude o número no meio do processo
            AtualizarBotoesRecarga(); // Checa novamente se os botões devem ser habilitados
        }

        // Evento acionado toda vez que o texto de um campo normal (como o Nome) muda
        private void Campo_TextChanged(object sender, EventArgs e)
        {
            LimparValorSelecionado();
            AtualizarBotoesRecarga(); // Checa se já pode habilitar os botões de valores
        }

        // Método que reseta a indicação de que um valor já foi escolhido
        private void LimparValorSelecionado()
        {
            txt_Valor.Clear();
            label7.Text = "Selecione o valor de recarga";
        }

        // Evento disparado quando qualquer um dos 6 primeiros botões de valores é clicado
        private void SelecionarRecarga(object sender, EventArgs e)
        {
            ConfirmarSelecao(sender as Button); // Passa o botão que foi clicado para a função de confirmação
        }

        // Função principal que finaliza a demonstração capturando o valor do botão clicado
        private void ConfirmarSelecao(Button botao)
        {
            // Proteção: Se o botão for nulo ou estiver desabilitado, ignora o clique
            if (botao == null || !botao.Enabled)
            {
                return;
            }

            txt_Valor.Text = botao.Text; // Joga o valor (ex: "R$ 20,00") pro TextBox txt_Valor
            label7.Text = "Valor escolhido (demonstração)";

            // Exibe uma caixa de mensagem na tela com um resumo simulado da operação
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

        // ---------- EVENTOS DE CLIQUE DOS RADIOBUTTONS (Operadoras) ----------

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SelecionarOperadora(radioButton1);
          
        }

        // Evento disparado quando o RadioButton da Claro é marcado/desmarcado
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SelecionarOperadora(radioButton2);
            
        }

        // Evento disparado quando o RadioButton da TIM é marcado/desmarcado
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SelecionarOperadora(radioButton3);
           
        }

        // Evento disparado quando o RadioButton da Oi é marcado/desmarcado
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            SelecionarOperadora(radioButton4);
            
        }

        // ---------- EVENTOS ESPECÍFICOS DOS DOIS ÚLTIMOS BOTÕES ----------
        // (Nota: os botões 7 e 8 foram configurados de forma manual pelo visual studio, diferente do loop no Form1() )
        private void button7_Click(object sender, EventArgs e)
        {
            ConfirmarSelecao(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ConfirmarSelecao(button8);
        }

        // ---------- EVENTO CARREGAMENTO DO FORMULÁRIO ----------
        private void Form1_Load(object sender, EventArgs e)
        {
            // Ações extras ao abrir o app: limpar o campo de valor e definir o texto da instrução
            txt_Valor.Clear();
            label7.Text = "Selecione o valor de recarga";
            AtualizarBotoesRecarga(); // Força os botões a começarem bloqueados (já que os campos estão vazios)
        }

        // ---------- EVENTOS VAZIOS GERADOS SEM QUERER PELO DESIGNER ----------
        // Estes métodos podem ser removidos (se você desvincular o evento lá nas Propriedades do Visual Studio antes), 
        // mas não causam erro estando vazios.
        private void label7_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void label16_Click(object sender, EventArgs e) { }
        private void lbl_nome_Click(object sender, EventArgs e) { }
        private void btn1_Click(object sender, EventArgs e) { }
        private void btn3_Click(object sender, EventArgs e) { }
        private void lbl_VAL1_Click(object sender, EventArgs e) { }

        private void btn5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

        }

    }
}