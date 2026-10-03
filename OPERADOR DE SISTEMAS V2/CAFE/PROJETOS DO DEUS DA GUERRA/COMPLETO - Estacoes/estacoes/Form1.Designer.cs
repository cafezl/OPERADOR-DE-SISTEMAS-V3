namespace estacoes
{
    partial class frm_Estacoes
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gpr_estacoes = new System.Windows.Forms.GroupBox();
            this.rad_inverno = new System.Windows.Forms.RadioButton();
            this.rad_outono = new System.Windows.Forms.RadioButton();
            this.rad_verao = new System.Windows.Forms.RadioButton();
            this.rad_primavera = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gpr_estacoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(287, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(297, 231);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // gpr_estacoes
            // 
            this.gpr_estacoes.Controls.Add(this.rad_inverno);
            this.gpr_estacoes.Controls.Add(this.rad_outono);
            this.gpr_estacoes.Controls.Add(this.rad_verao);
            this.gpr_estacoes.Controls.Add(this.rad_primavera);
            this.gpr_estacoes.Location = new System.Drawing.Point(99, 95);
            this.gpr_estacoes.Name = "gpr_estacoes";
            this.gpr_estacoes.Size = new System.Drawing.Size(134, 126);
            this.gpr_estacoes.TabIndex = 1;
            this.gpr_estacoes.TabStop = false;
            this.gpr_estacoes.Text = "Estações";
            this.gpr_estacoes.Enter += new System.EventHandler(this.gpr_estacoes_Enter);
            // 
            // rad_inverno
            // 
            this.rad_inverno.AutoSize = true;
            this.rad_inverno.Location = new System.Drawing.Point(7, 91);
            this.rad_inverno.Name = "rad_inverno";
            this.rad_inverno.Size = new System.Drawing.Size(60, 17);
            this.rad_inverno.TabIndex = 3;
            this.rad_inverno.TabStop = true;
            this.rad_inverno.Text = "inverno";
            this.rad_inverno.UseVisualStyleBackColor = true;
            this.rad_inverno.CheckedChanged += new System.EventHandler(this.rad_inverno_CheckedChanged);
            // 
            // rad_outono
            // 
            this.rad_outono.AutoSize = true;
            this.rad_outono.Location = new System.Drawing.Point(7, 68);
            this.rad_outono.Name = "rad_outono";
            this.rad_outono.Size = new System.Drawing.Size(60, 17);
            this.rad_outono.TabIndex = 2;
            this.rad_outono.TabStop = true;
            this.rad_outono.Text = "Outono";
            this.rad_outono.UseVisualStyleBackColor = true;
            this.rad_outono.CheckedChanged += new System.EventHandler(this.rad_outono_CheckedChanged);
            // 
            // rad_verao
            // 
            this.rad_verao.AutoSize = true;
            this.rad_verao.Location = new System.Drawing.Point(7, 44);
            this.rad_verao.Name = "rad_verao";
            this.rad_verao.Size = new System.Drawing.Size(53, 17);
            this.rad_verao.TabIndex = 1;
            this.rad_verao.TabStop = true;
            this.rad_verao.Text = "Verão";
            this.rad_verao.UseVisualStyleBackColor = true;
            this.rad_verao.CheckedChanged += new System.EventHandler(this.rad_verao_CheckedChanged);
            // 
            // rad_primavera
            // 
            this.rad_primavera.AutoSize = true;
            this.rad_primavera.Location = new System.Drawing.Point(7, 20);
            this.rad_primavera.Name = "rad_primavera";
            this.rad_primavera.Size = new System.Drawing.Size(72, 17);
            this.rad_primavera.TabIndex = 0;
            this.rad_primavera.TabStop = true;
            this.rad_primavera.Text = "Primavera";
            this.rad_primavera.UseVisualStyleBackColor = true;
            this.rad_primavera.CheckedChanged += new System.EventHandler(this.rad_primavera_CheckedChanged);
            // 
            // frm_Estacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gpr_estacoes);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frm_Estacoes";
            this.Text = "Estações";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gpr_estacoes.ResumeLayout(false);
            this.gpr_estacoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gpr_estacoes;
        private System.Windows.Forms.RadioButton rad_inverno;
        private System.Windows.Forms.RadioButton rad_outono;
        private System.Windows.Forms.RadioButton rad_verao;
        private System.Windows.Forms.RadioButton rad_primavera;
    }
}

