using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        string path = @"C:\Users\FRIDAY\Documents\OPP .NET projekt\OOP .NET projekt\lang.txt";
        string pathScreen = @"C:\Users\FRIDAY\Documents\OPP .NET projekt\OOP .NET projekt\full.txt";

        protected override void OnStartup(StartupEventArgs e)
        {
            if (!File.Exists(path))
            {
                if (!File.Exists(pathScreen))
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine("false");
                    }
                }
                //run select lang
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                if (!File.Exists(pathScreen))
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine("false");
                    }
                }
                loadLang();
                Window1 w1 = new Window1();
                w1.Show();
            }





            //var langCode = WpfApp1.Properties.Settings.Default.languageCode;
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langCode);
            base.OnStartup(e);
        }

        private void loadLang()
        {
            string hrvatski = "hr";
            string engleski = "en-GB";

            using (StreamReader sr = new StreamReader(path))
            {
                string text = sr.ReadLine();
                string utilsLang = WpfApp1.Properties.Settings.Default.languageCode;

                if (text == hrvatski)
                {
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(hrvatski);
                }
                else
                {
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(engleski);
                }


            }
        }
    }
}
