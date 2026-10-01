namespace cadastro
{
    partial class Frm_Cadastro
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Cadastro));
			this.lbl_DadosP = new System.Windows.Forms.Label();
			this.lbl_Nome = new System.Windows.Forms.Label();
			this.lbl_Sobrenome = new System.Windows.Forms.Label();
			this.lbl_Idade = new System.Windows.Forms.Label();
			this.lbl_Bairro = new System.Windows.Forms.Label();
			this.lbl_Celular = new System.Windows.Forms.Label();
			this.lbl_Email = new System.Windows.Forms.Label();
			this.lbl_ConfirmaçãoDa = new System.Windows.Forms.Label();
			this.txt_Nome = new System.Windows.Forms.TextBox();
			this.txt_Sobrenome = new System.Windows.Forms.TextBox();
			this.txt_Idade = new System.Windows.Forms.TextBox();
			this.txt_Bairro = new System.Windows.Forms.TextBox();
			this.txt_Celular = new System.Windows.Forms.TextBox();
			this.txt_Email = new System.Windows.Forms.TextBox();
			this.btn_Nome = new System.Windows.Forms.Button();
			this.btn_Sobrenome = new System.Windows.Forms.Button();
			this.btn_Idade = new System.Windows.Forms.Button();
			this.btn_Bairro = new System.Windows.Forms.Button();
			this.btn_Celular = new System.Windows.Forms.Button();
			this.btn_Email = new System.Windows.Forms.Button();
			this.btn_DadosCompletos = new System.Windows.Forms.Button();
			this.grptemas = new System.Windows.Forms.GroupBox();
			this.rad_tema1 = new System.Windows.Forms.RadioButton();
			this.rad_tema2 = new System.Windows.Forms.RadioButton();
			this.rad_tema3 = new System.Windows.Forms.RadioButton();
			this.btnativar = new System.Windows.Forms.RadioButton();
			this.btndesativar = new System.Windows.Forms.RadioButton();
			this.btnlimpar = new System.Windows.Forms.RadioButton();
			this.lblresultados = new System.Windows.Forms.Label();
			this.grptemas.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbl_DadosP
			// 
			this.lbl_DadosP.AutoSize = true;
			this.lbl_DadosP.BackColor = System.Drawing.Color.Transparent;
			this.lbl_DadosP.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.lbl_DadosP.Location = new System.Drawing.Point(9, 0);
			this.lbl_DadosP.Name = "lbl_DadosP";
			this.lbl_DadosP.Size = new System.Drawing.Size(83, 13);
			this.lbl_DadosP.TabIndex = 0;
			this.lbl_DadosP.Text = "Dados Pessoais";
			// 
			// lbl_Nome
			// 
			this.lbl_Nome.AutoSize = true;
			this.lbl_Nome.BackColor = System.Drawing.Color.Transparent;
			this.lbl_Nome.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.lbl_Nome.Location = new System.Drawing.Point(36, 13);
			this.lbl_Nome.Name = "lbl_Nome";
			this.lbl_Nome.Size = new System.Drawing.Size(35, 13);
			this.lbl_Nome.TabIndex = 1;
			this.lbl_Nome.Text = "Nome";
			this.lbl_Nome.Click += new System.EventHandler(this.label2_Click);
			// 
			// lbl_Sobrenome
			// 
			this.lbl_Sobrenome.AutoSize = true;
			this.lbl_Sobrenome.BackColor = System.Drawing.Color.Transparent;
			this.lbl_Sobrenome.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.lbl_Sobrenome.Location = new System.Drawing.Point(216, 9);
			this.lbl_Sobrenome.Name = "lbl_Sobrenome";
			this.lbl_Sobrenome.Size = new System.Drawing.Size(61, 13);
			this.lbl_Sobrenome.TabIndex = 2;
			this.lbl_Sobrenome.Text = "Sobrenome";
			// 
			// lbl_Idade
			// 
			this.lbl_Idade.AutoSize = true;
			this.lbl_Idade.BackColor = System.Drawing.Color.Transparent;
			this.lbl_Idade.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.lbl_Idade.Location = new System.Drawing.Point(110, 10);
			this.lbl_Idade.Name = "lbl_Idade";
			this.lbl_Idade.Size = new System.Drawing.Size(34, 13);
			this.lbl_Idade.TabIndex = 3;
			this.lbl_Idade.Text = "Idade";
			this.lbl_Idade.Click += new System.EventHandler(this.label4_Click);
			// 
			// lbl_Bairro
			// 
			this.lbl_Bairro.AutoSize = true;
			this.lbl_Bairro.BackColor = System.Drawing.Color.Transparent;
			this.lbl_Bairro.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.lbl_Bairro.Location = new System.Drawing.Point(169, 10);
			this.lbl_Bairro.Name = "lbl_Bairro";
			this.lbl_Bairro.Size = new System.Drawing.Size(34, 13);
			this.lbl_Bairro.TabIndex = 4;
			this.lbl_Bairro.Text = "Bairro";
			// 
			// lbl_Celular
			// 
			this.lbl_Celular.AutoSize = true;
			this.lbl_Celular.BackColor = System.Drawing.Color.Transparent;
			this.lbl_Celular.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.lbl_Celular.Location = new System.Drawing.Point(283, 9);
			this.lbl_Celular.Name = "lbl_Celular";
			this.lbl_Celular.Size = new System.Drawing.Size(39, 13);
			this.lbl_Celular.TabIndex = 5;
			this.lbl_Celular.Text = "Celular";
			// 
			// lbl_Email
			// 
			this.lbl_Email.AutoSize = true;
			this.lbl_Email.BackColor = System.Drawing.Color.Transparent;
			this.lbl_Email.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.lbl_Email.Location = new System.Drawing.Point(328, 9);
			this.lbl_Email.Name = "lbl_Email";
			this.lbl_Email.Size = new System.Drawing.Size(32, 13);
			this.lbl_Email.TabIndex = 6;
			this.lbl_Email.Text = "Email";
			// 
			// lbl_ConfirmaçãoDa
			// 
			this.lbl_ConfirmaçãoDa.AutoSize = true;
			this.lbl_ConfirmaçãoDa.BackColor = System.Drawing.Color.Transparent;
			this.lbl_ConfirmaçãoDa.ForeColor = System.Drawing.Color.Transparent;
			this.lbl_ConfirmaçãoDa.Location = new System.Drawing.Point(9, 52);
			this.lbl_ConfirmaçãoDa.Name = "lbl_ConfirmaçãoDa";
			this.lbl_ConfirmaçãoDa.Size = new System.Drawing.Size(115, 13);
			this.lbl_ConfirmaçãoDa.TabIndex = 7;
			this.lbl_ConfirmaçãoDa.Text = "Confirmação de Dados";
			// 
			// txt_Nome
			// 
			this.txt_Nome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt_Nome.Location = new System.Drawing.Point(12, 26);
			this.txt_Nome.Name = "txt_Nome";
			this.txt_Nome.Size = new System.Drawing.Size(83, 20);
			this.txt_Nome.TabIndex = 9;
			// 
			// txt_Sobrenome
			// 
			this.txt_Sobrenome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt_Sobrenome.Location = new System.Drawing.Point(101, 26);
			this.txt_Sobrenome.Name = "txt_Sobrenome";
			this.txt_Sobrenome.Size = new System.Drawing.Size(53, 20);
			this.txt_Sobrenome.TabIndex = 10;
			// 
			// txt_Idade
			// 
			this.txt_Idade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt_Idade.Location = new System.Drawing.Point(160, 26);
			this.txt_Idade.Name = "txt_Idade";
			this.txt_Idade.Size = new System.Drawing.Size(53, 20);
			this.txt_Idade.TabIndex = 11;
			// 
			// txt_Bairro
			// 
			this.txt_Bairro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt_Bairro.Location = new System.Drawing.Point(219, 26);
			this.txt_Bairro.Name = "txt_Bairro";
			this.txt_Bairro.Size = new System.Drawing.Size(58, 20);
			this.txt_Bairro.TabIndex = 12;
			this.txt_Bairro.TextChanged += new System.EventHandler(this.txt_Bairro_TextChanged);
			// 
			// txt_Celular
			// 
			this.txt_Celular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt_Celular.Location = new System.Drawing.Point(283, 27);
			this.txt_Celular.Name = "txt_Celular";
			this.txt_Celular.Size = new System.Drawing.Size(39, 20);
			this.txt_Celular.TabIndex = 13;
			// 
			// txt_Email
			// 
			this.txt_Email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt_Email.Location = new System.Drawing.Point(328, 25);
			this.txt_Email.Name = "txt_Email";
			this.txt_Email.Size = new System.Drawing.Size(32, 20);
			this.txt_Email.TabIndex = 14;
			// 
			// btn_Nome
			// 
			this.btn_Nome.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.btn_Nome.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btn_Nome.Location = new System.Drawing.Point(726, 13);
			this.btn_Nome.Name = "btn_Nome";
			this.btn_Nome.Size = new System.Drawing.Size(75, 23);
			this.btn_Nome.TabIndex = 15;
			this.btn_Nome.Text = "Nome";
			this.btn_Nome.UseVisualStyleBackColor = false;
			// 
			// btn_Sobrenome
			// 
			this.btn_Sobrenome.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.btn_Sobrenome.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btn_Sobrenome.Location = new System.Drawing.Point(726, 42);
			this.btn_Sobrenome.Name = "btn_Sobrenome";
			this.btn_Sobrenome.Size = new System.Drawing.Size(75, 23);
			this.btn_Sobrenome.TabIndex = 16;
			this.btn_Sobrenome.Text = "Sobrenome";
			this.btn_Sobrenome.UseVisualStyleBackColor = false;
			// 
			// btn_Idade
			// 
			this.btn_Idade.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.btn_Idade.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btn_Idade.Location = new System.Drawing.Point(726, 71);
			this.btn_Idade.Name = "btn_Idade";
			this.btn_Idade.Size = new System.Drawing.Size(75, 23);
			this.btn_Idade.TabIndex = 17;
			this.btn_Idade.Text = "Idade";
			this.btn_Idade.UseVisualStyleBackColor = false;
			// 
			// btn_Bairro
			// 
			this.btn_Bairro.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.btn_Bairro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btn_Bairro.Location = new System.Drawing.Point(726, 100);
			this.btn_Bairro.Name = "btn_Bairro";
			this.btn_Bairro.Size = new System.Drawing.Size(75, 23);
			this.btn_Bairro.TabIndex = 18;
			this.btn_Bairro.Text = "Bairro";
			this.btn_Bairro.UseVisualStyleBackColor = false;
			// 
			// btn_Celular
			// 
			this.btn_Celular.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.btn_Celular.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btn_Celular.Location = new System.Drawing.Point(726, 129);
			this.btn_Celular.Name = "btn_Celular";
			this.btn_Celular.Size = new System.Drawing.Size(75, 23);
			this.btn_Celular.TabIndex = 19;
			this.btn_Celular.Text = "Celular";
			this.btn_Celular.UseVisualStyleBackColor = false;
			// 
			// btn_Email
			// 
			this.btn_Email.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.btn_Email.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btn_Email.Location = new System.Drawing.Point(726, 158);
			this.btn_Email.Name = "btn_Email";
			this.btn_Email.Size = new System.Drawing.Size(75, 23);
			this.btn_Email.TabIndex = 20;
			this.btn_Email.Text = "Email";
			this.btn_Email.UseVisualStyleBackColor = false;
			// 
			// btn_DadosCompletos
			// 
			this.btn_DadosCompletos.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.btn_DadosCompletos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btn_DadosCompletos.Location = new System.Drawing.Point(726, 187);
			this.btn_DadosCompletos.Name = "btn_DadosCompletos";
			this.btn_DadosCompletos.Size = new System.Drawing.Size(75, 34);
			this.btn_DadosCompletos.TabIndex = 21;
			this.btn_DadosCompletos.Text = "Dados \r\nCompletos";
			this.btn_DadosCompletos.UseVisualStyleBackColor = false;
			// 
			// grptemas
			// 
			this.grptemas.BackColor = System.Drawing.Color.Transparent;
			this.grptemas.Controls.Add(this.rad_tema1);
			this.grptemas.Controls.Add(this.rad_tema2);
			this.grptemas.Controls.Add(this.rad_tema3);
			this.grptemas.Controls.Add(this.btnativar);
			this.grptemas.ForeColor = System.Drawing.Color.White;
			this.grptemas.Location = new System.Drawing.Point(33, 494);
			this.grptemas.Name = "grptemas";
			this.grptemas.Size = new System.Drawing.Size(170, 36);
			this.grptemas.TabIndex = 22;
			this.grptemas.TabStop = false;
			this.grptemas.Text = "temas";
			this.grptemas.Enter += new System.EventHandler(this.grptemas_Enter);
			// 
			// rad_tema1
			// 
			this.rad_tema1.AutoSize = true;
			this.rad_tema1.BackColor = System.Drawing.Color.Transparent;
			this.rad_tema1.ForeColor = System.Drawing.Color.White;
			this.rad_tema1.Location = new System.Drawing.Point(5, 11);
			this.rad_tema1.Name = "rad_tema1";
			this.rad_tema1.Size = new System.Drawing.Size(54, 17);
			this.rad_tema1.TabIndex = 23;
			this.rad_tema1.TabStop = true;
			this.rad_tema1.Text = "tema1";
			this.rad_tema1.UseVisualStyleBackColor = false;
			// 
			// rad_tema2
			// 
			this.rad_tema2.AutoSize = true;
			this.rad_tema2.BackColor = System.Drawing.Color.Transparent;
			this.rad_tema2.ForeColor = System.Drawing.Color.White;
			this.rad_tema2.Location = new System.Drawing.Point(65, 11);
			this.rad_tema2.Name = "rad_tema2";
			this.rad_tema2.Size = new System.Drawing.Size(54, 17);
			this.rad_tema2.TabIndex = 24;
			this.rad_tema2.TabStop = true;
			this.rad_tema2.Text = "tema2";
			this.rad_tema2.UseVisualStyleBackColor = false;
			this.rad_tema2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// rad_tema3
			// 
			this.rad_tema3.AutoSize = true;
			this.rad_tema3.BackColor = System.Drawing.Color.Transparent;
			this.rad_tema3.ForeColor = System.Drawing.Color.White;
			this.rad_tema3.Location = new System.Drawing.Point(116, 11);
			this.rad_tema3.Name = "rad_tema3";
			this.rad_tema3.Size = new System.Drawing.Size(54, 17);
			this.rad_tema3.TabIndex = 25;
			this.rad_tema3.TabStop = true;
			this.rad_tema3.Text = "tema3";
			this.rad_tema3.UseVisualStyleBackColor = false;
			// 
			// btnativar
			// 
			this.btnativar.AutoSize = true;
			this.btnativar.BackColor = System.Drawing.Color.Transparent;
			this.btnativar.ForeColor = System.Drawing.Color.White;
			this.btnativar.Location = new System.Drawing.Point(176, 11);
			this.btnativar.Name = "btnativar";
			this.btnativar.Size = new System.Drawing.Size(51, 17);
			this.btnativar.TabIndex = 26;
			this.btnativar.TabStop = true;
			this.btnativar.Text = "ativar";
			this.btnativar.UseVisualStyleBackColor = false;
			// 
			// btndesativar
			// 
			this.btndesativar.AutoSize = true;
			this.btndesativar.BackColor = System.Drawing.Color.Transparent;
			this.btndesativar.ForeColor = System.Drawing.Color.White;
			this.btndesativar.Location = new System.Drawing.Point(209, 511);
			this.btndesativar.Name = "btndesativar";
			this.btndesativar.Size = new System.Drawing.Size(68, 17);
			this.btndesativar.TabIndex = 27;
			this.btndesativar.TabStop = true;
			this.btndesativar.Text = "desativar";
			this.btndesativar.UseVisualStyleBackColor = false;
			this.btndesativar.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged_1);
			// 
			// btnlimpar
			// 
			this.btnlimpar.AutoSize = true;
			this.btnlimpar.BackColor = System.Drawing.Color.Transparent;
			this.btnlimpar.ForeColor = System.Drawing.Color.White;
			this.btnlimpar.Location = new System.Drawing.Point(286, 511);
			this.btnlimpar.Name = "btnlimpar";
			this.btnlimpar.Size = new System.Drawing.Size(52, 17);
			this.btnlimpar.TabIndex = 28;
			this.btnlimpar.TabStop = true;
			this.btnlimpar.Text = "limpar";
			this.btnlimpar.UseVisualStyleBackColor = false;
			this.btnlimpar.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// lblresultados
			// 
			this.lblresultados.AutoSize = true;
			this.lblresultados.BackColor = System.Drawing.Color.Transparent;
			this.lblresultados.ForeColor = System.Drawing.Color.White;
			this.lblresultados.Location = new System.Drawing.Point(344, 517);
			this.lblresultados.Name = "lblresultados";
			this.lblresultados.Size = new System.Drawing.Size(55, 13);
			this.lblresultados.TabIndex = 29;
			this.lblresultados.Text = "resultados";
			// 
			// Frm_Cadastro
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(1004, 535);
			this.Controls.Add(this.lblresultados);
			this.Controls.Add(this.btnlimpar);
			this.Controls.Add(this.btndesativar);
			this.Controls.Add(this.grptemas);
			this.Controls.Add(this.btn_DadosCompletos);
			this.Controls.Add(this.btn_Email);
			this.Controls.Add(this.btn_Celular);
			this.Controls.Add(this.btn_Bairro);
			this.Controls.Add(this.btn_Idade);
			this.Controls.Add(this.btn_Sobrenome);
			this.Controls.Add(this.btn_Nome);
			this.Controls.Add(this.txt_Email);
			this.Controls.Add(this.txt_Celular);
			this.Controls.Add(this.txt_Bairro);
			this.Controls.Add(this.txt_Idade);
			this.Controls.Add(this.txt_Sobrenome);
			this.Controls.Add(this.txt_Nome);
			this.Controls.Add(this.lbl_ConfirmaçãoDa);
			this.Controls.Add(this.lbl_Email);
			this.Controls.Add(this.lbl_Celular);
			this.Controls.Add(this.lbl_Bairro);
			this.Controls.Add(this.lbl_Idade);
			this.Controls.Add(this.lbl_Sobrenome);
			this.Controls.Add(this.lbl_Nome);
			this.Controls.Add(this.lbl_DadosP);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(1020, 574);
			this.MinimumSize = new System.Drawing.Size(920, 474);
			this.Name = "Frm_Cadastro";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cadastro";
			this.Load += new System.EventHandler(this.Frm_Cadastro_Load);
			this.grptemas.ResumeLayout(false);
			this.grptemas.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_DadosP;
        private System.Windows.Forms.Label lbl_Nome;
        private System.Windows.Forms.Label lbl_Sobrenome;
        private System.Windows.Forms.Label lbl_Idade;
        private System.Windows.Forms.Label lbl_Bairro;
        private System.Windows.Forms.Label lbl_Celular;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label lbl_ConfirmaçãoDa;
        private System.Windows.Forms.TextBox txt_Nome;
        private System.Windows.Forms.TextBox txt_Sobrenome;
        private System.Windows.Forms.TextBox txt_Idade;
        private System.Windows.Forms.TextBox txt_Bairro;
        private System.Windows.Forms.TextBox txt_Celular;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Button btn_Nome;
        private System.Windows.Forms.Button btn_Sobrenome;
        private System.Windows.Forms.Button btn_Idade;
        private System.Windows.Forms.Button btn_Bairro;
        private System.Windows.Forms.Button btn_Celular;
        private System.Windows.Forms.Button btn_Email;
        private System.Windows.Forms.Button btn_DadosCompletos;
        private System.Windows.Forms.GroupBox grptemas;
        private System.Windows.Forms.RadioButton rad_tema1;
        private System.Windows.Forms.RadioButton rad_tema2;
        private System.Windows.Forms.RadioButton rad_tema3;
        private System.Windows.Forms.RadioButton btnativar;
        private System.Windows.Forms.RadioButton btndesativar;
        private System.Windows.Forms.RadioButton btnlimpar;
        private System.Windows.Forms.Label lblresultados;
    }
}

