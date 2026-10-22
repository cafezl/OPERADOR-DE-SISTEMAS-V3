using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace sei_la
{
    // Cursores nativos não precisam de uma janela seguindo o mouse nem de Cursor.Hide().
    // A mão segura a ponta do cabo; o pivô da rotação fica ali e o acerto fica na cabeça.
    internal sealed class MarteloCursor : IDisposable
    {
        private readonly List<Cursor> quadros = new List<Cursor>();
        private readonly List<IntPtr> handles = new List<IntPtr>();
        public Cursor Repouso { get { return quadros.Count == 0 ? Cursors.Cross : quadros[0]; } }

        public MarteloCursor()
        {
            try
            {
                foreach (float angulo in new float[] { -25, -38, 16, 6, -25 })
                    AdicionarQuadro(angulo);
            }
            catch (Win32Exception)
            {
                // Um computador sem suporte ao cursor colorido ainda pode jogar com a mira.
                Dispose();
            }
        }

        public Cursor Quadro(int indice)
        {
            return quadros.Count == 0 ? Cursors.Cross : quadros[Math.Max(0, Math.Min(indice, quadros.Count - 1))];
        }

        private void AdicionarQuadro(float angulo)
        {
            const int tamanho = 128;
            using (Bitmap imagem = new Bitmap(tamanho, tamanho, PixelFormat.Format32bppArgb))
            using (Graphics desenho = Graphics.FromImage(imagem))
            {
                desenho.SmoothingMode = SmoothingMode.AntiAlias;
                desenho.Clear(Color.Transparent);
                // A origem (64,108) é a extremidade inferior do cabo, junto à mão.
                desenho.TranslateTransform(64, 108);
                desenho.RotateTransform(angulo);
                using (Pen contorno = new Pen(Color.FromArgb(40, 27, 20), 17))
                    desenho.DrawLine(contorno, 0, -4, 0, -66);
                using (Pen madeira = new Pen(Color.FromArgb(163, 88, 39), 11))
                    desenho.DrawLine(madeira, 0, -4, 0, -66);
                using (Pen fita = new Pen(Color.FromArgb(240, 176, 91), 2))
                    for (int y = -17; y > -52; y -= 10) desenho.DrawLine(fita, -5, y, 5, y - 4);
                Rectangle cabeca = new Rectangle(-23, -86, 46, 30);
                using (Brush metal = new LinearGradientBrush(cabeca, Color.WhiteSmoke, Color.SlateGray, 90))
                    desenho.FillRectangle(metal, cabeca);
                using (Pen borda = new Pen(Color.FromArgb(31, 42, 56), 3))
                    desenho.DrawRectangle(borda, cabeca);
                using (Pen luz = new Pen(Color.White, 3))
                    desenho.DrawLine(luz, -18, -81, 17, -81);
                // A pequena mão está na ponta: visualmente o martelo deixa de flutuar pelo meio.
                using (Brush mao = new SolidBrush(Color.FromArgb(243, 184, 120)))
                    desenho.FillEllipse(mao, -11, -12, 22, 18);
                using (Pen bordaMao = new Pen(Color.FromArgb(75, 40, 23), 2))
                {
                    desenho.DrawEllipse(bordaMao, -11, -12, 22, 18);
                    desenho.DrawLine(bordaMao, -6, -6, 5, -6);
                    desenho.DrawLine(bordaMao, -6, -1, 5, -1);
                }
                // O hotspot é o centro da cabeça: é ali que o clique realmente acertará.
                PointF[] ponta = { new PointF(0, -71) };
                using (Matrix matriz = desenho.Transform) matriz.TransformPoints(ponta);
                int x = Math.Max(0, Math.Min(tamanho - 1, (int)Math.Round(ponta[0].X)));
                int yHotspot = Math.Max(0, Math.Min(tamanho - 1, (int)Math.Round(ponta[0].Y)));
                CriarCursor(imagem, x, yHotspot);
            }
        }

        private void CriarCursor(Bitmap imagem, int x, int y)
        {
            // Copiamos o ícone para um cursor com hotspot próprio e liberamos as cópias GDI.
            IntPtr icone = imagem.GetHicon();
            IconInfo info = new IconInfo();
            try
            {
                if (!GetIconInfo(icone, out info)) throw new Win32Exception();
                info.Icone = false;
                info.X = x;
                info.Y = y;
                IntPtr cursor = CreateIconIndirect(ref info);
                if (cursor == IntPtr.Zero) throw new Win32Exception();
                handles.Add(cursor);
                quadros.Add(new Cursor(cursor));
            }
            finally
            {
                if (info.Mascara != IntPtr.Zero) DeleteObject(info.Mascara);
                if (info.Cor != IntPtr.Zero) DeleteObject(info.Cor);
                DestroyIcon(icone);
            }
        }

        public void Dispose()
        {
            foreach (Cursor cursor in quadros) cursor.Dispose();
            quadros.Clear();
            // Cursor(IntPtr) não assume posse do handle; a classe que o criou o destrói.
            foreach (IntPtr handle in handles) DestroyIcon(handle);
            handles.Clear();
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct IconInfo
        {
            [MarshalAs(UnmanagedType.Bool)] public bool Icone;
            public int X, Y;
            public IntPtr Mascara, Cor;
        }
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetIconInfo(IntPtr icone, out IconInfo info);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr CreateIconIndirect(ref IconInfo info);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DestroyIcon(IntPtr handle);
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteObject(IntPtr handle);
    }
}
