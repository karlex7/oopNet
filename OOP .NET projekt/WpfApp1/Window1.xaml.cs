﻿using ClassLibrary;
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
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string path = @"C:\Users\FRIDAY\Documents\OPP .NET projekt\OOP .NET projekt\full.txt";
        string pathFavouriteNation = @"C:\Users\FRIDAY\Documents\OPP .NET projekt\OOP .NET projekt\fifaCode.txt";
        List<StartingEleven> away;
        List<StartingEleven> home;
        IRepo repo = RepoFactory.getRepo();
        public string savedFifaCode { get; set; }
        public string selectedFifaCode { get; set; }
        public Match Match { get; set; }
        List<Country> AllCountries;
        string Home_Fifa_code;
        string Away_Fifa_code;
        public Window1()
        {
            InitializeComponent();
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
            dohvatiDrzave();

            //StartingEleven s = new StartingEleven();
            //s.Name = "Karlo";
            //IgracUC.StartingEleven = s;
            //IgracUC.loadData();
        }

        private async void dohvatiDrzave()
        {
            Task<List<Country>> task = new Task<List<Country>>(getajDrzave);//new Task<List<StartingEleven>>(repo.GetStartingElevenForCountry(fifa_Code));
            task.Start();
            List<Country> countries = await task;
            foreach (Country c in countries)
            {
                cbFavourite.Items.Add(c.CountryName + " (" + c.FifaCode + ")");
            }
            AllCountries = countries;
            ucitajSpremljenuDrzavu();
            //&panel1.Hide();
        }
        private List<Country> getajDrzave()
        {
            return repo.getAllCountries();
        }
        private void ucitajSpremljenuDrzavu()
        {

            if (!File.Exists(pathFavouriteNation))
            {
                cbFavourite.SelectedIndex = 0;
                return;
            }
            else
            {
                using (StreamReader sr = new StreamReader(pathFavouriteNation))
                {
                    string text = sr.ReadLine();
                    cbFavourite.SelectedValue = text;
                    savedFifaCode = text;
                }
            }

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

        private void cbFavourite_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbFavourite.SelectedIndex!=-1)
            {
                //Dohvacanje fifa coda
                selectedFifaCode = getFifaCodeFromCBFavourite();
                
                ucitajDrzaveProtivnika();
            }
        }

        private async void ucitajDrzaveProtivnika()
        {
            Task<List<Country>> task = new Task<List<Country>>(getajProtivnike);//new Task<List<StartingEleven>>(repo.GetStartingElevenForCountry(fifa_Code));
            task.Start();
            List<Country> countries = await task;
            cbOpponent.Items.Clear();
            foreach (Country c in countries)
            {
                cbOpponent.Items.Add(c.CountryName + " (" + c.FifaCode + ")");
            }
            cbOpponent.SelectedIndex = 0;

            //Prikazi mapu terena i igrace
        }
        private List<Country> getajProtivnike()
        {
            return repo.getOpponentCountry(selectedFifaCode,AllCountries);
        }

        private string getFifaCodeFromCBFavourite()
        {
            string s = cbFavourite.SelectedValue.ToString();
            string z = s.Substring(s.Length - 4);
            string j = z.Remove(z.Length - 1);
            return j;
        }
        private string getFifaCodeFromCBOpponent()
        {
            string s = cbOpponent.SelectedValue.ToString();
            string z = s.Substring(s.Length - 4);
            string j = z.Remove(z.Length - 1);
            return j;
        }

        private void btnShowFavourite_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2(getFifaCodeFromCBFavourite());
            w2.Show();
        }

        private void btnShowOppoenet_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2(getFifaCodeFromCBOpponent());
            w2.Show();
        }

        private void btnTeren_Click(object sender, RoutedEventArgs e)
        {
            //List<StartingEleven> home = repo.GetStartingElevenForCountryNoSubs(getFifaCodeFromCBFavourite());
            // repo.GetStartingElevenForCountryNoSubs(getFifaCodeFromCBOpponent());
            
            if (cbOpponent.SelectedItem!=null)
            {
                Home_Fifa_code = getFifaCodeFromCBFavourite();
                Away_Fifa_code = getFifaCodeFromCBOpponent();
                dohvatiMatch();
                dohvatihome();
                dohvatiAway();
            }
            
            


            //Window3 w3 = new Window3(home, away,Match);

            //w3.Show();
        }

        private async void dohvatihome()
        {
            Task<List<StartingEleven>> task = new Task<List<StartingEleven>>(getstartingHome);//new Task<List<StartingEleven>>(repo.GetStartingElevenForCountry(fifa_Code));
            task.Start();
            home = await task;
        }

        private List<StartingEleven> getstartingHome()
        {
            return repo.GetStartingElevenForCountryNoSubs(Home_Fifa_code); 
        }
        private async void dohvatiAway()
        {
            Task<List<StartingEleven>> task = new Task<List<StartingEleven>>(getstartinhAway);//new Task<List<StartingEleven>>(repo.GetStartingElevenForCountry(fifa_Code));
            task.Start();
            away = await task;

            Window3 w3 = new Window3(home, away, Match);

            w3.Show();

        }
        private List<StartingEleven> getstartinhAway()
        {
            return repo.GetStartingElevenForCountryNoSubs(Away_Fifa_code);
        }

        private async void dohvatiMatch()
        {
            Task<Match> task = new Task<Match>(getajMatch);//new Task<List<StartingEleven>>(repo.GetStartingElevenForCountry(fifa_Code));
            task.Start();
            Match = await task;

            //&panel1.Hide();
        }
        private Match getajMatch()
        {
            return repo.getMatchByFifaCode(Home_Fifa_code,Away_Fifa_code);
        }

        private void cbOpponent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //
            //dohvatiMatch();
            //dohvatiMatch();
        }

        private void btnPostavke_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
