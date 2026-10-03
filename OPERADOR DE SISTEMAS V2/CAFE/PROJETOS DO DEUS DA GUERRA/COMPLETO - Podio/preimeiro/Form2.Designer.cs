namespace preimeiro
{
    partial class frm_segundo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_segundo));
            this.btn_tela3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_tela3
            // 
            this.btn_tela3.Location = new System.Drawing.Point(541, 314);
            this.btn_tela3.Name = "btn_tela3";
            this.btn_tela3.Size = new System.Drawing.Size(106, 93);
            this.btn_tela3.TabIndex = 0;
            this.btn_tela3.Text = "Tela 3";
            this.btn_tela3.UseVisualStyleBackColor = true;
            this.btn_tela3.Click += new System.EventHandler(this.btn_tela3_Click);
            // 
            // frm_segundo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::preimeiro.Properties.Resources.Espada2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(722, 469);
            this.Controls.Add(this.btn_tela3);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_segundo";
            this.Text = "Segundo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_segundo_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_tela3;
    }
}