namespace WindowsFormsApp
{
    partial class IgracStatistikaUC
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
            this.slika = new System.Windows.Forms.PictureBox();
            this.lblIme = new System.Windows.Forms.Label();
            this.lblGolovi = new System.Windows.Forms.Label();
            this.lblZuti = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.slika)).BeginInit();
            this.SuspendLayout();
            // 
            // slika
            // 
            this.slika.Location = new System.Drawing.Point(3, 3);
            this.slika.Name = "slika";
            this.slika.Size = new System.Drawing.Size(67, 55);
            this.slika.TabIndex = 0;
            this.slika.TabStop = false;
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Location = new System.Drawing.Point(112, 23);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(30, 17);
            this.lblIme.TabIndex = 1;
            this.lblIme.Text = "Ime";
            // 
            // lblGolovi
            // 
            this.lblGolovi.AutoSize = true;
            this.lblGolovi.Location = new System.Drawing.Point(325, 23);
            this.lblGolovi.Name = "lblGolovi";
            this.lblGolovi.Size = new System.Drawing.Size(48, 17);
            this.lblGolovi.TabIndex = 2;
            this.lblGolovi.Text = "Golovi";
            // 
            // lblZuti
            // 
            this.lblZuti.AutoSize = true;
            this.lblZuti.Location = new System.Drawing.Point(407, 23);
            this.lblZuti.Name = "lblZuti";
            this.lblZuti.Size = new System.Drawing.Size(32, 17);
            this.lblZuti.TabIndex = 3;
            this.lblZuti.Text = "Zuti";
            // 
            // IgracStatistikaUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblZuti);
            this.Controls.Add(this.lblGolovi);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.slika);
            this.Name = "IgracStatistikaUC";
            this.Size = new System.Drawing.Size(446, 61);
            ((System.ComponentModel.ISupportInitialize)(this.slika)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox slika;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label lblGolovi;
        private System.Windows.Forms.Label lblZuti;
    }
}
