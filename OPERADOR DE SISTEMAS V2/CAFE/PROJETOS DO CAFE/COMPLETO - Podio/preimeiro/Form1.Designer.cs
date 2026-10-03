namespace preimeiro
{
    partial class frm_primeiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_primeiro));
            this.btn_tela2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_tela2
            // 
            this.btn_tela2.Location = new System.Drawing.Point(557, 32);
            this.btn_tela2.Name = "btn_tela2";
            this.btn_tela2.Size = new System.Drawing.Size(91, 94);
            this.btn_tela2.TabIndex = 0;
            this.btn_tela2.Text = "Tela 2";
            this.btn_tela2.UseVisualStyleBackColor = true;
            this.btn_tela2.Click += new System.EventHandler(this.btn_tela2_Click);
            // 
            // frm_primeiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::preimeiro.Properties.Resources.Espada1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(723, 469);
            this.Controls.Add(this.btn_tela2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_primeiro";
            this.Text = "Primeiro";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_primeiro_FormClosed);
            this.Load += new System.EventHandler(this.frm_primeiro_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_tela2;
    }
}