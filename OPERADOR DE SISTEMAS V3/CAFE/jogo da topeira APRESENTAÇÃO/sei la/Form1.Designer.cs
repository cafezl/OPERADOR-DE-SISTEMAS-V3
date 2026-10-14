namespace sei_la
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        private void InitializeComponent()
        {
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnMovel = new System.Windows.Forms.Button();
            this.pnlVideo = new System.Windows.Forms.Panel();
            this.lblVideo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlVideo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblLevel.Location = new System.Drawing.Point(350, 30);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(140, 26);
            this.lblLevel.TabIndex = 2;
            this.lblLevel.Text = "Nível: 1 / 30";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblInfo.Location = new System.Drawing.Point(200, 70);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(470, 20);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "🔨 MARTELE AS TOPEIRAS PARA LIBERAR O PRÊMIO!";
            // 
            // btnMovel
            // 
            this.btnMovel.BackgroundImage = global::sei_la.Properties.Resources.Captura_de_tela_2026_10_13_210608;
            this.btnMovel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMovel.FlatAppearance.BorderSize = 0;
            this.btnMovel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMovel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnMovel.Location = new System.Drawing.Point(350, 150);
            this.btnMovel.Name = "btnMovel";
            this.btnMovel.Size = new System.Drawing.Size(100, 100);
            this.btnMovel.TabIndex = 3;
            this.btnMovel.Text = "";
            this.btnMovel.UseVisualStyleBackColor = false;
            this.btnMovel.Click += new System.EventHandler(this.btnMovel_Click);
            // 
            // pnlVideo
            // 
            this.pnlVideo.BackColor = System.Drawing.Color.Black;
            this.pnlVideo.Controls.Add(this.lblVideo);
            this.pnlVideo.Controls.Add(this.btnClose);
            this.pnlVideo.Location = new System.Drawing.Point(200, 250);
            this.pnlVideo.Name = "pnlVideo";
            this.pnlVideo.Size = new System.Drawing.Size(450, 200);
            this.pnlVideo.TabIndex = 0;
            this.pnlVideo.Visible = false;
            // 
            // lblVideo
            // 
            this.lblVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVideo.ForeColor = System.Drawing.Color.White;
            this.lblVideo.Location = new System.Drawing.Point(50, 50);
            this.lblVideo.Name = "lblVideo";
            this.lblVideo.Size = new System.Drawing.Size(350, 50);
            this.lblVideo.TabIndex = 0;
            this.lblVideo.Text = "🎬 VÍDEO DE RECOMPENSA 🎬\n(Aqui vai seu vídeo)";
            this.lblVideo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(180, 130);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Fechar e Reiniciar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(830, 450);
            this.Controls.Add(this.pnlVideo);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.btnMovel);
            this.Name = "Form1";
            this.Text = "Jogo da Toupeira - Nível 30";
            this.pnlVideo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnMovel;
        private System.Windows.Forms.Panel pnlVideo;
        private System.Windows.Forms.Label lblVideo;
        private System.Windows.Forms.Button btnClose;
    }
}