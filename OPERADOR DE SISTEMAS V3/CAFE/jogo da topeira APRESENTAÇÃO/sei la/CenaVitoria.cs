using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace sei_la
{
    // Cena original em estilo de console antigo. Tudo é desenhado com formas e cores:
    // a vitória funciona sem internet, codec, navegador ou instalação de outro programa.
    public sealed class CenaVitoria : Control
    {
        public const double DuracaoSegundos = 8.0;
        private readonly Timer animacao;
        private readonly Stopwatch relogio = new Stopwatch();
        private readonly Dictionary<Color, SolidBrush> pinceis = new Dictionary<Color, SolidBrush>();
        private readonly Font fonteTitulo = new Font("Consolas", 29, FontStyle.Bold, GraphicsUnit.Pixel);
        private readonly Font fonteLegenda = new Font("Consolas", 12, FontStyle.Bold, GraphicsUnit.Pixel);
        private readonly Font fonteRodape = new Font("Consolas", 11, FontStyle.Bold, GraphicsUnit.Pixel);

        private static readonly Color Ceu = Color.FromArgb(18, 22, 50);
        private static readonly Color Ouro = Color.FromArgb(255, 212, 83);
        private static readonly Color Creme = Color.FromArgb(255, 244, 203);
        private static readonly Color Verde = Color.FromArgb(112, 218, 109);

        public CenaVitoria()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Ceu;
            TabStop = false;
            AccessibleName = "Vitória: ilha conquistada, " + EstadoPartida.Meta + " de " + EstadoPartida.Meta + " toupeiras. Torna-te quem tu és.";
            animacao = new Timer();
            animacao.Interval = 33; // Aproximadamente 30 quadros por segundo.
            animacao.Tick += delegate { Invalidate(); };
        }

        // O relógio mede tempo real: se um quadro atrasar, a animação mantém a duração correta.
        public void Iniciar()
        {
            relogio.Restart();
            animacao.Start();
            Invalidate();
        }

        public void Parar()
        {
            animacao.Stop();
            relogio.Stop();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            RenderizarQuadro(e.Graphics, ClientRectangle, relogio.Elapsed.TotalSeconds);
        }

        // A mesma função alimenta a tela e a exportação em vídeo. O tempo recebido determina
        // todas as posições, permitindo gerar os mesmos quadros sem depender do relógio ou do mouse.
        public void RenderizarQuadro(Graphics g, Rectangle area, double segundos)
        {
            if (area.Width <= 0 || area.Height <= 0) return;
            GraphicsState estado = g.Save();
            try
            {
                g.SetClip(area);
                g.FillRectangle(Pincel(Ceu), area);
                // Coordenadas fixas 480 x 270; a escala uniforme preserva a arte em qualquer janela.
                float escala = Math.Min(area.Width / 480f, area.Height / 270f);
                g.TranslateTransform(area.Left + (area.Width - 480 * escala) / 2,
                    area.Top + (area.Height - 270 * escala) / 2);
                g.ScaleTransform(escala, escala);
                g.SmoothingMode = SmoothingMode.None;
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.Half;
                g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                double t = Math.Max(0, segundos) % DuracaoSegundos;

                DesenharCenario(g, t);
                DesenharPalmeira(g, 91, 181, false, t);
                DesenharPalmeira(g, 385, 185, true, t);

                // A toupeira aparece atrás da caixa; desenhar a frente por último cria profundidade.
                double revelacao = Suavizar((t - 0.35) / 1.15);
                int subir = (int)(revelacao * 45);
                int pulo = t > 1.5 ? (int)(Math.Sin((t - 1.5) * 4) * 3) : 0;
                DesenharToupeira(g, 222, 176 - subir + pulo);
                DesenharCaixa(g, 119, 180, 35);
                DesenharCaixa(g, 319, 180, 35);
                DesenharCaixa(g, 211, 174, 58);
                // Tampa sobe e se afasta nos primeiros quadros, como uma caixa de recompensa.
                int tampaX = 209 - (int)(revelacao * 32);
                int tampaY = 170 - (int)(Math.Sin(revelacao * Math.PI / 2) * 57);
                Bloco(g, Color.FromArgb(255, 185, 80), tampaX, tampaY, 62, 8);
                Bloco(g, Color.FromArgb(135, 65, 43), tampaX, tampaY + 6, 62, 4);

                if (t > 1.25)
                {
                    int flutuar = (int)(Math.Sin(t * 3.2) * 3);
                    DesenharTrofeu(g, 284, 130 + flutuar);
                    DesenharConfetes(g, t - 1.25);
                }

                // Duas passadas dão sombra às letras e mantêm a leitura mesmo no céu animado.
                TextoCentral(g, "VITÓRIA!", fonteTitulo, Ouro, 14);
                TextoCentral(g, "ILHA CONQUISTADA", fonteLegenda, Creme, 49);
                TextoCentral(g, "Torna-te quem tu és", fonteLegenda, Ouro, 233);
                TextoCentral(g, EstadoPartida.Meta + " / " + EstadoPartida.Meta + " TOUPEIRAS  //  MISSÃO CUMPRIDA", fonteRodape, Color.FromArgb(177, 214, 222), 252);
            }
            finally
            {
                g.Restore(estado);
            }
        }

        private void DesenharCenario(Graphics g, double t)
        {
            Bloco(g, Ceu, 0, 0, 480, 270);
            Bloco(g, Color.FromArgb(35, 35, 70), 0, 78, 480, 35);
            Bloco(g, Color.FromArgb(65, 44, 82), 0, 113, 480, 37);
            Bloco(g, Color.FromArgb(109, 63, 88), 0, 150, 480, 24);

            // Estrelas e um sol quadrado dão ao fundo a linguagem visual de jogos de 16 bits.
            for (int i = 0; i < 27; i++)
            {
                int x = (i * 137 + 19) % 470;
                int y = (i * 47 + 13) % 105;
                Color cor = Math.Sin(t * 1.8 + i) > 0.2 ? Creme : Color.FromArgb(91, 111, 145);
                Bloco(g, cor, x, y, 2, 2);
            }
            Bloco(g, Color.FromArgb(242, 150, 113), 365, 89, 46, 44);
            Bloco(g, Color.FromArgb(255, 197, 136), 370, 83, 36, 50);
            Bloco(g, Color.FromArgb(65, 44, 82), 364, 116, 48, 4);
            Bloco(g, Color.FromArgb(65, 44, 82), 364, 127, 48, 5);

            // Mar em faixas; pequenos reflexos deslocam-se sem usar uma textura externa.
            Bloco(g, Color.FromArgb(31, 102, 128), 0, 167, 480, 66);
            Bloco(g, Color.FromArgb(22, 74, 110), 0, 191, 480, 49);
            Bloco(g, Color.FromArgb(19, 49, 80), 0, 222, 480, 48);
            for (int i = 0; i < 16; i++)
            {
                int x = (int)((i * 73 + t * (i % 2 == 0 ? 11 : 7)) % 520) - 20;
                int y = 174 + (i * 19) % 53;
                Bloco(g, Color.FromArgb(64, 142, 157), x, y, 13 + i % 4 * 3, 2);
            }

            // A ilha é construída de baixo para cima: rocha, areia e grama.
            Bloco(g, Color.FromArgb(67, 50, 68), 104, 209, 282, 15);
            Bloco(g, Color.FromArgb(125, 79, 63), 83, 196, 317, 18);
            Bloco(g, Color.FromArgb(217, 155, 89), 71, 190, 337, 13);
            Bloco(g, Color.FromArgb(247, 204, 118), 82, 182, 314, 12);
            Bloco(g, Color.FromArgb(42, 126, 85), 91, 175, 296, 13);
            Bloco(g, Verde, 103, 172, 274, 5);
            for (int i = 0; i < 11; i++)
                Bloco(g, Color.FromArgb(251, 218, 143), 90 + i * 27, 199 + i % 3 * 3, 8, 3);
        }

        private void DesenharPalmeira(Graphics g, int x, int y, bool inverter, double t)
        {
            int sentido = inverter ? -1 : 1;
            int balanco = (int)Math.Round(Math.Sin(t * 1.3) * 2);
            for (int i = 0; i < 7; i++)
            {
                int px = x + sentido * i * 2;
                Bloco(g, Color.FromArgb(113, 70, 46), px, y - i * 8, 9, 10);
                Bloco(g, Color.FromArgb(199, 132, 64), px + 2, y - i * 8, 4, 8);
            }
            int topoX = x + sentido * 12 + balanco;
            int topoY = y - 51;
            Color folha = Color.FromArgb(42, 154, 94);
            Color luz = Color.FromArgb(108, 204, 105);
            // Blocos em degraus formam as folhas da palmeira.
            Bloco(g, folha, topoX - 28, topoY - 5, 60, 8);
            Bloco(g, luz, topoX - 20, topoY - 12, 45, 7);
            Bloco(g, folha, topoX - 37, topoY + 3, 20, 7);
            Bloco(g, folha, topoX + 22, topoY + 3, 21, 7);
            Bloco(g, folha, topoX - 42, topoY + 10, 13, 8);
            Bloco(g, folha, topoX + 36, topoY + 10, 11, 8);
            Bloco(g, luz, topoX - 4, topoY - 22, 10, 13);
            Bloco(g, folha, topoX + 4, topoY - 17, 14, 8);
            Bloco(g, Color.FromArgb(116, 69, 48), topoX, topoY + 2, 8, 8);
        }

        private void DesenharCaixa(Graphics g, int x, int y, int tamanho)
        {
            Color borda = Color.FromArgb(110, 52, 42);
            Color madeira = Color.FromArgb(199, 106, 56);
            Color claro = Color.FromArgb(244, 170, 79);
            Bloco(g, borda, x, y, tamanho, tamanho * 0.65f);
            Bloco(g, madeira, x + 4, y + 4, tamanho - 8, tamanho * 0.65f - 8);
            Bloco(g, claro, x + 2, y + 2, tamanho - 4, 3);
            Bloco(g, claro, x + 2, y + 2, 3, tamanho * 0.65f - 4);
            // Travessas em X, desenhadas em degraus para preservar o pixel art.
            for (int i = 0; i < tamanho / 5; i++)
            {
                float dy = i * 3;
                Bloco(g, claro, x + 5 + i * 4, y + 5 + dy, 5, 3);
                Bloco(g, claro, x + tamanho - 10 - i * 4, y + 5 + dy, 5, 3);
            }
        }

        private void DesenharToupeira(Graphics g, int x, int y)
        {
            Color marrom = Color.FromArgb(126, 77, 63);
            Color luz = Color.FromArgb(184, 120, 89);
            // Orelhas, cabeça, focinho e pequenas mãos compõem a mascote da conquista.
            Bloco(g, marrom, x - 3, y + 3, 12, 13);
            Bloco(g, marrom, x + 28, y + 3, 12, 13);
            Bloco(g, luz, x + 1, y + 6, 5, 6);
            Bloco(g, luz, x + 31, y + 6, 5, 6);
            Bloco(g, marrom, x + 3, y + 1, 30, 40);
            Bloco(g, marrom, x - 1, y + 11, 39, 26);
            Bloco(g, luz, x + 5, y + 7, 25, 26);
            Bloco(g, Creme, x + 7, y + 13, 7, 8);
            Bloco(g, Creme, x + 23, y + 13, 7, 8);
            Bloco(g, Ceu, x + 10, y + 16, 4, 5);
            Bloco(g, Ceu, x + 23, y + 16, 4, 5);
            Bloco(g, Color.FromArgb(235, 169, 137), x + 11, y + 23, 15, 8);
            Bloco(g, Ceu, x + 16, y + 22, 5, 4);
            Bloco(g, Creme, x + 16, y + 29, 5, 5);
            Bloco(g, luz, x - 8, y + 34, 12, 7);
            Bloco(g, luz, x + 33, y + 34, 12, 7);
        }

        private void DesenharTrofeu(Graphics g, int x, int y)
        {
            Color sombra = Color.FromArgb(193, 121, 46);
            // Pequeno brilho em cruz anuncia a recompensa.
            Bloco(g, Creme, x + 31, y - 10, 2, 12);
            Bloco(g, Creme, x + 26, y - 5, 12, 2);
            Bloco(g, sombra, x - 6, y + 4, 32, 14);
            Bloco(g, Ceu, x - 3, y + 7, 26, 7);
            Bloco(g, Ouro, x, y, 20, 19);
            Bloco(g, Ouro, x + 4, y + 19, 12, 5);
            Bloco(g, sombra, x + 8, y + 24, 5, 9);
            Bloco(g, Ouro, x + 3, y + 32, 16, 5);
            Bloco(g, Creme, x + 3, y + 3, 3, 12);
            Bloco(g, Color.FromArgb(255, 169, 58), x + 11, y + 5, 5, 9);
        }

        private void DesenharConfetes(Graphics g, double t)
        {
            Color[] cores = { Ouro, Verde, Color.FromArgb(95, 210, 230), Color.FromArgb(255, 113, 138) };
            for (int i = 0; i < 43; i++)
            {
                double queda = t * (23 + i % 7 * 3) + i * 31;
                int y = (int)(queda % 235);
                int x = (int)((i * 107 + Math.Sin(t * 2 + i) * 15 + 490) % 480);
                // Reserva o topo para o título: confete jamais cobre a leitura.
                if (y > 70 && y < 224)
                    Bloco(g, cores[i % cores.Length], x, y, i % 2 == 0 ? 4 : 2, i % 2 == 0 ? 2 : 4);
            }
        }

        private void TextoCentral(Graphics g, string texto, Font fonte, Color cor, float y)
        {
            SizeF tamanho = g.MeasureString(texto, fonte);
            float x = (480 - tamanho.Width) / 2;
            g.DrawString(texto, fonte, Pincel(Color.FromArgb(31, 23, 40)), x + 2, y + 2);
            g.DrawString(texto, fonte, Pincel(cor), x, y);
        }

        private void Bloco(Graphics g, Color cor, float x, float y, float largura, float altura)
        {
            g.FillRectangle(Pincel(cor), x, y, largura, altura);
        }

        // Reutilizar os pincéis reduz alocações por quadro. Dispose libera todos ao fechar o jogo.
        private SolidBrush Pincel(Color cor)
        {
            SolidBrush pincel;
            if (!pinceis.TryGetValue(cor, out pincel))
            {
                pincel = new SolidBrush(cor);
                pinceis.Add(cor, pincel);
            }
            return pincel;
        }

        private static double Suavizar(double valor)
        {
            valor = Math.Max(0, Math.Min(1, valor));
            return valor * valor * (3 - 2 * valor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                animacao.Stop();
                animacao.Dispose();
                relogio.Stop();
                fonteTitulo.Dispose();
                fonteLegenda.Dispose();
                fonteRodape.Dispose();
                foreach (SolidBrush pincel in pinceis.Values) pincel.Dispose();
                pinceis.Clear();
            }
            base.Dispose(disposing);
        }
    }
}
