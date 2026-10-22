using System;
using System.Windows.Forms;

namespace sei_la
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // O loop do Windows entrega cliques, teclas e timers aos formulários.
            // O finally libera o áudio mesmo se a janela principal for fechada.
            try { Application.Run(new Form1()); }
            finally { AudioRetro.Liberar(); }
        }
    }
}
