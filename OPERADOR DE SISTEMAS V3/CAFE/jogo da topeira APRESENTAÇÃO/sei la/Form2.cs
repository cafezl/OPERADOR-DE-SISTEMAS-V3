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
    // Form2 - TELA DO JOGO DA TOUPEIRA
    // O jogador deve clicar nas toupeiras que aparecem
    public partial class Form2 : Form
    {
        // Variáveis do jogo
        private int nivel = 1;           // Nível atual (1 a 30)
        private int pontos = 0;          // Pontuação do jogador
        private int toupeirasRestantes = 10; // Toupeiras que faltam neste nível
        private Random random = new Random(); // Gerador de números aleatórios
        private Timer timerToupeira;     // Timer que controla o aparecimento das toupeiras
        private PictureBox toupeiraAtual; // PictureBox da toupeira que está visível
        private Image[] framesGif;       // Array para armazenar os frames do GIF animado
        private int frameAtual = 0;      // Frame atual do GIF
        private Timer timerGif;          // Timer para animar o GIF

        public Form2()
        {
            // Inicializa os componentes visuais
            InitializeComponent();

            // Cria o timer que controla o aparecimento das toupeiras
            timerToupeira = new Timer();
            timerToupeira.Interval = 1500; // Toupeira aparece a cada 1,5 segundos
            timerToupeira.Tick += TimerToupeira_Tick;

            // Cria o timer para animar o GIF de fundo
            timerGif = new Timer();
            timerGif.Interval = 100; // Troca de frame a cada 100ms
            timerGif.Tick += TimerGif_Tick;
        }

        // Evento que ocorre quando o formulário do jogo é carregado
        private void Form2_Load(object sender, EventArgs e)
        {
            // Define o título da janela com o nível atual
            this.Text = "Jogo da Toupeira - Nível " + nivel;

            // Configura o cursor de martelo em TODO o formulário
            // O cursor foi adicionado nos Resources como "Thor_s_Hammer"
            this.Cursor = new Cursor(sei_la.Properties.Resources.Thor_s_Hammer.Handle);

            // Aplica o cursor de martelo em todos os controles
            foreach (Control controle in this.Controls)
            {
                controle.Cursor = new Cursor(sei_la.Properties.Resources.Thor_s_Hammer.Handle);
            }

            // Carrega os frames do GIF animado
            CarregarGifAnimado();

            // Inicia a animação do GIF
            timerGif.Start();

            // Inicia o timer das toupeiras
            timerToupeira.Start();

            // Atualiza os labels com as informações iniciais
            AtualizarDisplay();
        }

        // Método que carrega os frames do GIF para animação
        private void CarregarGifAnimado()
        {
            try
            {
                // Carrega a imagem GIF dos Resources
                Image gifImage = sei_la.Properties.Resources.bbfd139b1304358dd4314364736e163d;

                // Obtém o número de frames do GIF
                int totalFrames = gifImage.GetFrameCount(System.Drawing.Imaging.FrameDimension.Time);

                // Cria o array de frames
                framesGif = new Image[totalFrames];

                // Extrai cada frame do GIF
                for (int i = 0; i < totalFrames; i++)
                {
                    gifImage.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Time, i);
                    framesGif[i] = new Bitmap(gifImage);
                }
            }
            catch
            {
                // Se der erro, usa apenas uma imagem estática
                framesGif = new Image[] { sei_la.Properties.Resources.bbfd139b1304358dd4314364736e163d };
            }
        }

        // Timer que anima o GIF de fundo (troca os frames)
        private void TimerGif_Tick(object sender, EventArgs e)
        {
            if (framesGif != null && framesGif.Length > 0)
            {
                // Avança para o próximo frame
                frameAtual = (frameAtual + 1) % framesGif.Length;

                // Define o frame atual como imagem de fundo
                this.BackgroundImage = framesGif[frameAtual];
            }
        }

        // Timer que controla o aparecimento das toupeiras
        private void TimerToupeira_Tick(object sender, EventArgs e)
        {
            // Remove a toupeira anterior se existir
            if (toupeiraAtual != null)
            {
                this.Controls.Remove(toupeiraAtual);
                toupeiraAtual.Dispose();
            }

            // Verifica se ainda há toupeiras restantes neste nível
            if (toupeirasRestantes > 0)
            {
                // Cria uma nova toupeira em posição aleatória
                CriarToupeira();
            }
            else
            {
                // Acabou as toupeiras deste nível - avança para o próximo
                AvancarNivel();
            }
        }

        // Método que cria uma toupeira em posição aleatória
        private void CriarToupeira()
        {
            // Cria o PictureBox da toupeira
            toupeiraAtual = new PictureBox();

            // Define o tamanho da toupeira
            toupeiraAtual.Size = new Size(100, 100);

            // Define a imagem da toupeira (usando a imagem dos Resources)
            toupeiraAtual.Image = sei_la.Properties.Resources.bbfd139b1304358dd4314364736e163d;
            toupeiraAtual.SizeMode = PictureBoxSizeMode.StretchImage;

            // Define a posição aleatória dentro do formulário
            // Evita que a toupeira fique muito perto das bordas
            int maxX = this.ClientSize.Width - 150;
            int maxY = this.ClientSize.Height - 200;
            int minX = 50;
            int minY = 100;

            toupeiraAtual.Location = new Point(
                random.Next(minX, maxX),
                random.Next(minY, maxY)
            );

            // Configura o cursor de martelo na toupeira
            toupeiraAtual.Cursor = new Cursor(sei_la.Properties.Resources.Thor_s_Hammer.Handle);

            // Adiciona o evento de clique - quando o jogador acerta a toupeira
            toupeiraAtual.Click += Toupeira_Click;

            // Adiciona a toupeira ao formulário
            this.Controls.Add(toupeiraAtual);

            // Traz a toupeira para frente (para ficar visível sobre o fundo)
            toupeiraAtual.BringToFront();
        }

        // Evento que ocorre quando o jogador clica na toupeira (acerta!)
        private void Toupeira_Click(object sender, EventArgs e)
        {
            // Aumenta a pontuação
            pontos += 10;

            // Diminui o número de toupeiras restantes
            toupeirasRestantes--;

            // Remove a toupeira clicada
            if (toupeiraAtual != null)
            {
                this.Controls.Remove(toupeiraAtual);
                toupeiraAtual.Dispose();
                toupeiraAtual = null;
            }

            // Mostra feedback visual de que acertou
            MessageBox.Show("Acertou! +10 pontos!", "Boa!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Atualiza o display com a nova pontuação
            AtualizarDisplay();
        }

        // Método que avança para o próximo nível
        private void AvancarNivel()
        {
            // Para o timer das toupeiras
            timerToupeira.Stop();

            // Aumenta o nível
            nivel++;

            // Verifica se o jogador completou todos os 30 níveis
            if (nivel > 30)
            {
                // Jogador venceu o jogo!
                MessageBox.Show("PARABÉNS! Você completou todos os 30 níveis!\n\n" +
                    "Pontuação final: " + pontos,
                    "VITÓRIA!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Volta para o menu principal
                this.Close();
                return;
            }

            // Reseta as toupeiras para o novo nível (aumenta a dificuldade)
            toupeirasRestantes = 10 + (nivel * 2); // Mais toupeiras a cada nível

            // Diminui o intervalo do timer (fica mais rápido a cada nível)
            int novoIntervalo = Math.Max(500, 1500 - (nivel * 30));
            timerToupeira.Interval = novoIntervalo;

            // Atualiza o título da janela
            this.Text = "Jogo da Toupeira - Nível " + nivel + " / 30";

            // Mostra mensagem de avanço de nível
            MessageBox.Show("Nível " + (nivel - 1) + " completo!\n\n" +
                "Preparando nível " + nivel + "...\n" +
                "Toupeiras: " + toupeirasRestantes + "\n" +
                "Velocidade aumentou!",
                "Nível Completo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Atualiza o display
            AtualizarDisplay();

            // Reinicia o timer para o próximo nível
            timerToupeira.Start();
        }

        // Método que atualiza os labels com as informações do jogo
        private void AtualizarDisplay()
        {
            lblNivel.Text = "Nível: " + nivel + " / 30";
            lblPontos.Text = "Pontos: " + pontos;
            lblRestantes.Text = "Toupeiras restantes: " + toupeirasRestantes;
        }

        // Evento que ocorre quando o formulário está fechando
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Para os timers para evitar erros
            timerToupeira.Stop();
            timerGif.Stop();

            // Libera os recursos dos timers
            timerToupeira.Dispose();
            timerGif.Dispose();
        }
    }
}