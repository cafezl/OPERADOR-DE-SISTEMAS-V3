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
            // Componentes do formulário
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnLoadGame = new System.Windows.Forms.Button();
            this.btnPassword = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // ============================================
            // lblTitulo - Título do jogo (estilo Crash)
            // ============================================
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.Yellow;
            this.lblTitulo.Location = new System.Drawing.Point(150, 50);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(500, 68);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "JOGO DA TOUPEIRA";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ============================================
            // btnStart - Botão START (verde, como no Crash)
            // ============================================
            this.btnStart.BackColor = System.Drawing.Color.Green;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Arial Black", 20F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(250, 180);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(300, 60);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "▶ START";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            // ============================================
            // btnLoadGame - Botão LOAD GAME (laranja)
            // ============================================
            this.btnLoadGame.BackColor = System.Drawing.Color.Orange;
            this.btnLoadGame.FlatAppearance.BorderSize = 0;
            this.btnLoadGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadGame.Font = new System.Drawing.Font("Arial Black", 20F, System.Drawing.FontStyle.Bold);
            this.btnLoadGame.ForeColor = System.Drawing.Color.White;
            this.btnLoadGame.Location = new System.Drawing.Point(250, 260);
            this.btnLoadGame.Name = "btnLoadGame";
            this.btnLoadGame.Size = new System.Drawing.Size(300, 60);
            this.btnLoadGame.TabIndex = 2;
            this.btnLoadGame.Text = "LOAD GAME";
            this.btnLoadGame.UseVisualStyleBackColor = false;
            this.btnLoadGame.Click += new System.EventHandler(this.btnLoadGame_Click);

            // ============================================
            // btnPassword - Botão PASSWORD (vermelho)
            // ============================================
            this.btnPassword.BackColor = System.Drawing.Color.Red;
            this.btnPassword.FlatAppearance.BorderSize = 0;
            this.btnPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPassword.Font = new System.Drawing.Font("Arial Black", 20F, System.Drawing.FontStyle.Bold);
            this.btnPassword.ForeColor = System.Drawing.Color.White;
            this.btnPassword.Location = new System.Drawing.Point(250, 340);
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.Size = new System.Drawing.Size(300, 60);
            this.btnPassword.TabIndex = 3;
            this.btnPassword.Text = "PASSWORD";
            this.btnPassword.UseVisualStyleBackColor = false;
            this.btnPassword.Click += new System.EventHandler(this.btnPassword_Click);

            // ============================================
            // btnOptions - Botão OPTIONS (azul)
            // ============================================
            this.btnOptions.BackColor = System.Drawing.Color.Blue;
            this.btnOptions.FlatAppearance.BorderSize = 0;
            this.btnOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptions.Font = new System.Drawing.Font("Arial Black", 20F, System.Drawing.FontStyle.Bold);
            this.btnOptions.ForeColor = System.Drawing.Color.White;
            this.btnOptions.Location = new System.Drawing.Point(250, 420);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(300, 60);
            this.btnOptions.TabIndex = 4;
            this.btnOptions.Text = "OPTIONS";
            this.btnOptions.UseVisualStyleBackColor = false;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);

            // ============================================
            // Form1 - Configurações do formulário
            // ============================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::sei_la.Properties.Resources.textura_de_gramia;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnPassword);
            this.Controls.Add(this.btnLoadGame);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblTitulo);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jogo da Toupeira - Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnLoadGame;
        private System.Windows.Forms.Button btnPassword;
        private System.Windows.Forms.Button btnOptions;
    }
}