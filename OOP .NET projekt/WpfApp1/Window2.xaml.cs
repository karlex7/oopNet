using ClassLibrary;
using ClassLibrary.MODEL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public string Fifa_Code { get; set; }
        string path = @"C:\Users\FRIDAY\Documents\OPP .NET projekt\OOP .NET projekt\full.txt";
        public Country Country { get; set; }
        IRepo repo = RepoFactory.getRepo();
        public Window2(string fifa_code)
        {
            if (!File.Exists(path))
            {
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.ShowDialog();
                this.Close();
            }
            else
            {
                setScreenSize();
            }
            Fifa_Code = fifa_code;
            InitializeComponent();
            dohvatiDrzavu();
        }
        private void setScreenSize()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string text = sr.ReadLine();

                if (text == "true")
                {
                    WindowState = WindowState.Maximized;
                }
                else
                {
                    WindowState = WindowState.Normal;
                }


            }
        }
        private async void dohvatiDrzavu()
        {
            Task<Country> task = new Task<Country>(getajDrzavu);//new Task<List<StartingEleven>>(repo.GetStartingElevenForCountry(fifa_Code));
            task.Start();
            Country = await task;
            loadData();
            //&panel1.Hide();
        }
        private Country getajDrzavu()
        {
            return repo.getStatisticForCountry(Fifa_Code);
        }

        private void loadData()
        {
            lblNaziv.Content = Country.CountryName;
            lblFifaKod.Content = Country.FifaCode;

            lblPobjede.Content = Country.GamesWins;
            lblPorazi.Content = Country.GamesLoses;
            lblNeodlucene.Content = Country.GamesDraw;

            lblGolovi.Content = Country.Goals;
            lblPrimljeniGolovi.Content = Country.GoalsReceived;
            lblGolRazlika.Content = Country.Goals - Country.GoalsReceived;
        }

    }
}
