namespace novo_projeto
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTarefa;
        private System.Windows.Forms.Label lblPrioridade;
        private System.Windows.Forms.Label lblPrazo;
        private System.Windows.Forms.Label lblResumo;
        private System.Windows.Forms.TextBox txtTarefa;
        private System.Windows.Forms.ComboBox cboPrioridade;
        private System.Windows.Forms.DateTimePicker dtpPrazo;
        private System.Windows.Forms.ListView lstTarefas;
        private System.Windows.Forms.ColumnHeader colTarefa;
        private System.Windows.Forms.ColumnHeader colPrioridade;
        private System.Windows.Forms.ColumnHeader colPrazo;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnLimparConcluidas;

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
            this.components = new System.ComponentModel.Container();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTarefa = new System.Windows.Forms.Label();
            this.lblPrioridade = new System.Windows.Forms.Label();
            this.lblPrazo = new System.Windows.Forms.Label();
            this.lblResumo = new System.Windows.Forms.Label();
            this.txtTarefa = new System.Windows.Forms.TextBox();
            this.cboPrioridade = new System.Windows.Forms.ComboBox();
            this.dtpPrazo = new System.Windows.Forms.DateTimePicker();
            this.lstTarefas = new System.Windows.Forms.ListView();
            this.colTarefa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrioridade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrazo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnLimparConcluidas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(35, 56, 74);
            this.lblTitulo.Location = new System.Drawing.Point(26, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(350, 41);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gerenciador de tarefas";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblSubtitulo.Location = new System.Drawing.Point(31, 65);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(345, 15);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Organize atividades, defina prioridades e acompanhe o progresso.";
            // 
            // lblTarefa
            // 
            this.lblTarefa.AutoSize = true;
            this.lblTarefa.Location = new System.Drawing.Point(28, 105);
            this.lblTarefa.Name = "lblTarefa";
            this.lblTarefa.Size = new System.Drawing.Size(62, 15);
            this.lblTarefa.TabIndex = 2;
            this.lblTarefa.Text = "Descrição";
            // 
            // lblPrioridade
            // 
            this.lblPrioridade.AutoSize = true;
            this.lblPrioridade.Location = new System.Drawing.Point(400, 105);
            this.lblPrioridade.Name = "lblPrioridade";
            this.lblPrioridade.Size = new System.Drawing.Size(59, 15);
            this.lblPrioridade.TabIndex = 3;
            this.lblPrioridade.Text = "Prioridade";
            // 
            // lblPrazo
            // 
            this.lblPrazo.AutoSize = true;
            this.lblPrazo.Location = new System.Drawing.Point(535, 105);
            this.lblPrazo.Name = "lblPrazo";
            this.lblPrazo.Size = new System.Drawing.Size(36, 15);
            this.lblPrazo.TabIndex = 4;
            this.lblPrazo.Text = "Prazo";
            // 
            // txtTarefa
            // 
            this.txtTarefa.Location = new System.Drawing.Point(31, 128);
            this.txtTarefa.MaxLength = 150;
            this.txtTarefa.Name = "txtTarefa";
            this.txtTarefa.Size = new System.Drawing.Size(350, 23);
            this.txtTarefa.TabIndex = 5;
            // 
            // cboPrioridade
            // 
            this.cboPrioridade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrioridade.FormattingEnabled = true;
            this.cboPrioridade.Items.AddRange(new object[] { "Alta", "Média", "Baixa" });
            this.cboPrioridade.Location = new System.Drawing.Point(403, 128);
            this.cboPrioridade.Name = "cboPrioridade";
            this.cboPrioridade.Size = new System.Drawing.Size(116, 23);
            this.cboPrioridade.TabIndex = 6;
            // 
            // dtpPrazo
            // 
            this.dtpPrazo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPrazo.Location = new System.Drawing.Point(538, 128);
            this.dtpPrazo.Name = "dtpPrazo";
            this.dtpPrazo.Size = new System.Drawing.Size(130, 23);
            this.dtpPrazo.TabIndex = 7;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.FromArgb(39, 119, 91);
            this.btnAdicionar.FlatAppearance.BorderSize = 0;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.ForeColor = System.Drawing.Color.White;
            this.btnAdicionar.Location = new System.Drawing.Point(686, 125);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(176, 29);
            this.btnAdicionar.TabIndex = 8;
            this.btnAdicionar.Text = "Adicionar tarefa";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // lstTarefas
            // 
            this.lstTarefas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTarefas.CheckBoxes = true;
            this.lstTarefas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.colTarefa, this.colPrioridade, this.colPrazo, this.colStatus });
            this.lstTarefas.FullRowSelect = true;
            this.lstTarefas.GridLines = true;
            this.lstTarefas.HideSelection = false;
            this.lstTarefas.Location = new System.Drawing.Point(31, 183);
            this.lstTarefas.MultiSelect = false;
            this.lstTarefas.Name = "lstTarefas";
            this.lstTarefas.Size = new System.Drawing.Size(831, 325);
            this.lstTarefas.TabIndex = 9;
            this.lstTarefas.UseCompatibleStateImageBehavior = false;
            this.lstTarefas.View = System.Windows.Forms.View.Details;
            this.lstTarefas.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstTarefas_ItemChecked);
            this.lstTarefas.SelectedIndexChanged += new System.EventHandler(this.lstTarefas_SelectedIndexChanged);
            // 
            // colTarefa
            // 
            this.colTarefa.Text = "Tarefa (marque ao concluir)";
            this.colTarefa.Width = 430;
            // 
            // colPrioridade
            // 
            this.colPrioridade.Text = "Prioridade";
            this.colPrioridade.Width = 120;
            // 
            // colPrazo
            // 
            this.colPrazo.Text = "Prazo";
            this.colPrazo.Width = 130;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Situação";
            this.colStatus.Width = 130;
            // 
            // btnRemover
            // 
            this.btnRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemover.Enabled = false;
            this.btnRemover.Location = new System.Drawing.Point(31, 526);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(166, 32);
            this.btnRemover.TabIndex = 10;
            this.btnRemover.Text = "Remover selecionada";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnLimparConcluidas
            // 
            this.btnLimparConcluidas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimparConcluidas.Enabled = false;
            this.btnLimparConcluidas.Location = new System.Drawing.Point(211, 526);
            this.btnLimparConcluidas.Name = "btnLimparConcluidas";
            this.btnLimparConcluidas.Size = new System.Drawing.Size(166, 32);
            this.btnLimparConcluidas.TabIndex = 11;
            this.btnLimparConcluidas.Text = "Limpar concluídas";
            this.btnLimparConcluidas.UseVisualStyleBackColor = true;
            this.btnLimparConcluidas.Click += new System.EventHandler(this.btnLimparConcluidas_Click);
            // 
            // lblResumo
            // 
            this.lblResumo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResumo.AutoSize = true;
            this.lblResumo.ForeColor = System.Drawing.Color.FromArgb(35, 56, 74);
            this.lblResumo.Location = new System.Drawing.Point(540, 535);
            this.lblResumo.Name = "lblResumo";
            this.lblResumo.Size = new System.Drawing.Size(322, 15);
            this.lblResumo.TabIndex = 12;
            this.lblResumo.Text = "Tarefas: 0    Concluídas: 0    Pendentes: 0";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnAdicionar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(246, 248, 249);
            this.ClientSize = new System.Drawing.Size(900, 590);
            this.Controls.Add(this.lblResumo);
            this.Controls.Add(this.btnLimparConcluidas);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.lstTarefas);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.dtpPrazo);
            this.Controls.Add(this.cboPrioridade);
            this.Controls.Add(this.txtTarefa);
            this.Controls.Add(this.lblPrazo);
            this.Controls.Add(this.lblPrioridade);
            this.Controls.Add(this.lblTarefa);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblTitulo);
            this.MinimumSize = new System.Drawing.Size(760, 560);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciador de tarefas";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}