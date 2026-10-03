namespace VOTAÇÕES
{
    partial class Form3
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
            this.btn_tela1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_tela1
            // 
            this.btn_tela1.BackColor = System.Drawing.Color.Black;
            this.btn_tela1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btn_tela1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btn_tela1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tela1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_tela1.Location = new System.Drawing.Point(63, 73);
            this.btn_tela1.Name = "btn_tela1";
            this.btn_tela1.Size = new System.Drawing.Size(78, 68);
            this.btn_tela1.TabIndex = 0;
            this.btn_tela1.Text = "TELA 1";
            this.btn_tela1.UseVisualStyleBackColor = false;
            this.btn_tela1.Click += new System.EventHandler(this.btn_tela1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VOTAÇÕES.Properties.Resources.baixados__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_tela1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_tela1;
    }
}