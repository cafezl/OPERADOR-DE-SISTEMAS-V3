namespace preimeiro
{
    partial class frm_terceira
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_terceira));
            this.btn_tela1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_tela1
            // 
            this.btn_tela1.Location = new System.Drawing.Point(111, 172);
            this.btn_tela1.Name = "btn_tela1";
            this.btn_tela1.Size = new System.Drawing.Size(98, 90);
            this.btn_tela1.TabIndex = 0;
            this.btn_tela1.Text = "Tela 1";
            this.btn_tela1.UseVisualStyleBackColor = true;
            this.btn_tela1.Click += new System.EventHandler(this.btn_tela1_Click);
            // 
            // frm_terceira
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::preimeiro.Properties.Resources.Espada3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(801, 457);
            this.Controls.Add(this.btn_tela1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_terceira";
            this.Text = "Terceira";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_terceira_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_tela1;
    }
}