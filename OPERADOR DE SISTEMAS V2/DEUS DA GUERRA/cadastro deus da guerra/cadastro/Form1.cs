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

            btn_Desativar.Enabled = true;
            btn_Limpar.Enabled = true;
            btn_Nome.Enabled = true;
            btn_Sobrenome.Enabled = true;
            btn_Idade.Enabled = true;
            btn_Bairro.Enabled = true;
            btn_Celular.Enabled = true;
            btn_Email.Enabled = true;
            btn_DadosCompletos.Enabled = true;

            lbl_DadosP.Enabled = true;
            lbl_Nome.Enabled = true;
            lbl_Sobrenome.Enabled = true;
            lbl_Idade.Enabled = true;
            lbl_Bairro.Enabled = true;
            lbl_Celular.Enabled = true;
            lbl_Email.Enabled = true;
            lbl_ConfirmaçãoDa.Enabled = true;
            lbl_Resultado.Enabled = true;

            txt_Nome.Enabled = true;
            txt_Sobrenome.Enabled = true;
            txt_Idade.Enabled = true;
            txt_Bairro.Enabled = true;
            txt_Celular.Enabled = true;
            txt_Email.Enabled = true;
        }

        private void btn_Desativar_Click(object sender, EventArgs e)
        {
            grp_Temas.Enabled = false;

            btn_Desativar.Enabled = false;
            btn_ativar.Enabled = true;
            btn_Limpar.Enabled = false;
            btn_Nome.Enabled = false;
            btn_Sobrenome.Enabled = false;
            btn_Idade.Enabled = false;
            btn_Bairro.Enabled = false;
            btn_Celular.Enabled = false;
            btn_Email.Enabled = false;
            btn_DadosCompletos.Enabled = false;

            lbl_DadosP.Enabled = false;
            lbl_Nome.Enabled = false;
            lbl_Sobrenome.Enabled = false;
            lbl_Idade.Enabled = false;
            lbl_Bairro.Enabled = false;
            lbl_Celular.Enabled = false;
            lbl_Email.Enabled = false;
            lbl_ConfirmaçãoDa.Enabled = false;
            lbl_Resultado.Enabled = false;

            txt_Nome.Enabled = false;
            txt_Sobrenome.Enabled = false;
            txt_Idade.Enabled = false;
            txt_Bairro.Enabled = false;
            txt_Celular.Enabled = false;
            txt_Email.Enabled = false;
        }
    }
}
