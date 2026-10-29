namespace sei_la
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
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
            this.cenario = new sei_la.CenarioMenu();
            this.btnStart = new sei_la.BotaoAventura();
            this.btnLoadGame = new sei_la.BotaoAventura();
            this.btnPassword = new sei_la.BotaoAventura();
            this.btnOptions = new sei_la.BotaoAventura();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblAtalhos = new System.Windows.Forms.Label();
            this.cenario.SuspendLayout();
            this.SuspendLayout();
            //
            // Menu preview: positions and labels match the opening screen at runtime.
            //
            this.btnStart.Location = new System.Drawing.Point(90, 310);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(470, 60);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "START";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnLoadGame.Location = new System.Drawing.Point(90, 375);
            this.btnLoadGame.Name = "btnLoadGame";
            this.btnLoadGame.Size = new System.Drawing.Size(470, 60);
            this.btnLoadGame.TabIndex = 1;
            this.btnLoadGame.Text = "A LENDA DA ILHA";
            this.btnLoadGame.Click += new System.EventHandler(this.btnLoadGame_Click);
            this.btnPassword.Location = new System.Drawing.Point(90, 440);
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.Size = new System.Drawing.Size(470, 60);
            this.btnPassword.TabIndex = 2;
            this.btnPassword.Text = "PASSWORD";
            this.btnPassword.Click += new System.EventHandler(this.btnPassword_Click);
            this.btnOptions.Location = new System.Drawing.Point(90, 505);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(470, 60);
            this.btnOptions.TabIndex = 3;
            this.btnOptions.Text = "OPTIONS";
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            this.lblStatus.AutoSize = false;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 215, 100);
            this.lblStatus.Location = new System.Drawing.Point(110, 603);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(880, 30);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Visitante • 0/50 salvos • recorde 0";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAtalhos.AutoSize = false;
            this.lblAtalhos.BackColor = System.Drawing.Color.Transparent;
            this.lblAtalhos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAtalhos.ForeColor = System.Drawing.Color.FromArgb(230, 237, 231);
            this.lblAtalhos.Location = new System.Drawing.Point(110, 640);
            this.lblAtalhos.Name = "lblAtalhos";
            this.lblAtalhos.Size = new System.Drawing.Size(900, 28);
            this.lblAtalhos.TabIndex = 5;
            this.lblAtalhos.Text = "↑ ↓ e Enter ou mouse • F11: tela cheia • Esc: voltar";
            this.lblAtalhos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cenario
            //
            this.cenario.Controls.Add(this.btnStart);
            this.cenario.Controls.Add(this.btnLoadGame);
            this.cenario.Controls.Add(this.btnPassword);
            this.cenario.Controls.Add(this.btnOptions);
            this.cenario.Controls.Add(this.lblStatus);
            this.cenario.Controls.Add(this.lblAtalhos);
            this.cenario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cenario.Location = new System.Drawing.Point(0, 0);
            this.cenario.Name = "cenario";
            this.cenario.Size = new System.Drawing.Size(1100, 690);
            this.cenario.TabIndex = 0;
            //
            // Form1
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1100, 690);
            this.Controls.Add(this.cenario);
            this.MinimumSize = new System.Drawing.Size(820, 560);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ilha da Toupeira • Café";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cenario.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
