using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace sei_la
{
    // Cenário original com formas angulares, madeira e pedra: clima de aventura de console.
    // Todos os desenhos usam 1100 x 690; a mesma transformação posiciona os controles.
    internal sealed class CenarioMenu : Panel
    {
        private bool interior;
        public bool Interior { get { return interior; } set { interior = value; Invalidate(true); } }
        public float EscalaCena { get { return Math.Max(0.01f, Math.Min(ClientSize.Width / 1100f, ClientSize.Height / 690f)); } }
        public RectangleF AreaCena
        {
            get
            {
                float escala = EscalaCena;
                return new RectangleF((Width - 1100 * escala) / 2, (Height - 690 * escala) / 2, 1100 * escala, 690 * escala);
            }
        }
        public Rectangle Mapear(Rectangle baseCena)
        {
            RectangleF area = AreaCena; float escala = EscalaCena;
            return Rectangle.Round(new RectangleF(area.X + baseCena.X * escala, area.Y + baseCena.Y * escala,
                baseCena.Width * escala, baseCena.Height * escala));
        }
        public CenarioMenu()
        {
            DoubleBuffered = true; ResizeRedraw = true;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(8, 13, 16);
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            RectangleF area = AreaCena;
            GraphicsState estado = e.Graphics.Save();
            e.Graphics.TranslateTransform(area.X, area.Y);
            e.Graphics.ScaleTransform(EscalaCena, EscalaCena);
            e.Graphics.SetClip(new Rectangle(0, 0, 1100, 690));
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            if (Interior) DesenharTemplo(e.Graphics); else DesenharIlha(e.Graphics);
            e.Graphics.Restore(estado);
        }
        private static void Retangulo(Graphics g, Color cor, int x, int y, int w, int h)
        { using (Brush b = new SolidBrush(cor)) g.FillRectangle(b, x, y, w, h); }
        private static void Poligono(Graphics g, Color cor, params Point[] pontos)
        { using (Brush b = new SolidBrush(cor)) g.FillPolygon(b, pontos); }
        private static void Oval(Graphics g, Color cor, int x, int y, int w, int h)
        { using (Brush b = new SolidBrush(cor)) g.FillEllipse(b, x, y, w, h); }
        private static void Linha(Graphics g, Color cor, float largura, int x, int y, int x2, int y2)
        { using (Pen p = new Pen(cor, largura)) g.DrawLine(p, x, y, x2, y2); }

        private static void DesenharIlha(Graphics g)
        {
            using (Brush ceu = new LinearGradientBrush(new Rectangle(0, 0, 1100, 690),
                Color.FromArgb(29, 91, 93), Color.FromArgb(115, 157, 75), 90f))
                g.FillRectangle(ceu, 0, 0, 1100, 690);
            // Silhuetas em camadas dão profundidade sem esconder os itens do menu.
            Poligono(g, Color.FromArgb(29, 76, 67), new Point(0, 285), new Point(165, 145), new Point(295, 260),
                new Point(455, 135), new Point(665, 305), new Point(905, 135), new Point(1100, 245), new Point(1100, 600), new Point(0, 600));
            Poligono(g, Color.FromArgb(47, 102, 57), new Point(0, 390), new Point(140, 270), new Point(350, 420),
                new Point(555, 290), new Point(790, 400), new Point(1000, 260), new Point(1100, 390), new Point(1100, 690), new Point(0, 690));
            for (int i = 0; i < 8; i++)
            {
                int x = i * 163 - 38;
                Poligono(g, Color.FromArgb(31, 58, 38), new Point(x, 0), new Point(x + 52, 0),
                    new Point(x + 25, 440), new Point(x + 80, 555), new Point(x - 25, 545));
                Linha(g, Color.FromArgb(88, 97, 43), 10, x + 31, 72, x + 6, 445);
            }
            Poligono(g, Color.FromArgb(164, 135, 65), new Point(0, 580), new Point(600, 415), new Point(780, 470),
                new Point(1100, 620), new Point(1100, 690), new Point(0, 690));
            Poligono(g, Color.FromArgb(188, 156, 81), new Point(350, 690), new Point(635, 445), new Point(729, 480), new Point(825, 690));
            // Fragmento de ruína atrás do menu e raízes nas bordas da ilha.
            Pilar(g, 0, 0, 100, 510, false);
            Pilar(g, 1015, 0, 85, 535, false);
            for (int i = 0; i < 5; i++)
                Folha(g, i * 240 - 75, 20 + (i % 2) * 35, 1.2f, i % 2 == 0);
            Folha(g, 1000, 370, 1.0f, false);
            Folha(g, 45, 590, 0.8f, true);
            using (Brush sombra = new LinearGradientBrush(new Rectangle(0, 270, 570, 360),
                Color.FromArgb(195, 8, 24, 18), Color.FromArgb(0, 8, 24, 18), 0f))
                g.FillRectangle(sombra, 0, 270, 570, 360);
            Placa(g);
            Caixa(g, 916, 553, 122);
            Caixa(g, 25, 610, 69);
            Toupeira(g);
            Linha(g, Color.FromArgb(76, 54, 25), 9, 0, 686, 1100, 686);
        }

        private static void Placa(Graphics g)
        {
            // A placa tem bordas irregulares, travessas e pregos de madeira.
            Poligono(g, Color.FromArgb(42, 24, 14), new Point(115, 71), new Point(932, 39), new Point(990, 216),
                new Point(940, 284), new Point(141, 263), new Point(92, 149));
            Poligono(g, Color.FromArgb(123, 57, 22), new Point(129, 75), new Point(920, 52), new Point(965, 212),
                new Point(934, 266), new Point(153, 248), new Point(111, 147));
            Poligono(g, Color.FromArgb(171, 84, 29), new Point(129, 75), new Point(920, 52), new Point(926, 70),
                new Point(136, 95), new Point(111, 147));
            Linha(g, Color.FromArgb(74, 30, 17), 7, 127, 157, 955, 141);
            Linha(g, Color.FromArgb(78, 34, 17), 6, 139, 222, 948, 226);
            Linha(g, Color.FromArgb(170, 91, 35), 3, 140, 106, 899, 85);
            Linha(g, Color.FromArgb(164, 76, 24), 3, 166, 245, 912, 247);
            foreach (Point p in new[] { new Point(153, 112), new Point(907, 90), new Point(169, 227), new Point(923, 235) })
            { Oval(g, Color.FromArgb(41, 25, 15), p.X, p.Y, 12, 12); Oval(g, Color.FromArgb(187, 151, 76), p.X + 2, p.Y + 2, 6, 5); }
            TextoDourado(g, "ILHA DA", new RectangleF(196, 65, 700, 72), 55, false);
            TextoDourado(g, "TOUPEIRA", new RectangleF(157, 117, 800, 111), 93, false);
            using (Font f = new Font("Georgia", 17, FontStyle.Bold, GraphicsUnit.Pixel))
            using (Brush b = new SolidBrush(Color.FromArgb(255, 230, 174)))
            using (StringFormat formato = new StringFormat { Alignment = StringAlignment.Center })
                g.DrawString("A GUERRA DO JARDIM", f, b, new RectangleF(160, 231, 800, 26), formato);
        }

        private static void Toupeira(Graphics g)
        {
            Oval(g, Color.FromArgb(105, 39, 31, 17), 575, 601, 350, 56);
            Poligono(g, Color.FromArgb(87, 45, 29), new Point(660, 441), new Point(795, 425), new Point(867, 548),
                new Point(846, 629), new Point(612, 626), new Point(613, 531));
            Poligono(g, Color.FromArgb(173, 100, 52), new Point(680, 476), new Point(781, 468), new Point(823, 605),
                new Point(655, 618), new Point(648, 549));
            Oval(g, Color.FromArgb(106, 56, 33), 602, 336, 75, 88);
            Oval(g, Color.FromArgb(199, 123, 82), 617, 352, 43, 51);
            Oval(g, Color.FromArgb(106, 56, 33), 805, 325, 73, 86);
            Oval(g, Color.FromArgb(199, 123, 82), 819, 340, 43, 52);
            Poligono(g, Color.FromArgb(126, 68, 38), new Point(636, 324), new Point(713, 291), new Point(800, 315),
                new Point(848, 379), new Point(826, 468), new Point(749, 510), new Point(651, 469), new Point(614, 394));
            Poligono(g, Color.FromArgb(161, 91, 47), new Point(636, 324), new Point(713, 291), new Point(766, 315),
                new Point(688, 349), new Point(649, 419), new Point(614, 394));
            Poligono(g, Color.FromArgb(217, 154, 93), new Point(642, 402), new Point(694, 371), new Point(783, 378),
                new Point(824, 421), new Point(790, 475), new Point(697, 483), new Point(654, 454));
            Oval(g, Color.Ivory, 667, 352, 51, 60); Oval(g, Color.Ivory, 752, 350, 51, 60);
            Oval(g, Color.FromArgb(35, 24, 20), 681, 369, 23, 31); Oval(g, Color.FromArgb(35, 24, 20), 765, 367, 23, 31);
            Oval(g, Color.White, 686, 369, 7, 9); Oval(g, Color.White, 770, 367, 7, 9);
            Poligono(g, Color.FromArgb(41, 27, 24), new Point(684, 415), new Point(736, 394), new Point(790, 416), new Point(739, 447));
            Linha(g, Color.FromArgb(82, 38, 26), 5, 705, 458, 777, 458);
            Retangulo(g, Color.FromArgb(255, 244, 197), 718, 456, 18, 29);
            Retangulo(g, Color.FromArgb(255, 244, 197), 739, 456, 18, 29);
            Poligono(g, Color.FromArgb(220, 157, 94), new Point(612, 547), new Point(656, 536), new Point(690, 565),
                new Point(677, 605), new Point(605, 609), new Point(585, 581));
            Poligono(g, Color.FromArgb(220, 157, 94), new Point(815, 544), new Point(854, 531), new Point(889, 568),
                new Point(874, 606), new Point(810, 608), new Point(792, 578));
            for (int i = 0; i < 3; i++)
            { Linha(g, Color.FromArgb(255, 230, 174), 6, 610 + i * 22, 591, 605 + i * 22, 612);
                Linha(g, Color.FromArgb(255, 230, 174), 6, 824 + i * 22, 590, 819 + i * 22, 611); }
        }

        private static void Folha(Graphics g, int x, int y, float tamanho, bool direita)
        {
            GraphicsState estado = g.Save();
            g.TranslateTransform(x, y); g.ScaleTransform(direita ? tamanho : -tamanho, tamanho);
            Poligono(g, Color.FromArgb(21, 64, 36), new Point(0, 0), new Point(110, -38), new Point(257, 34),
                new Point(181, 21), new Point(224, 72), new Point(133, 39), new Point(164, 91), new Point(81, 53), new Point(0, 0));
            Poligono(g, Color.FromArgb(71, 123, 40), new Point(0, 0), new Point(108, -24), new Point(227, 27), new Point(114, 10));
            Linha(g, Color.FromArgb(116, 148, 55), 4, 0, 0, 213, 32); g.Restore(estado);
        }
        private static void Caixa(Graphics g, int x, int y, int lado)
        {
            Retangulo(g, Color.FromArgb(75, 38, 18), x - 6, y - 6, lado + 12, lado + 12);
            Retangulo(g, Color.FromArgb(174, 89, 32), x, y, lado, lado);
            Retangulo(g, Color.FromArgb(105, 50, 21), x + 12, y + 12, lado - 24, lado - 24);
            Linha(g, Color.FromArgb(229, 153, 61), 12, x + 8, y + 8, x + lado - 8, y + lado - 8);
            Linha(g, Color.FromArgb(220, 140, 51), 12, x + lado - 8, y + 8, x + 8, y + lado - 8);
            Linha(g, Color.FromArgb(248, 183, 83), 5, x, y, x + lado, y);
        }

        private static void DesenharTemplo(Graphics g)
        {
            Retangulo(g, Color.FromArgb(14, 29, 42), 0, 0, 1100, 690);
            for (int y = 0; y < 690; y += 65)
                for (int x = -70; x < 1100; x += 140)
                {
                    int xx = x + (y / 65 % 2) * 70;
                    Retangulo(g, Color.FromArgb(27 + (x + 70) % 17, 51, 66), xx + 3, y + 3, 134, 59);
                    Linha(g, Color.FromArgb(54, 82, 91), 2, xx + 5, y + 5, xx + 134, y + 5);
                }
            Pilar(g, 60, 0, 164, 690, true); Pilar(g, 876, 0, 164, 690, true);
            Retangulo(g, Color.FromArgb(6, 17, 25), 244, 62, 612, 566);
            Retangulo(g, Color.FromArgb(16, 29, 39), 253, 72, 594, 545);
            Linha(g, Color.FromArgb(79, 102, 103), 5, 247, 64, 853, 64);
            Linha(g, Color.FromArgb(46, 69, 77), 4, 247, 65, 247, 623);
            Linha(g, Color.FromArgb(7, 17, 24), 8, 850, 66, 850, 625);
            Tocha(g, 173, 324); Tocha(g, 927, 324);
            for (int i = 0; i < 3; i++)
                Retangulo(g, Color.FromArgb(43 - i * 8, 58 - i * 8, 59 - i * 8), 230 - i * 20, 627 + i * 21, 640 + i * 40, 20);
        }
        private static void Pilar(Graphics g, int x, int y, int w, int h, bool rostos)
        {
            Retangulo(g, Color.FromArgb(19, 37, 44), x, y, w, h);
            for (int yy = y; yy < y + h; yy += 87)
            {
                Retangulo(g, Color.FromArgb(42, 63, 62), x + 6, yy + 3, w - 12, 80);
                Linha(g, Color.FromArgb(71, 86, 73), 4, x + 9, yy + 5, x + w - 10, yy + 5);
                Linha(g, Color.FromArgb(17, 30, 34), 5, x + w - 9, yy + 8, x + w - 9, yy + 80);
            }
            if (!rostos) return;
            foreach (int yy in new[] { y + 35, y + 477 })
            {
                Retangulo(g, Color.FromArgb(22, 44, 51), x + 18, yy, w - 36, 138);
                Retangulo(g, Color.FromArgb(8, 23, 30), x + 36, yy + 31, 31, 37);
                Retangulo(g, Color.FromArgb(8, 23, 30), x + w - 67, yy + 31, 31, 37);
                Poligono(g, Color.FromArgb(70, 91, 85), new Point(x + w / 2, yy + 57), new Point(x + w / 2 - 17, yy + 90), new Point(x + w / 2 + 17, yy + 90));
                for (int i = 0; i < 4; i++) Retangulo(g, Color.FromArgb(6, 23, 27), x + 40 + i * 23, yy + 108, 13, 19);
            }
        }
        private static void Tocha(Graphics g, int x, int y)
        {
            for (int i = 4; i > 0; i--) Oval(g, Color.FromArgb(12, 255, 127, 18), x - i * 24, y - i * 24, i * 48, i * 48);
            Poligono(g, Color.FromArgb(187, 46, 12), new Point(x - 38, y + 12), new Point(x - 48, y - 22),
                new Point(x - 18, y - 82), new Point(x - 11, y - 45), new Point(x + 13, y - 108), new Point(x + 27, y - 44), new Point(x + 43, y - 19), new Point(x + 31, y + 15));
            Poligono(g, Color.FromArgb(255, 151, 25), new Point(x - 27, y + 9), new Point(x - 12, y - 48),
                new Point(x, y - 30), new Point(x + 12, y - 70), new Point(x + 30, y - 9), new Point(x + 17, y + 15));
            Poligono(g, Color.FromArgb(255, 234, 125), new Point(x - 12, y + 8), new Point(x + 2, y - 29), new Point(x + 18, y + 11));
            Poligono(g, Color.FromArgb(78, 79, 61), new Point(x - 48, y + 15), new Point(x + 48, y + 15), new Point(x + 30, y + 54), new Point(x - 29, y + 54));
            Linha(g, Color.FromArgb(174, 139, 73), 7, x - 48, y + 16, x + 48, y + 16);
            Retangulo(g, Color.FromArgb(62, 56, 42), x - 10, y + 54, 20, 70);
        }
        internal static void TextoDourado(Graphics g, string texto, RectangleF area, float tamanho, bool destaque, bool esquerda = false)
        {
            using (FontFamily familia = new FontFamily("Arial Black"))
            using (StringFormat formato = new StringFormat { Alignment = esquerda ? StringAlignment.Near : StringAlignment.Center, LineAlignment = StringAlignment.Center })
            using (GraphicsPath letras = new GraphicsPath())
            using (Pen borda = new Pen(Color.FromArgb(55, 24, 8), 6) { LineJoin = LineJoin.Round })
            using (Brush sombra = new SolidBrush(Color.FromArgb(65, 35, 7)))
            using (Brush ouro = new LinearGradientBrush(area, destaque ? Color.FromArgb(255, 255, 145) : Color.FromArgb(255, 236, 66), Color.FromArgb(243, 131, 10), 90f))
            {
                letras.AddString(texto, familia, (int)FontStyle.Regular, tamanho, area, formato);
                GraphicsState estado = g.Save(); g.TranslateTransform(4, 6); g.FillPath(sombra, letras); g.Restore(estado);
                g.DrawPath(borda, letras); g.FillPath(ouro, letras);
            }
        }
    }

    // Continua sendo Button: Tab, Enter, atalhos e leitores de tela funcionam normalmente.
    internal sealed class BotaoAventura : Button
    {
        private bool apontado, pressionado;
        public BotaoAventura()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            FlatStyle = FlatStyle.Flat; FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = Color.Transparent; FlatAppearance.MouseDownBackColor = Color.Transparent;
            BackColor = Color.Transparent; ForeColor = Color.Gold; UseVisualStyleBackColor = false; Cursor = Cursors.Hand;
            TextAlign = ContentAlignment.MiddleLeft;
        }
        protected override void OnMouseEnter(EventArgs e) { apontado = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { apontado = false; pressionado = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnGotFocus(EventArgs e) { Invalidate(); base.OnGotFocus(e); }
        protected override void OnLostFocus(EventArgs e) { Invalidate(); base.OnLostFocus(e); }
        protected override void OnMouseDown(MouseEventArgs e) { pressionado = true; Invalidate(); base.OnMouseDown(e); }
        protected override void OnMouseUp(MouseEventArgs e) { pressionado = false; Invalidate(); base.OnMouseUp(e); }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Width < 10 || Height < 10) return;
            bool ativo = Enabled && (apontado || Focused);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            float seta = Height * 0.36f;
            if (ativo)
                using (Brush b = new SolidBrush(Color.FromArgb(91, 238, 56)))
                    e.Graphics.FillPolygon(b, new[] { new PointF(4, Height * 0.25f), new PointF(4 + seta, Height * 0.5f), new PointF(4, Height * 0.75f) });
            RectangleF area = new RectangleF(seta + 9 + (pressionado ? 2 : 0), pressionado ? 2 : 0, Width - seta - 14, Height - 4);
            CenarioMenu.TextoDourado(e.Graphics, Text, area, Math.Min(Height * 0.64f, area.Width / Math.Max(1, Text.Length) * 1.4f), ativo, true);
        }
    }
}
