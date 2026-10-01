using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Botao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (Button botao in Controls.OfType<Button>())
            {
                botao.Click += BotaoCor_Click;
            }
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
        }

        private void BotaoCor_Click(object sender, EventArgs e)
        {
            Button botao = sender as Button;
            if (botao == null)
            {
                return;
            }

            Color cor;
            switch (botao.Text.Trim().ToLowerInvariant())
            {
                case "verde": cor = Color.Green; break;
                case "roxo": cor = Color.Purple; break;
                case "amarelo": cor = Color.Yellow; break;
                case "laranja": cor = Color.Orange; break;
                case "rosa": cor = Color.HotPink; break;
                case "branco": cor = Color.White; break;
                case "ciano": cor = Color.Cyan; break;
                case "preto": cor = Color.Black; break;
                case "azul": cor = Color.Blue; break;
                default: return;
            }

            pictureBox1.BackColor = cor;
        }
    }
}
