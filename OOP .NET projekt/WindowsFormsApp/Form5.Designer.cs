namespace WindowsFormsApp
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.rbHrv = new System.Windows.Forms.RadioButton();
            this.rbEng = new System.Windows.Forms.RadioButton();
            this.gbJezik = new System.Windows.Forms.GroupBox();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.gbJezik.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbHrv
            // 
            resources.ApplyResources(this.rbHrv, "rbHrv");
            this.rbHrv.Name = "rbHrv";
            this.rbHrv.TabStop = true;
            this.rbHrv.UseVisualStyleBackColor = true;
            // 
            // rbEng
            // 
            resources.ApplyResources(this.rbEng, "rbEng");
            this.rbEng.Name = "rbEng";
            this.rbEng.TabStop = true;
            this.rbEng.UseVisualStyleBackColor = true;
            // 
            // gbJezik
            // 
            this.gbJezik.Controls.Add(this.rbHrv);
            this.gbJezik.Controls.Add(this.rbEng);
            resources.ApplyResources(this.gbJezik, "gbJezik");
            this.gbJezik.Name = "gbJezik";
            this.gbJezik.TabStop = false;
            // 
            // btnPotvrdi
            // 
            resources.ApplyResources(this.btnPotvrdi, "btnPotvrdi");
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // btnOdustani
            // 
            resources.ApplyResources(this.btnOdustani, "btnOdustani");
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // Form5
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.gbJezik);
            this.KeyPreview = true;
            this.Name = "Form5";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form5_KeyPress);
            this.gbJezik.ResumeLayout(false);
            this.gbJezik.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton rbHrv;
        private System.Windows.Forms.RadioButton rbEng;
        private System.Windows.Forms.GroupBox gbJezik;
        private System.Windows.Forms.Button btnPotvrdi;
        private System.Windows.Forms.Button btnOdustani;
    }
}