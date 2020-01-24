namespace WindowsFormsApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCro = new System.Windows.Forms.Button();
            this.btnEng = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCro
            // 
            resources.ApplyResources(this.btnCro, "btnCro");
            this.btnCro.Name = "btnCro";
            this.btnCro.UseVisualStyleBackColor = true;
            this.btnCro.Click += new System.EventHandler(this.btnCro_Click);
            // 
            // btnEng
            // 
            resources.ApplyResources(this.btnEng, "btnEng");
            this.btnEng.Name = "btnEng";
            this.btnEng.UseVisualStyleBackColor = true;
            this.btnEng.Click += new System.EventHandler(this.btnEng_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEng);
            this.Controls.Add(this.btnCro);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCro;
        private System.Windows.Forms.Button btnEng;
        private System.Windows.Forms.Label label1;
    }
}

