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
    public partial class Form5 : Form
    {
        string path = @"C:\Users\FRIDAY\Documents\OPP .NET projekt\OOP .NET projekt\lang.txt";
        public Form5()
        {
            InitializeComponent();
        }
        private void setHRLang()
        {
            var utils = new Utils.Utils();
            utils.UpdateConfig("language", "hr");
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("hr");
            }

            Application.Exit();
        }
        private void setENGLang()
        {
            var utils = new Utils.Utils();
            utils.UpdateConfig("language", "en-GB");
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("en");
            }

            Application.Exit();
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            setLang();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void setLang()
        {
            if (rbHrv.Checked)
            {
                setHRLang();
            }
            else
            {
                setENGLang();
            }
            Application.Restart();
        }

        private void Form5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {
                setLang();
            }
            if (e.KeyChar==(char)Keys.Escape)
            {
                Application.Restart();
            }
        }

    }
}
