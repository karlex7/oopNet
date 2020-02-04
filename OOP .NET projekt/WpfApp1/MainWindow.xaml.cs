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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = @"C:\Users\FRIDAY\Documents\OPP .NET projekt\OOP .NET projekt\lang.txt";
        string pathScreen = @"C:\Users\FRIDAY\Documents\OPP .NET projekt\OOP .NET projekt\full.txt";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rbHr.IsChecked==true)
            {
                Properties.Settings.Default.languageCode = "hr";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("hr");
                }
            }
            else
            {
                Properties.Settings.Default.languageCode = "en-GB";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("en-GB");
                }
            }
            Properties.Settings.Default.Save();

            if (rbFull.IsChecked==true)
            {
                using (StreamWriter sw = new StreamWriter(pathScreen))
                {
                    sw.WriteLine("true");
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(pathScreen))
                {
                    sw.WriteLine("false");
                }
            }


            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
