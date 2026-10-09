using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cadastro
{
    public partial class Frm_Cadastro: Form
    {
        public Frm_Cadastro()
        {
            InitializeComponent();
        }

        private void Frm_Cadastro_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void rad_tema1_CheckedChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.imagem1;
        }

        private void rad_tema2_CheckedChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.imagem2;
        }

        private void rad_tema3_CheckedChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.imagem4;
        }

        private void txt_Nome_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Nome_Click(object sender, EventArgs e)
        {
            lbl_Resultado.Text = txt_Nome.Text; //recebendo o nome digitado


        }

        private void btn_Sobrenome_Click(object sender, EventArgs e)
        {
            lbl_Resultado.Text = txt_Sobrenome.Text;
        }

        private void btn_Idade_Click(object sender, EventArgs e)
        {
            lbl_Resultado.Text = txt_Idade.Text;
        }

        private void btn_Bairro_Click(object sender, EventArgs e)
        {
            lbl_Resultado.Text = txt_Bairro.Text;
        }

        private void btn_Celular_Click(object sender, EventArgs e)
        {
            lbl_Resultado.Text = txt_Celular.Text;
        }

        private void btn_Email_Click(object sender, EventArgs e)
        {
            lbl_Resultado.Text = txt_Email.Text;
        }

        private void btn_DadosCompletos_Click(object sender, EventArgs e)
        {
            lbl_Resultado.Text = txt_Nome.Text + " " + txt_Sobrenome.Text + "\n" + txt_Idade.Text + "\n" + txt_Bairro.Text + "\n" + txt_Celular.Text + "\n" + txt_Email.Text; 
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            lbl_Resultado.Text = "";
            txt_Bairro.Clear();
            txt_Celular.Clear();
            txt_Nome.Clear();
            txt_Sobrenome.Clear();
            txt_Idade.Clear();
            txt_Email.Clear();
        }

        private void btn_ativar_Click(object sender, EventArgs e)
        {
            grp_Temas.Enabled = true;

           
        }

        private void btn_Desativar_Click(object sender, EventArgs e)
        {
           
        }
    }
}
