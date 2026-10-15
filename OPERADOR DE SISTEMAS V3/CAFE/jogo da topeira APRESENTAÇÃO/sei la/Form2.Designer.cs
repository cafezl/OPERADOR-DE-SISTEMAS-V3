namespace sei_la
{
    partial class Form2
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
            // Componentes do formulário do jogo
            this.lblNivel = new System.Windows.Forms.Label();
            this.lblPontos = new System.Windows.Forms.Label();
            this.lblRestantes = new System.Windows.Forms.Label();
            this.lblInstrucao = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // ============================================
            // lblNivel - Mostra o nível atual
            // ============================================
            this.lblNivel.AutoSize = true;
            this.lblNivel.BackColor = System.Drawing.Color.Black;
            this.lblNivel.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold);
            this.lblNivel.ForeColor = System.Drawing.Color.Yellow;
            this.lblNivel.Location = new System.Drawing.Point(20, 20);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(200, 31);
            this.lblNivel.TabIndex = 0;
            this.lblNivel.Text = "Nível: 1 / 30";

            // ============================================
            // lblPontos - Mostra a pontuação
            // ============================================
            this.lblPontos.AutoSize = true;
            this.lblPontos.BackColor = System.Drawing.Color.Black;
            this.lblPontos.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold);
            this.lblPontos.ForeColor = System.Drawing.Color.Yellow;
            this.lblPontos.Location = new System.Drawing.Point(20, 60);
            this.lblPontos.Name = "lblPontos";
            this.lblPontos.Size = new System.Drawing.Size(200, 31);
            this.lblPontos.TabIndex = 1;
            this.lblPontos.Text = "Pontos: 0";

            // ============================================
            // lblRestantes - Mostra toupeiras restantes
            // ============================================
            this.lblRestantes.AutoSize = true;
            this.lblRestantes.BackColor = System.Drawing.Color.Black;
            this.lblRestantes.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold);
            this.lblRestantes.ForeColor = System.Drawing.Color.Yellow;
            this.lblRestantes.Location = new System.Drawing.Point(20, 100);
            this.lblRestantes.Name = "lblRestantes";
            this.lblRestantes.Size = new System.Drawing.Size(300, 31);
            this.lblRestantes.TabIndex = 2;
            this.lblRestantes.Text = "Toupeiras restantes: 10";

            // ============================================
            // lblInstrucao - Instrução do jogo
            // ============================================
            this.lblInstrucao.AutoSize = true;
            this.lblInstrucao.BackColor = System.Drawing.Color.Black;
            this.lblInstrucao.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold);
            this.lblInstrucao.ForeColor = System.Drawing.Color.White;
            this.lblInstrucao.Location = new System.Drawing.Point(250, 20);
            this.lblInstrucao.Name = "lblInstrucao";
            this.lblInstrucao.Size = new System.Drawing.Size(400, 27);
            this.lblInstrucao.TabIndex = 3;
            this.lblInstrucao.Text = "🔨 MARTELE AS TOUPEIRAS! 🔨";

            // ============================================
            // Form2 - Configurações do formulário do jogo
            // ============================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            // O BackgroundImage será definido dinamicamente pelo timer do GIF
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lblInstrucao);
            this.Controls.Add(this.lblRestantes);
            this.Controls.Add(this.lblPontos);
            this.Controls.Add(this.lblNivel);
            this.DoubleBuffered = true; // Evita flickering na animação
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jogo da Toupeira";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.Label lblPontos;
        private System.Windows.Forms.Label lblRestantes;
        private System.Windows.Forms.Label lblInstrucao;
    }
}