namespace sei_la
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing) LiberarRecursos();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.lblNivel = new System.Windows.Forms.Label();
            this.lblPontos = new System.Windows.Forms.Label();
            this.lblRestantes = new System.Windows.Forms.Label();
            this.lblInstrucao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.BackColor = System.Drawing.Color.Black;
            this.lblNivel.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold);
            this.lblNivel.ForeColor = System.Drawing.Color.Yellow;
            this.lblNivel.Location = new System.Drawing.Point(20, 20);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(152, 31);
            this.lblNivel.TabIndex = 0;
            this.lblNivel.Text = "Nível: 1 / 30";
            this.lblNivel.Click += new System.EventHandler(this.lblNivel_Click);
            // 
            // lblPontos
            // 
            this.lblPontos.AutoSize = true;
            this.lblPontos.BackColor = System.Drawing.Color.Black;
            this.lblPontos.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold);
            this.lblPontos.ForeColor = System.Drawing.Color.Yellow;
            this.lblPontos.Location = new System.Drawing.Point(20, 60);
            this.lblPontos.Name = "lblPontos";
            this.lblPontos.Size = new System.Drawing.Size(126, 31);
            this.lblPontos.TabIndex = 1;
            this.lblPontos.Text = "Pontos: 0";
            this.lblPontos.Click += new System.EventHandler(this.lblPontos_Click);
            // 
            // lblRestantes
            // 
            this.lblRestantes.AutoSize = true;
            this.lblRestantes.BackColor = System.Drawing.Color.Black;
            this.lblRestantes.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold);
            this.lblRestantes.ForeColor = System.Drawing.Color.Yellow;
            this.lblRestantes.Location = new System.Drawing.Point(20, 100);
            this.lblRestantes.Name = "lblRestantes";
            this.lblRestantes.Size = new System.Drawing.Size(301, 31);
            this.lblRestantes.TabIndex = 2;
            this.lblRestantes.Text = "Toupeiras restantes: 10";
            this.lblRestantes.Click += new System.EventHandler(this.lblRestantes_Click);
            // 
            // lblInstrucao
            // 
            this.lblInstrucao.AutoSize = true;
            this.lblInstrucao.BackColor = System.Drawing.Color.Black;
            this.lblInstrucao.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold);
            this.lblInstrucao.ForeColor = System.Drawing.Color.White;
            this.lblInstrucao.Location = new System.Drawing.Point(602, 39);
            this.lblInstrucao.Name = "lblInstrucao";
            this.lblInstrucao.Size = new System.Drawing.Size(352, 27);
            this.lblInstrucao.TabIndex = 3;
            this.lblInstrucao.Text = "🔨 MARTELE AS TOUPEIRAS! 🔨";
            this.lblInstrucao.Click += new System.EventHandler(this.lblInstrucao_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::sei_la.Properties.Resources.textura_de_grama;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1676, 823);
            this.Controls.Add(this.lblInstrucao);
            this.Controls.Add(this.lblRestantes);
            this.Controls.Add(this.lblPontos);
            this.Controls.Add(this.lblNivel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jogo da Toupeira";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
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
