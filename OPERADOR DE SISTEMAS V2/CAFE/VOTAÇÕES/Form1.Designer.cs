namespace VOTAÇÕES
{
    partial class frm_Primeiro
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
            this.btn_tela2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_tela2
            // 
            this.btn_tela2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_tela2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_tela2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btn_tela2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tela2.ForeColor = System.Drawing.Color.White;
            this.btn_tela2.Location = new System.Drawing.Point(69, 81);
            this.btn_tela2.Name = "btn_tela2";
            this.btn_tela2.Size = new System.Drawing.Size(88, 84);
            this.btn_tela2.TabIndex = 0;
            this.btn_tela2.Text = "TELA 2";
            this.btn_tela2.UseVisualStyleBackColor = false;
            this.btn_tela2.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm_Primeiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VOTAÇÕES.Properties.Resources.Understanding_the_Selling_Leadership_Style_and___;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(864, 530);
            this.Controls.Add(this.btn_tela2);
            this.Name = "frm_Primeiro";
            this.Text = "Primeiro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Primeiro_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_tela2;
    }
}

