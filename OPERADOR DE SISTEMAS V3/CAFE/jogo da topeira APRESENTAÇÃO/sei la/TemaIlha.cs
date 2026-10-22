using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace sei_la
{
    // Uma paleta e um conjunto de ícones para todas as ações da ilha.
    internal static class TemaIlha
    {
        private static readonly ConditionalWeakTable<Button, Recursos> recursos =
            new ConditionalWeakTable<Button, Recursos>();

        public static void Aplicar(Button botao, string icone, bool principal = false)
        {
            AtualizarIcone(botao, icone, principal ? Color.FromArgb(28, 43, 32) : Color.FromArgb(255, 210, 110));
            Recursos recurso = recursos.GetValue(botao, delegate { return new Recursos(); });
            if (recurso.Fonte == null) recurso.Fonte = new Font("Consolas", 9, FontStyle.Bold);
            botao.Font = recurso.Fonte;
            botao.FlatStyle = FlatStyle.Flat;
            botao.FlatAppearance.BorderSize = 0;
            botao.FlatAppearance.BorderColor = principal ? Color.FromArgb(255, 219, 132) : Color.FromArgb(74, 115, 93);
            botao.BackColor = principal ? Color.FromArgb(247, 192, 77) : Color.FromArgb(22, 53, 42);
            botao.ForeColor = principal ? Color.FromArgb(28, 43, 32) : Color.FromArgb(241, 245, 231);
            botao.FlatAppearance.MouseOverBackColor = principal ? Color.FromArgb(255, 215, 115) : Color.FromArgb(36, 75, 57);
            botao.FlatAppearance.MouseDownBackColor = principal ? Color.FromArgb(219, 161, 50) : Color.FromArgb(13, 37, 29);
            botao.Padding = new Padding(12, 0, 10, 0);
            botao.TextImageRelation = TextImageRelation.ImageBeforeText;
            botao.ImageAlign = ContentAlignment.MiddleLeft;
            botao.TextAlign = ContentAlignment.MiddleCenter;
            botao.Cursor = Cursors.Hand;
            botao.UseVisualStyleBackColor = false;
            if (!recurso.BordaAplicada)
            {
                recurso.BordaAplicada = true;
                botao.Paint += delegate(object sender, PaintEventArgs e)
                {
                    Button alvo = (Button)sender;
                    if (alvo.ClientSize.Width < 8 || alvo.ClientSize.Height < 8) return;
                    e.Graphics.SmoothingMode = SmoothingMode.None;
                    Color luz = alvo.Enabled ? Color.FromArgb(255, 226, 142) : Color.Gray;
                    Color sombra = alvo.Enabled ? Color.FromArgb(10, 28, 22) : Color.DarkGray;
                    using (Pen topo = new Pen(luz, 3))
                    using (Pen baseEscura = new Pen(sombra, 3))
                    using (Pen detalhe = new Pen(principal ? Color.FromArgb(197, 127, 32) : Color.FromArgb(70, 110, 82), 1))
                    {
                        e.Graphics.DrawLine(topo, 2, 2, alvo.Width - 3, 2);
                        e.Graphics.DrawLine(topo, 2, 2, 2, alvo.Height - 3);
                        e.Graphics.DrawLine(baseEscura, 2, alvo.Height - 3, alvo.Width - 3, alvo.Height - 3);
                        e.Graphics.DrawLine(baseEscura, alvo.Width - 3, 2, alvo.Width - 3, alvo.Height - 3);
                        e.Graphics.DrawRectangle(detalhe, 5, 5, alvo.Width - 11, alvo.Height - 11);
                    }
                };
            }
        }

        public static void AtualizarIcone(Button botao, string icone, Color cor)
        {
            Recursos recurso;
            if (!recursos.TryGetValue(botao, out recurso))
            {
                recurso = new Recursos();
                recursos.Add(botao, recurso);
                Recursos dono = recurso;
                botao.Disposed += delegate { dono.Dispose(); };
            }
            Image antiga = recurso.Imagem;
            recurso.Imagem = CriarIcone(icone, cor);
            botao.Image = recurso.Imagem;
            if (antiga != null) antiga.Dispose();
        }

        public static Bitmap CriarIcone(string nome)
        {
            return CriarIcone(nome, Color.FromArgb(255, 210, 110));
        }

        // Ícones vetoriais são desenhados localmente; não dependem de fontes de emoji.
        public static Bitmap CriarIcone(string nome, Color cor)
        {
            Bitmap imagem = new Bitmap(24, 24);
            using (Graphics g = Graphics.FromImage(imagem))
            using (Pen p = new Pen(cor, 2))
            using (Brush b = new SolidBrush(cor))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                p.StartCap = p.EndCap = LineCap.Round;
                switch (nome)
                {
                    case "jogar":
                        g.FillPolygon(b, new[] { new Point(7, 4), new Point(21, 12), new Point(7, 20) }); break;
                    case "continuar":
                        g.DrawRectangle(p, 3, 3, 17, 17);
                        g.FillPolygon(b, new[] { new Point(9, 7), new Point(16, 12), new Point(9, 17) }); break;
                    case "chave":
                        g.DrawEllipse(p, 2, 3, 9, 9); g.DrawLine(p, 10, 11, 20, 21);
                        g.DrawLine(p, 16, 17, 19, 14); g.DrawLine(p, 19, 20, 22, 17); break;
                    case "opcoes":
                        g.DrawEllipse(p, 6, 6, 12, 12); g.DrawEllipse(p, 10, 10, 4, 4);
                        for (int i = 0; i < 8; i++) { double a = i * Math.PI / 4;
                            g.DrawLine(p, 12 + (float)Math.Cos(a) * 8, 12 + (float)Math.Sin(a) * 8,
                                12 + (float)Math.Cos(a) * 10, 12 + (float)Math.Sin(a) * 10); } break;
                    case "pausa":
                        g.FillRectangle(b, 5, 4, 5, 16); g.FillRectangle(b, 14, 4, 5, 16); break;
                    case "som": case "mudo":
                        g.FillPolygon(b, new[] { new Point(2, 9), new Point(7, 9), new Point(12, 4),
                            new Point(12, 20), new Point(7, 15), new Point(2, 15) });
                        if (nome == "som") { g.DrawArc(p, 7, 3, 14, 18, -55, 110); g.DrawArc(p, 8, 7, 9, 10, -55, 110); }
                        else { g.DrawLine(p, 16, 8, 22, 16); g.DrawLine(p, 22, 8, 16, 16); } break;
                    case "menu":
                        g.DrawLines(p, new[] { new Point(2, 11), new Point(12, 3), new Point(22, 11) });
                        g.DrawRectangle(p, 6, 11, 12, 10); g.DrawRectangle(p, 10, 15, 4, 6); break;
                    case "repetir":
                        g.DrawArc(p, 4, 4, 16, 16, -80, 290);
                        g.FillPolygon(b, new[] { new Point(2, 9), new Point(9, 9), new Point(5, 15) }); break;
                    case "video":
                        g.DrawRectangle(p, 2, 4, 20, 16);
                        g.FillPolygon(b, new[] { new Point(9, 8), new Point(16, 12), new Point(9, 16) }); break;
                    case "trofeu":
                        g.DrawLines(p, new[] { new Point(6, 3), new Point(18, 3), new Point(16, 13), new Point(12, 16), new Point(8, 13), new Point(6, 3) });
                        g.DrawArc(p, 1, 4, 7, 9, 90, 180); g.DrawArc(p, 16, 4, 7, 9, -90, 180);
                        g.DrawLine(p, 12, 16, 12, 21); g.DrawLine(p, 7, 21, 17, 21); break;
                    default:
                        g.DrawEllipse(p, 3, 3, 18, 18); g.DrawEllipse(p, 8, 8, 8, 8);
                        g.DrawLine(p, 12, 1, 12, 5); g.DrawLine(p, 19, 12, 23, 12); break;
                }
            }
            return imagem;
        }

        // Cada botão libera somente os recursos que esta classe criou para ele.
        private sealed class Recursos : IDisposable
        {
            public Image Imagem;
            public Font Fonte;
            public bool BordaAplicada;
            public void Dispose()
            {
                if (Imagem != null) { Imagem.Dispose(); Imagem = null; }
                if (Fonte != null) { Fonte.Dispose(); Fonte = null; }
            }
        }
    }
}
