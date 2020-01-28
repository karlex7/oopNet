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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.MODEL;

namespace WindowsFormsApp
{
    public partial class Form2 : Form
    {
        string path = Environment.CurrentDirectory + "/" + "fifaCode.txt";
        string pathFavouritePlayers = Environment.CurrentDirectory + "/" + "favouritePlayers.txt";
        public string savedFifaCode { get; set; }
        public string selectedFifaCode { get; set; }
        IRepo repo = RepoFactory.getRepo();
        Thread th;
        public Form2()
        {
            InitializeComponent();
            ucitajDrzave();
            ucitajSpremljenuDrzavu();
        }


        private void ucitajDrzave()
        {
            
            List<Country> countries = repo.getAllCountries();
            foreach (Country c in countries)
            {
                cbCountry.Items.Add(new CBItem(c.CountryName+" ("+c.FifaCode+")",c.FifaCode));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           CBItem cBItem = (CBItem)cbCountry.SelectedItem;
           label2.Text = cBItem.getID();//
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(cBItem.ToString());//
            }
            checkIfCountryChanged();
            this.Close();
            th = new Thread(openNewForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }


        private void openNewForm()
        {
            CBItem cBItem = (CBItem)cbCountry.SelectedItem;
            string fifaCode = cBItem.getID();

            Application.Run(new Form3(repo.GetStartingElevenForCountry(fifaCode)));
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
                    savedFifaCode = text;
                }
            }
                
        }
        private void checkIfCountryChanged()
        {
            if (!savedFifaCode.Equals(selectedFifaCode))
            {
                deleteFavouritePlayers();
            }
        }

        private void deleteFavouritePlayers()
        {
            if (!File.Exists(pathFavouritePlayers))
            {
                return;
            }
            else
            {
                File.Delete(pathFavouritePlayers);
            }
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            string selectedValue = cmb.Items[selectedIndex].ToString();
            selectedFifaCode = selectedValue;
        }
    }
}
