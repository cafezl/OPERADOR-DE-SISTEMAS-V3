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
            this.grp_Temas = new System.Windows.Forms.GroupBox();
            this.rad_tema3 = new System.Windows.Forms.RadioButton();
            this.rad_tema1 = new System.Windows.Forms.RadioButton();
            this.rad_tema2 = new System.Windows.Forms.RadioButton();
            this.btn_ativar = new System.Windows.Forms.Button();
            this.btn_Desativar = new System.Windows.Forms.Button();
            this.btn_Limpar = new System.Windows.Forms.Button();
            this.lbl_Resultado = new System.Windows.Forms.Label();
            this.btn_DadosCompletos = new System.Windows.Forms.Button();
            this.btn_Email = new System.Windows.Forms.Button();
            this.btn_Celular = new System.Windows.Forms.Button();
            this.btn_Bairro = new System.Windows.Forms.Button();
            this.btn_Idade = new System.Windows.Forms.Button();
            this.btn_Sobrenome = new System.Windows.Forms.Button();
            this.btn_Nome = new System.Windows.Forms.Button();
            this.grp_Temas.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_DadosP
            // 
            this.lbl_DadosP.AutoSize = true;
            this.lbl_DadosP.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_DadosP.Enabled = false;
            this.lbl_DadosP.Location = new System.Drawing.Point(297, 9);
            this.lbl_DadosP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_DadosP.Name = "lbl_DadosP";
            this.lbl_DadosP.Size = new System.Drawing.Size(104, 14);
            this.lbl_DadosP.TabIndex = 0;
            this.lbl_DadosP.Text = "Dados Pessoais";
            // 
            // lbl_Nome
            // 
            this.lbl_Nome.AutoSize = true;
            this.lbl_Nome.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Nome.Enabled = false;
            this.lbl_Nome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Nome.Location = new System.Drawing.Point(52, 53);
            this.lbl_Nome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Nome.Name = "lbl_Nome";
            this.lbl_Nome.Size = new System.Drawing.Size(44, 14);
            this.lbl_Nome.TabIndex = 1;
            this.lbl_Nome.Text = "Nome";
            this.lbl_Nome.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbl_Sobrenome
            // 
            this.lbl_Sobrenome.AutoSize = true;
            this.lbl_Sobrenome.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Sobrenome.Enabled = false;
            this.lbl_Sobrenome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Sobrenome.Location = new System.Drawing.Point(52, 111);
            this.lbl_Sobrenome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Sobrenome.Name = "lbl_Sobrenome";
            this.lbl_Sobrenome.Size = new System.Drawing.Size(78, 14);
            this.lbl_Sobrenome.TabIndex = 2;
            this.lbl_Sobrenome.Text = "Sobrenome";
            // 
            // lbl_Idade
            // 
            this.lbl_Idade.AutoSize = true;
            this.lbl_Idade.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Idade.Enabled = false;
            this.lbl_Idade.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Idade.Location = new System.Drawing.Point(52, 172);
            this.lbl_Idade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Idade.Name = "lbl_Idade";
            this.lbl_Idade.Size = new System.Drawing.Size(43, 14);
            this.lbl_Idade.TabIndex = 3;
            this.lbl_Idade.Text = "Idade";
            this.lbl_Idade.Click += new System.EventHandler(this.label4_Click);
            // 
            // lbl_Bairro
            // 
            this.lbl_Bairro.AutoSize = true;
            this.lbl_Bairro.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Bairro.Enabled = false;
            this.lbl_Bairro.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Bairro.Location = new System.Drawing.Point(52, 229);
            this.lbl_Bairro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Bairro.Name = "lbl_Bairro";
            this.lbl_Bairro.Size = new System.Drawing.Size(48, 14);
            this.lbl_Bairro.TabIndex = 4;
            this.lbl_Bairro.Text = "Bairro";
            // 
            // lbl_Celular
            // 
            this.lbl_Celular.AutoSize = true;
            this.lbl_Celular.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Celular.Enabled = false;
            this.lbl_Celular.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Celular.Location = new System.Drawing.Point(52, 288);
            this.lbl_Celular.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Celular.Name = "lbl_Celular";
            this.lbl_Celular.Size = new System.Drawing.Size(53, 14);
            this.lbl_Celular.TabIndex = 5;
            this.lbl_Celular.Text = "Celular";
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Email.Enabled = false;
            this.lbl_Email.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Email.Location = new System.Drawing.Point(52, 337);
            this.lbl_Email.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(42, 14);
            this.lbl_Email.TabIndex = 6;
            this.lbl_Email.Text = "Email";
            // 
            // lbl_ConfirmaçãoDa
            // 
            this.lbl_ConfirmaçãoDa.AutoSize = true;
            this.lbl_ConfirmaçãoDa.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ConfirmaçãoDa.Enabled = false;
            this.lbl_ConfirmaçãoDa.Location = new System.Drawing.Point(52, 398);
            this.lbl_ConfirmaçãoDa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ConfirmaçãoDa.Name = "lbl_ConfirmaçãoDa";
            this.lbl_ConfirmaçãoDa.Size = new System.Drawing.Size(150, 14);
            this.lbl_ConfirmaçãoDa.TabIndex = 7;
            this.lbl_ConfirmaçãoDa.Text = "Confirmação de Dados";
            // 
            // txt_Nome
            // 
            this.txt_Nome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Nome.Enabled = false;
            this.txt_Nome.Location = new System.Drawing.Point(141, 45);
            this.txt_Nome.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_Nome.Name = "txt_Nome";
            this.txt_Nome.Size = new System.Drawing.Size(407, 22);
            this.txt_Nome.TabIndex = 9;
            this.txt_Nome.TextChanged += new System.EventHandler(this.txt_Nome_TextChanged);
            // 
            // txt_Sobrenome
            // 
            this.txt_Sobrenome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Sobrenome.Enabled = false;
            this.txt_Sobrenome.Location = new System.Drawing.Point(141, 107);
            this.txt_Sobrenome.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_Sobrenome.Name = "txt_Sobrenome";
            this.txt_Sobrenome.Size = new System.Drawing.Size(407, 22);
            this.txt_Sobrenome.TabIndex = 10;
            // 
            // txt_Idade
            // 
            this.txt_Idade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Idade.Enabled = false;
            this.txt_Idade.Location = new System.Drawing.Point(141, 164);
            this.txt_Idade.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_Idade.Name = "txt_Idade";
            this.txt_Idade.Size = new System.Drawing.Size(407, 22);
            this.txt_Idade.TabIndex = 11;
            // 
            // txt_Bairro
            // 
            this.txt_Bairro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Bairro.Enabled = false;
            this.txt_Bairro.Location = new System.Drawing.Point(141, 225);
            this.txt_Bairro.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_Bairro.Name = "txt_Bairro";
            this.txt_Bairro.Size = new System.Drawing.Size(407, 22);
            this.txt_Bairro.TabIndex = 12;
            // 
            // txt_Celular
            // 
            this.txt_Celular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Celular.Enabled = false;
            this.txt_Celular.Location = new System.Drawing.Point(141, 280);
            this.txt_Celular.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_Celular.Name = "txt_Celular";
            this.txt_Celular.Size = new System.Drawing.Size(407, 22);
            this.txt_Celular.TabIndex = 13;
            // 
            // txt_Email
            // 
            this.txt_Email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Email.Enabled = false;
            this.txt_Email.Location = new System.Drawing.Point(141, 330);
            this.txt_Email.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(407, 22);
            this.txt_Email.TabIndex = 14;
            // 
            // grp_Temas
            // 
            this.grp_Temas.BackColor = System.Drawing.Color.Transparent;
            this.grp_Temas.Controls.Add(this.rad_tema3);
            this.grp_Temas.Controls.Add(this.rad_tema1);
            this.grp_Temas.Controls.Add(this.rad_tema2);
            this.grp_Temas.Enabled = false;
            this.grp_Temas.ForeColor = System.Drawing.Color.Black;
            this.grp_Temas.Location = new System.Drawing.Point(998, 53);
            this.grp_Temas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grp_Temas.Name = "grp_Temas";
            this.grp_Temas.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grp_Temas.Size = new System.Drawing.Size(143, 149);
            this.grp_Temas.TabIndex = 22;
            this.grp_Temas.TabStop = false;
            this.grp_Temas.Text = "Temas";
            // 
            // rad_tema3
            // 
            this.rad_tema3.AutoSize = true;
            this.rad_tema3.ForeColor = System.Drawing.Color.Black;
            this.rad_tema3.Location = new System.Drawing.Point(8, 109);
            this.rad_tema3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rad_tema3.Name = "rad_tema3";
            this.rad_tema3.Size = new System.Drawing.Size(71, 18);
            this.rad_tema3.TabIndex = 25;
            this.rad_tema3.TabStop = true;
            this.rad_tema3.Text = "Tema 3";
            this.rad_tema3.UseVisualStyleBackColor = true;
            this.rad_tema3.CheckedChanged += new System.EventHandler(this.rad_tema3_CheckedChanged);
            // 
            // rad_tema1
            // 
            this.rad_tema1.AutoSize = true;
            this.rad_tema1.ForeColor = System.Drawing.Color.Black;
            this.rad_tema1.Location = new System.Drawing.Point(8, 40);
            this.rad_tema1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rad_tema1.Name = "rad_tema1";
            this.rad_tema1.Size = new System.Drawing.Size(70, 18);
            this.rad_tema1.TabIndex = 23;
            this.rad_tema1.TabStop = true;
            this.rad_tema1.Text = "Padrão";
            this.rad_tema1.UseVisualStyleBackColor = true;
            this.rad_tema1.CheckedChanged += new System.EventHandler(this.rad_tema1_CheckedChanged);
            // 
            // rad_tema2
            // 
            this.rad_tema2.AutoSize = true;
            this.rad_tema2.ForeColor = System.Drawing.Color.Black;
            this.rad_tema2.Location = new System.Drawing.Point(8, 75);
            this.rad_tema2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rad_tema2.Name = "rad_tema2";
            this.rad_tema2.Size = new System.Drawing.Size(71, 18);
            this.rad_tema2.TabIndex = 24;
            this.rad_tema2.TabStop = true;
            this.rad_tema2.Text = "Tema 2";
            this.rad_tema2.UseVisualStyleBackColor = true;
            this.rad_tema2.CheckedChanged += new System.EventHandler(this.rad_tema2_CheckedChanged);
            // 
            // btn_ativar
            // 
            this.btn_ativar.BackColor = System.Drawing.Color.Transparent;
            this.btn_ativar.Location = new System.Drawing.Point(647, 12);
            this.btn_ativar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_ativar.Name = "btn_ativar";
            this.btn_ativar.Size = new System.Drawing.Size(100, 25);
            this.btn_ativar.TabIndex = 23;
            this.btn_ativar.Text = "Ativar";
            this.btn_ativar.UseVisualStyleBackColor = false;
            this.btn_ativar.Click += new System.EventHandler(this.btn_ativar_Click);
            // 
            // btn_Desativar
            // 
            this.btn_Desativar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Desativar.Enabled = false;
            this.btn_Desativar.Location = new System.Drawing.Point(755, 12);
            this.btn_Desativar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Desativar.Name = "btn_Desativar";
            this.btn_Desativar.Size = new System.Drawing.Size(100, 25);
            this.btn_Desativar.TabIndex = 24;
            this.btn_Desativar.Text = "Desativar";
            this.btn_Desativar.UseVisualStyleBackColor = false;
            this.btn_Desativar.Click += new System.EventHandler(this.btn_Desativar_Click);
            // 
            // btn_Limpar
            // 
            this.btn_Limpar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Limpar.Enabled = false;
            this.btn_Limpar.Location = new System.Drawing.Point(863, 12);
            this.btn_Limpar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Limpar.Name = "btn_Limpar";
            this.btn_Limpar.Size = new System.Drawing.Size(100, 25);
            this.btn_Limpar.TabIndex = 25;
            this.btn_Limpar.Text = "Limpar";
            this.btn_Limpar.UseVisualStyleBackColor = false;
            this.btn_Limpar.Click += new System.EventHandler(this.btn_Limpar_Click);
            // 
            // lbl_Resultado
            // 
            this.lbl_Resultado.AutoSize = true;
            this.lbl_Resultado.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_Resultado.Enabled = false;
            this.lbl_Resultado.Location = new System.Drawing.Point(297, 461);
            this.lbl_Resultado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Resultado.Name = "lbl_Resultado";
            this.lbl_Resultado.Size = new System.Drawing.Size(68, 14);
            this.lbl_Resultado.TabIndex = 26;
            this.lbl_Resultado.Text = "Resultado";
            // 
            // btn_DadosCompletos
            // 
            this.btn_DadosCompletos.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_DadosCompletos.Enabled = false;
            this.btn_DadosCompletos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_DadosCompletos.Location = new System.Drawing.Point(581, 387);
            this.btn_DadosCompletos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_DadosCompletos.Name = "btn_DadosCompletos";
            this.btn_DadosCompletos.Size = new System.Drawing.Size(100, 37);
            this.btn_DadosCompletos.TabIndex = 21;
            this.btn_DadosCompletos.Text = "Dados \r\nCompletos";
            this.btn_DadosCompletos.UseVisualStyleBackColor = false;
            this.btn_DadosCompletos.Click += new System.EventHandler(this.btn_DadosCompletos_Click);
            // 
            // btn_Email
            // 
            this.btn_Email.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Email.Enabled = false;
            this.btn_Email.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Email.Location = new System.Drawing.Point(581, 330);
            this.btn_Email.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Email.Name = "btn_Email";
            this.btn_Email.Size = new System.Drawing.Size(100, 25);
            this.btn_Email.TabIndex = 20;
            this.btn_Email.Text = "Email";
            this.btn_Email.UseVisualStyleBackColor = false;
            this.btn_Email.Click += new System.EventHandler(this.btn_Email_Click);
            // 
            // btn_Celular
            // 
            this.btn_Celular.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Celular.Enabled = false;
            this.btn_Celular.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Celular.Location = new System.Drawing.Point(581, 277);
            this.btn_Celular.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Celular.Name = "btn_Celular";
            this.btn_Celular.Size = new System.Drawing.Size(100, 25);
            this.btn_Celular.TabIndex = 19;
            this.btn_Celular.Text = "Celular";
            this.btn_Celular.UseVisualStyleBackColor = false;
            this.btn_Celular.Click += new System.EventHandler(this.btn_Celular_Click);
            // 
            // btn_Bairro
            // 
            this.btn_Bairro.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Bairro.Enabled = false;
            this.btn_Bairro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Bairro.Location = new System.Drawing.Point(581, 222);
            this.btn_Bairro.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Bairro.Name = "btn_Bairro";
            this.btn_Bairro.Size = new System.Drawing.Size(100, 25);
            this.btn_Bairro.TabIndex = 18;
            this.btn_Bairro.Text = "Bairro";
            this.btn_Bairro.UseVisualStyleBackColor = false;
            this.btn_Bairro.Click += new System.EventHandler(this.btn_Bairro_Click);
            // 
            // btn_Idade
            // 
            this.btn_Idade.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Idade.Enabled = false;
            this.btn_Idade.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Idade.Location = new System.Drawing.Point(581, 167);
            this.btn_Idade.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Idade.Name = "btn_Idade";
            this.btn_Idade.Size = new System.Drawing.Size(100, 25);
            this.btn_Idade.TabIndex = 17;
            this.btn_Idade.Text = "Idade";
            this.btn_Idade.UseVisualStyleBackColor = false;
            this.btn_Idade.Click += new System.EventHandler(this.btn_Idade_Click);
            // 
            // btn_Sobrenome
            // 
            this.btn_Sobrenome.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Sobrenome.Enabled = false;
            this.btn_Sobrenome.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Sobrenome.Location = new System.Drawing.Point(581, 107);
            this.btn_Sobrenome.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Sobrenome.Name = "btn_Sobrenome";
            this.btn_Sobrenome.Size = new System.Drawing.Size(100, 25);
            this.btn_Sobrenome.TabIndex = 16;
            this.btn_Sobrenome.Text = "Sobrenome";
            this.btn_Sobrenome.UseVisualStyleBackColor = false;
            this.btn_Sobrenome.Click += new System.EventHandler(this.btn_Sobrenome_Click);
            // 
            // btn_Nome
            // 
            this.btn_Nome.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Nome.Enabled = false;
            this.btn_Nome.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Nome.Location = new System.Drawing.Point(581, 48);
            this.btn_Nome.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Nome.Name = "btn_Nome";
            this.btn_Nome.Size = new System.Drawing.Size(100, 25);
            this.btn_Nome.TabIndex = 15;
            this.btn_Nome.Text = "Nome";
            this.btn_Nome.UseVisualStyleBackColor = false;
            this.btn_Nome.Click += new System.EventHandler(this.btn_Nome_Click);
            // 
            // Frm_Cadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::cadastro.Properties.Resources.imagem4;
            this.ClientSize = new System.Drawing.Size(1139, 576);
            this.Controls.Add(this.btn_Celular);
            this.Controls.Add(this.btn_Email);
            this.Controls.Add(this.btn_Bairro);
            this.Controls.Add(this.btn_DadosCompletos);
            this.Controls.Add(this.btn_Idade);
            this.Controls.Add(this.btn_Sobrenome);
            this.Controls.Add(this.btn_Nome);
            this.Controls.Add(this.lbl_Resultado);
            this.Controls.Add(this.btn_Limpar);
            this.Controls.Add(this.btn_Desativar);
            this.Controls.Add(this.btn_ativar);
            this.Controls.Add(this.grp_Temas);
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
            this.Font = new System.Drawing.Font("Baskerville Old Face", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSize = new System.Drawing.Size(1155, 615);
            this.MinimumSize = new System.Drawing.Size(1145, 595);
            this.Name = "Frm_Cadastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro";
            this.Load += new System.EventHandler(this.Frm_Cadastro_Load);
            this.grp_Temas.ResumeLayout(false);
            this.grp_Temas.PerformLayout();
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
        private System.Windows.Forms.GroupBox grp_Temas;
        private System.Windows.Forms.RadioButton rad_tema3;
        private System.Windows.Forms.RadioButton rad_tema1;
        private System.Windows.Forms.RadioButton rad_tema2;
        private System.Windows.Forms.Button btn_ativar;
        private System.Windows.Forms.Button btn_Desativar;
        private System.Windows.Forms.Button btn_Limpar;
        private System.Windows.Forms.Label lbl_Resultado;
        private System.Windows.Forms.Button btn_DadosCompletos;
        private System.Windows.Forms.Button btn_Email;
        private System.Windows.Forms.Button btn_Celular;
        private System.Windows.Forms.Button btn_Bairro;
        private System.Windows.Forms.Button btn_Idade;
        private System.Windows.Forms.Button btn_Sobrenome;
        private System.Windows.Forms.Button btn_Nome;
    }
}

