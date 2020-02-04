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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string path = @"C:\Users\FRIDAY\Documents\OPP .NET projekt\OOP .NET projekt\full.txt";
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
    }
}
