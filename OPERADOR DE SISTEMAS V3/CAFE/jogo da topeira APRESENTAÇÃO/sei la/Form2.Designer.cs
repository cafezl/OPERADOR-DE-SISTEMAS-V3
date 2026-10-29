namespace sei_la
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.Label lblPontos;
        private System.Windows.Forms.Label lblRestantes;
        private System.Windows.Forms.Label lblInstrucao;

        protected override void Dispose(bool disposing)
        {
            if (disposing) LiberarRecursos();
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Forms Designer

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.lblNivel = new System.Windows.Forms.Label();
            this.lblPontos = new System.Windows.Forms.Label();
            this.lblRestantes = new System.Windows.Forms.Label();
            this.lblInstrucao = new System.Windows.Forms.Label();
            this.btnPausa = new System.Windows.Forms.Button();
            this.btnSom = new System.Windows.Forms.Button();
            this.progresso = new System.Windows.Forms.ProgressBar();
            this.lblAjuda = new System.Windows.Forms.Label();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // Preview background and controls follow the running game. Form2_Load
            // replaces these static sample controls with the live game controls.
            //
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("partidaPreview")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblNivel.AutoSize = false;
            this.lblNivel.BackColor = System.Drawing.Color.Transparent;
            this.lblNivel.Font = new System.Drawing.Font("Consolas", 17F, System.Drawing.FontStyle.Bold);
            this.lblNivel.ForeColor = System.Drawing.Color.FromArgb(255, 211, 96);
            this.lblNivel.Location = new System.Drawing.Point(54, 10);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(170, 38);
            this.lblNivel.Text = "0 / 50";
            this.lblNivel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNivel.Click += new System.EventHandler(this.lblNivel_Click);
            this.lblPontos.AutoSize = false;
            this.lblPontos.BackColor = System.Drawing.Color.Transparent;
            this.lblPontos.Font = new System.Drawing.Font("Consolas", 17F, System.Drawing.FontStyle.Bold);
            this.lblPontos.ForeColor = System.Drawing.Color.FromArgb(255, 211, 96);
            this.lblPontos.Location = new System.Drawing.Point(269, 10);
            this.lblPontos.Name = "lblPontos";
            this.lblPontos.Size = new System.Drawing.Size(200, 38);
            this.lblPontos.Text = "0 pontos";
            this.lblPontos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPontos.Click += new System.EventHandler(this.lblPontos_Click);
            this.lblRestantes.AutoSize = false;
            this.lblRestantes.BackColor = System.Drawing.Color.Transparent;
            this.lblRestantes.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.lblRestantes.ForeColor = System.Drawing.Color.Yellow;
            this.lblRestantes.Location = new System.Drawing.Point(20, 48);
            this.lblRestantes.Name = "lblRestantes";
            this.lblRestantes.Size = new System.Drawing.Size(320, 22);
            this.lblRestantes.Text = "Toupeiras restantes: 50";
            this.lblRestantes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRestantes.Click += new System.EventHandler(this.lblRestantes_Click);
            this.lblInstrucao.AutoSize = false;
            this.lblInstrucao.BackColor = System.Drawing.Color.Transparent;
            this.lblInstrucao.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.lblInstrucao.ForeColor = System.Drawing.Color.FromArgb(173, 218, 188);
            this.lblInstrucao.Location = new System.Drawing.Point(20, 76);
            this.lblInstrucao.Name = "lblInstrucao";
            this.lblInstrucao.Size = new System.Drawing.Size(730, 26);
            this.lblInstrucao.Text = "SUA MISSÃO • proteja o jardim e devolva a paz à ilha";
            this.lblInstrucao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInstrucao.Click += new System.EventHandler(this.lblInstrucao_Click);
            this.btnSom.BackColor = System.Drawing.Color.FromArgb(20, 54, 45);
            this.btnSom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSom.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSom.Location = new System.Drawing.Point(749, 15);
            this.btnSom.Name = "btnSom";
            this.btnSom.Size = new System.Drawing.Size(135, 34);
            this.btnSom.Text = "SOM: ON";
            this.btnSom.UseVisualStyleBackColor = false;
            this.btnSom.Click += delegate { AlternarSom(); };
            this.btnPausa.BackColor = System.Drawing.Color.FromArgb(20, 54, 45);
            this.btnPausa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPausa.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPausa.Location = new System.Drawing.Point(894, 15);
            this.btnPausa.Name = "btnPausa";
            this.btnPausa.Size = new System.Drawing.Size(110, 34);
            this.btnPausa.Text = "PAUSAR";
            this.btnPausa.UseVisualStyleBackColor = false;
            this.btnPausa.Click += delegate { Pausar(); };
            this.progresso.Location = new System.Drawing.Point(0, 105);
            this.progresso.Maximum = 50;
            this.progresso.Name = "progresso";
            this.progresso.Size = new System.Drawing.Size(1024, 8);
            this.progresso.TabStop = false;
            this.lblAjuda.AutoSize = false;
            this.lblAjuda.BackColor = System.Drawing.Color.Transparent;
            this.lblAjuda.Font = new System.Drawing.Font("Consolas", 10F);
            this.lblAjuda.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblAjuda.Location = new System.Drawing.Point(14, 596);
            this.lblAjuda.Name = "lblAjuda";
            this.lblAjuda.Size = new System.Drawing.Size(744, 44);
            this.lblAjuda.Text = "Clique na toupeira • Esc: pausa • M: som • F11: tela cheia";
            this.lblAjuda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSituacao.AutoSize = false;
            this.lblSituacao.BackColor = System.Drawing.Color.Transparent;
            this.lblSituacao.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.lblSituacao.ForeColor = System.Drawing.Color.FromArgb(255, 210, 92);
            this.lblSituacao.Location = new System.Drawing.Point(764, 596);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(246, 44);
            this.lblSituacao.Text = "Recorde: 0";
            this.lblSituacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // Form2
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1024, 640);
            this.Controls.Add(this.lblNivel);
            this.Controls.Add(this.lblPontos);
            this.Controls.Add(this.lblRestantes);
            this.Controls.Add(this.lblInstrucao);
            this.Controls.Add(this.btnSom);
            this.Controls.Add(this.btnPausa);
            this.Controls.Add(this.progresso);
            this.Controls.Add(this.lblAjuda);
            this.Controls.Add(this.lblSituacao);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 560);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ilha da Toupeira • Proteja o jardim";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
