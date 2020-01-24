using ClassLibrary;
using ClassLibrary.MODEL;
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
using WindowsFormsApp.MODEL;

namespace WindowsFormsApp
{
    public partial class Form2 : Form
    {
        string path = Environment.CurrentDirectory + "/" + "fifaCode.txt";

        public Form2()
        {
            InitializeComponent();
            ucitajDrzave();
            ucitajSpremljenuDrzavu();
        }


        private void ucitajDrzave()
        {
            IRepo repo = RepoFactory.getRepo();
            List<Country> countries = repo.getAllCountries();
            foreach (Country c in countries)
            {
                cbCountry.Items.Add(new CBItem(c.CountryName+" ("+c.FifaCode+")",c.FifaCode));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           CBItem cBItem = (CBItem)cbCountry.SelectedItem;
           label2.Text = cBItem.getID();
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(cBItem.ToString());
            }
        }
        private void ucitajSpremljenuDrzavu()
        {

            if (!File.Exists(path))
            {
                return;
            }
            else
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string text = sr.ReadLine();
                    cbCountry.SelectedIndex = cbCountry.FindStringExact(text);
                    cbCountry.SelectedValue = text;
                }
            }
                
        }
    }
}
