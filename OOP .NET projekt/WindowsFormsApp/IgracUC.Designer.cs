namespace WindowsFormsApp
{
    partial class IgracUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbIme = new System.Windows.Forms.Label();
            this.lbBroj = new System.Windows.Forms.Label();
            this.lbPozicija = new System.Windows.Forms.Label();
            this.lbKapetan = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbIme
            // 
            this.lbIme.AutoSize = true;
            this.lbIme.Location = new System.Drawing.Point(129, 24);
            this.lbIme.Name = "lbIme";
            this.lbIme.Size = new System.Drawing.Size(30, 17);
            this.lbIme.TabIndex = 0;
            this.lbIme.Text = "Ime";
            // 
            // lbBroj
            // 
            this.lbBroj.AutoSize = true;
            this.lbBroj.Location = new System.Drawing.Point(343, 24);
            this.lbBroj.Name = "lbBroj";
            this.lbBroj.Size = new System.Drawing.Size(33, 17);
            this.lbBroj.TabIndex = 1;
            this.lbBroj.Text = "Broj";
            // 
            // lbPozicija
            // 
            this.lbPozicija.AutoSize = true;
            this.lbPozicija.Location = new System.Drawing.Point(382, 24);
            this.lbPozicija.Name = "lbPozicija";
            this.lbPozicija.Size = new System.Drawing.Size(56, 17);
            this.lbPozicija.TabIndex = 2;
            this.lbPozicija.Text = "Pozicija";
            // 
            // lbKapetan
            // 
            this.lbKapetan.AutoSize = true;
            this.lbKapetan.Location = new System.Drawing.Point(458, 24);
            this.lbKapetan.Name = "lbKapetan";
            this.lbKapetan.Size = new System.Drawing.Size(61, 17);
            this.lbKapetan.TabIndex = 3;
            this.lbKapetan.Text = "Kapetan";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(19, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 58);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // IgracUC
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbKapetan);
            this.Controls.Add(this.lbPozicija);
            this.Controls.Add(this.lbBroj);
            this.Controls.Add(this.lbIme);
            this.Name = "IgracUC";
            this.Size = new System.Drawing.Size(522, 64);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbIme;
        private System.Windows.Forms.Label lbBroj;
        private System.Windows.Forms.Label lbPozicija;
        private System.Windows.Forms.Label lbKapetan;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
