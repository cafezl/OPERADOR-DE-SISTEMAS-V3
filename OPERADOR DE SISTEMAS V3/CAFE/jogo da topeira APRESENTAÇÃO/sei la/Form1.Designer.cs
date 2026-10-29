namespace sei_la
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureMenu;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnLoadGame;
        private System.Windows.Forms.Button btnPassword;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblAtalhos;

        protected override void Dispose(bool disposing)
        {
            if (disposing) LiberarRecursosMenu();
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Forms Designer

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureMenu = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnLoadGame = new System.Windows.Forms.Button();
            this.btnPassword = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblAtalhos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMenu)).BeginInit();
            this.SuspendLayout();
            //
            // pictureMenu: imagem de prévia estática; o jogo desenha o cenário ao executar.
            //
            this.pictureMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureMenu.Image = ((System.Drawing.Image)(resources.GetObject("menuPreview")));
            this.pictureMenu.Location = new System.Drawing.Point(0, 0);
            this.pictureMenu.Name = "pictureMenu";
            this.pictureMenu.Size = new System.Drawing.Size(1100, 690);
            this.pictureMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureMenu.TabStop = false;
            //
            // Menu: os nomes, tamanhos e posições acompanham a tela inicial.
            //
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(31, 49, 34);
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(170, 125, 60);
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Arial Black", 22F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.FromArgb(255, 225, 155);
            this.btnStart.Location = new System.Drawing.Point(90, 310);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(470, 60);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "▶ START";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnLoadGame.BackColor = System.Drawing.Color.FromArgb(31, 49, 34);
            this.btnLoadGame.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(170, 125, 60);
            this.btnLoadGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadGame.Font = new System.Drawing.Font("Arial Black", 22F, System.Drawing.FontStyle.Bold);
            this.btnLoadGame.ForeColor = System.Drawing.Color.FromArgb(255, 225, 155);
            this.btnLoadGame.Location = new System.Drawing.Point(90, 375);
            this.btnLoadGame.Name = "btnLoadGame";
            this.btnLoadGame.Size = new System.Drawing.Size(470, 60);
            this.btnLoadGame.TabIndex = 1;
            this.btnLoadGame.Text = "A LENDA DA ILHA";
            this.btnLoadGame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadGame.UseVisualStyleBackColor = false;
            this.btnLoadGame.Click += new System.EventHandler(this.btnLoadGame_Click);
            this.btnPassword.BackColor = System.Drawing.Color.FromArgb(31, 49, 34);
            this.btnPassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(170, 125, 60);
            this.btnPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPassword.Font = new System.Drawing.Font("Arial Black", 22F, System.Drawing.FontStyle.Bold);
            this.btnPassword.ForeColor = System.Drawing.Color.FromArgb(255, 225, 155);
            this.btnPassword.Location = new System.Drawing.Point(90, 440);
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.Size = new System.Drawing.Size(470, 60);
            this.btnPassword.TabIndex = 2;
            this.btnPassword.Text = "PASSWORD";
            this.btnPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPassword.UseVisualStyleBackColor = false;
            this.btnPassword.Click += new System.EventHandler(this.btnPassword_Click);
            this.btnOptions.BackColor = System.Drawing.Color.FromArgb(31, 49, 34);
            this.btnOptions.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(170, 125, 60);
            this.btnOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptions.Font = new System.Drawing.Font("Arial Black", 22F, System.Drawing.FontStyle.Bold);
            this.btnOptions.ForeColor = System.Drawing.Color.FromArgb(255, 225, 155);
            this.btnOptions.Location = new System.Drawing.Point(90, 505);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(470, 60);
            this.btnOptions.TabIndex = 3;
            this.btnOptions.Text = "OPTIONS";
            this.btnOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOptions.UseVisualStyleBackColor = false;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            this.lblStatus.AutoSize = false;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 215, 100);
            this.lblStatus.Location = new System.Drawing.Point(110, 603);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(880, 30);
            this.lblStatus.Text = "Visitante • 0/50 salvos • recorde 0";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAtalhos.AutoSize = false;
            this.lblAtalhos.BackColor = System.Drawing.Color.Transparent;
            this.lblAtalhos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAtalhos.ForeColor = System.Drawing.Color.FromArgb(230, 237, 231);
            this.lblAtalhos.Location = new System.Drawing.Point(110, 640);
            this.lblAtalhos.Name = "lblAtalhos";
            this.lblAtalhos.Size = new System.Drawing.Size(900, 28);
            this.lblAtalhos.Text = "↑ ↓ e Enter ou mouse • F11: tela cheia • Esc: voltar";
            this.lblAtalhos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // Form1
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1100, 690);
            this.Controls.Add(this.pictureMenu);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnLoadGame);
            this.Controls.Add(this.btnPassword);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblAtalhos);
            this.Controls.SetChildIndex(this.pictureMenu, this.Controls.Count - 1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(820, 560);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ilha da Toupeira • Café";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureMenu)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
