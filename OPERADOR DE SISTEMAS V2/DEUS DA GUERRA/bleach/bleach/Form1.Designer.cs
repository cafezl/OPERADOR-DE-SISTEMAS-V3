namespace bleach
{
    partial class Form1
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
            this.btn_humano = new System.Windows.Forms.Button();
            this.btn_shinigami = new System.Windows.Forms.Button();
            this.btn_hollow = new System.Windows.Forms.Button();
            this.btn_quincy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_humano
            // 
            this.btn_humano.Font = new System.Drawing.Font("Baskerville Old Face", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_humano.Location = new System.Drawing.Point(12, 12);
            this.btn_humano.Name = "btn_humano";
            this.btn_humano.Size = new System.Drawing.Size(86, 82);
            this.btn_humano.TabIndex = 0;
            this.btn_humano.Text = "Humano";
            this.btn_humano.UseVisualStyleBackColor = true;
            this.btn_humano.Click += new System.EventHandler(this.btn_humano_Click);
            // 
            // btn_shinigami
            // 
            this.btn_shinigami.Font = new System.Drawing.Font("Baskerville Old Face", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_shinigami.Location = new System.Drawing.Point(560, 12);
            this.btn_shinigami.Name = "btn_shinigami";
            this.btn_shinigami.Size = new System.Drawing.Size(86, 82);
            this.btn_shinigami.TabIndex = 1;
            this.btn_shinigami.Text = "Shinigami";
            this.btn_shinigami.UseVisualStyleBackColor = true;
            // 
            // btn_hollow
            // 
            this.btn_hollow.Font = new System.Drawing.Font("Baskerville Old Face", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_hollow.Location = new System.Drawing.Point(12, 404);
            this.btn_hollow.Name = "btn_hollow";
            this.btn_hollow.Size = new System.Drawing.Size(86, 82);
            this.btn_hollow.TabIndex = 2;
            this.btn_hollow.Text = "Hollow";
            this.btn_hollow.UseVisualStyleBackColor = true;
            // 
            // btn_quincy
            // 
            this.btn_quincy.Font = new System.Drawing.Font("Baskerville Old Face", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_quincy.Location = new System.Drawing.Point(560, 404);
            this.btn_quincy.Name = "btn_quincy";
            this.btn_quincy.Size = new System.Drawing.Size(86, 82);
            this.btn_quincy.TabIndex = 3;
            this.btn_quincy.Text = "Quincy";
            this.btn_quincy.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 496);
            this.Controls.Add(this.btn_quincy);
            this.Controls.Add(this.btn_hollow);
            this.Controls.Add(this.btn_shinigami);
            this.Controls.Add(this.btn_humano);
            this.Name = "Form1";
            this.Text = "BLEACH";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_humano;
        private System.Windows.Forms.Button btn_shinigami;
        private System.Windows.Forms.Button btn_hollow;
        private System.Windows.Forms.Button btn_quincy;
    }
}

