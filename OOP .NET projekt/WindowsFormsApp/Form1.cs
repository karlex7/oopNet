using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {

        //string path = Environment.CurrentDirectory + "/" + "lang.txt";
        string path = @"C:\Users\FRIDAY\Documents\OPP .NET projekt\OOP .NET projekt\lang.txt";
        public Form1()
        {
            InitializeComponent();
        }


        private void btnCro_Click(object sender, EventArgs e)
        {
            setHRLang();
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("hr");
            }
            Application.Restart();
        }

        private void btnEng_Click(object sender, EventArgs e)
        {
            setENGLang();
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("en");
            }
            Application.Restart();
        }

        private void openSecondForm()
        {
            Form2 form2 = new Form2();
            form2.Show();
            Visible = false;
        }
        private void setHRLang()
        {
            var utils = new Utils.Utils();
            utils.UpdateConfig("language", "hr");
            
        }
        private void setENGLang()
        {
            var utils = new Utils.Utils();
            utils.UpdateConfig("language", "en-GB");
            
        }
    }
}
