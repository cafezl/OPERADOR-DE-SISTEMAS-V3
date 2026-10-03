using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paula_vado
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
            button7.Text = "roxo";
            button8.Text = "preto";
            button9.Text = "branco";
            AdicionarCoresDoParceiro();
        }

        private void AdicionarCoresDoParceiro()
        {
            ClientSize = new Size(582, 620);

            // [Deus da Guerra -> CAFE: opção rosa que faltava no seletor de cores]
            AdicionarBotaoExtra("rosa", Color.HotPink, new Point(146, 525));

            // [Deus da Guerra -> CAFE: opção ciano que faltava no seletor de cores]
            AdicionarBotaoExtra("ciano", Color.Cyan, new Point(338, 525));
        }

        private void AdicionarBotaoExtra(string nomeCor, Color cor, Point local)
        {
            Button botao = new Button
            {
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                ForeColor = ForeColor,
                Location = local,
                Name = "btnCor" + nomeCor,
                Size = new Size(91, 74),
                Tag = cor,
                Text = nomeCor,
                UseVisualStyleBackColor = false
            };
            botao.FlatAppearance.BorderSize = 5;
            botao.Click += BotaoExtra_Click;
            Controls.Add(botao);
        }

        private void BotaoExtra_Click(object sender, EventArgs e)
        {
            Button botao = sender as Button;
            if (botao != null && botao.Tag is Color)
            {
                AplicarCor((Color)botao.Tag);
            }
        }

        private void AplicarCor(Color cor)
        {
            pic_pic.BackColor = cor;
            pic_pic.BorderStyle = BorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AplicarCor(Color.Red);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AplicarCor(Color.Lime);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AplicarCor(Color.Yellow);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AplicarCor(Color.Blue);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AplicarCor(Color.Green);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AplicarCor(Color.Purple);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AplicarCor(Color.Orange);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AplicarCor(Color.White);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AplicarCor(Color.Black);
        }
    }
}
