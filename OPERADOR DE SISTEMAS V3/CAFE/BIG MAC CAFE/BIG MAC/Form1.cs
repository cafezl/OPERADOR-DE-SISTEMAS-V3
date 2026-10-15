using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIG_MAC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "McDonald's - Pedidos";
            Txt_testo.Clear();
            Txt_testo.ReadOnly = false; // Começa editável
        }

        // Botão MacPedido - Salvar pedido
        // Botão MacPedido - Salvar pedido
        private void button1_Click(object sender, EventArgs e)
        {
            if (Txt_testo.Text == "")
            {
                MessageBox.Show("Digite ou adicione itens ao pedido primeiro!", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Caminho da pasta PEDIDOS
            string pasta = @"C:\Users\DB\Desktop\OPERADOR-DE-SISTEMAS-V3\OPERADOR DE SISTEMAS V3\CAFE\BIG MAC CAFE\PEDIDOS";

            // Cria a pasta se não existir
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            // Salva o arquivo com data e hora no nome
            string arquivo = pasta + @"\pedido_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".txt";
            File.WriteAllText(arquivo, Txt_testo.Text);

            Txt_testo.Clear();
            Txt_testo.ReadOnly = false;
            MessageBox.Show("Pedido realizado com sucesso!!!\nSalvo em: " + arquivo);
        }

        // Label1_Click (vazio)
        private void label1_Click(object sender, EventArgs e)
        {
        }

        // PictureBox1_Click - Big Mac (SEGUNDA)
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Txt_testo.Text += "Big Mac - R$ 18,90" + Environment.NewLine;
            Txt_testo.ReadOnly = true; // Bloqueia edição manual após clicar
        }

        // PictureBox2_Click - Quarteirão (QUINTA)
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Txt_testo.Text += "Quarteirão - R$ 20,50" + Environment.NewLine;
            Txt_testo.ReadOnly = true; // Bloqueia edição manual após clicar
        }

        // PictureBox3_Click - Cheddar McMelt (TERÇA)
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Txt_testo.Text += "Cheddar McMelt - R$ 17,90" + Environment.NewLine;
            Txt_testo.ReadOnly = true; // Bloqueia edição manual após clicar
        }

        // PictureBox4_Click - McChicken Duplo (QUARTA)
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Txt_testo.Text += "McChicken Duplo - R$ 15,90" + Environment.NewLine;
            Txt_testo.ReadOnly = true; // Bloqueia edição manual após clicar
        }

        // PictureBox5_Click - Big Mac (SEXTA)
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Txt_testo.Text += "Big Mac - R$ 18,90" + Environment.NewLine;
            Txt_testo.ReadOnly = true; // Bloqueia edição manual após clicar
        }

        // PictureBox6_Click - Combo (SÁBADO)
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Txt_testo.Text += "Combo Completo - R$ 29,90" + Environment.NewLine;
            Txt_testo.ReadOnly = true; // Bloqueia edição manual após clicar
        }

        // Label2_Click - Quarteirão
        private void label2_Click(object sender, EventArgs e)
        {
            Txt_testo.Text += "Quarteirão - R$ 20,50" + Environment.NewLine;
            Txt_testo.ReadOnly = true;
        }

        // Label3_Click - Cheddar McMelt
        private void label3_Click(object sender, EventArgs e)
        {
            Txt_testo.Text += "Cheddar McMelt - R$ 17,90" + Environment.NewLine;
            Txt_testo.ReadOnly = true;
        }

        // Label4_Click - McChicken Duplo
        private void label4_Click(object sender, EventArgs e)
        {
            Txt_testo.Text += "McChicken Duplo - R$ 15,90" + Environment.NewLine;
            Txt_testo.ReadOnly = true;
        }

        // Label5_Click - Big Mac (Sexta)
        private void label5_Click(object sender, EventArgs e)
        {
            Txt_testo.Text += "Big Mac - R$ 18,90" + Environment.NewLine;
            Txt_testo.ReadOnly = true;
        }

        // Label6_Click - Combo
        private void label6_Click(object sender, EventArgs e)
        {
            Txt_testo.Text += "Combo Completo - R$ 29,90" + Environment.NewLine;
            Txt_testo.ReadOnly = true;
        }
    }
}