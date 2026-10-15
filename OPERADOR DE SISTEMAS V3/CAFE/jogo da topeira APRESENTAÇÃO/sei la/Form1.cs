using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sei_la
{
    // Form1 - TELA DE INÍCIO do jogo
    // Estilo similar ao menu do Crash Bandicoot
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Inicializa os componentes visuais do formulário
            InitializeComponent();
        }

        // Evento que ocorre quando o formulário é carregado
        private void Form1_Load(object sender, EventArgs e)
        {
            // Define o título da janela
            this.Text = "Jogo da Toupeira - Menu Principal";

            // Configura o cursor de martelo em TODOS os controles do menu
            // O cursor foi adicionado nos Resources como "Thor_s_Hammer"
            this.Cursor = new Cursor(sei_la.Properties.Resources.Thor_s_Hammer.Handle);
            btnStart.Cursor = new Cursor(sei_la.Properties.Resources.Thor_s_Hammer.Handle);
            btnLoadGame.Cursor = new Cursor(sei_la.Properties.Resources.Thor_s_Hammer.Handle);
            btnPassword.Cursor = new Cursor(sei_la.Properties.Resources.Thor_s_Hammer.Handle);
            btnOptions.Cursor = new Cursor(sei_la.Properties.Resources.Thor_s_Hammer.Handle);
        }

        // Botão START - Inicia o jogo
        // Abre o Form2 onde o jogo da toupeira acontece
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância do Form2 (tela do jogo)
            Form2 jogo = new Form2();

            // Esconde o menu principal (Form1)
            this.Hide();

            // Abre o jogo (Form2)
            jogo.ShowDialog();

            // Quando o jogo fechar, volta a mostrar o menu
            this.Show();
        }

        // Botão LOAD GAME - Carregar jogo salvo
        // (Funcionalidade futura - apenas exibe mensagem por enquanto)
        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidade de carregar jogo em desenvolvimento!",
                "Load Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Botão PASSWORD - Inserir senha/código
        // (Funcionalidade futura - apenas exibe mensagem por enquanto)
        private void btnPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidade de senha em desenvolvimento!",
                "Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Botão OPTIONS - Configurações do jogo
        // (Funcionalidade futura - apenas exibe mensagem por enquanto)
        private void btnOptions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidade de opções em desenvolvimento!\n\n" +
                "Configurações disponíveis:\n" +
                "- Volume do som\n" +
                "- Dificuldade do jogo\n" +
                "- Tamanho da tela",
                "Options", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}