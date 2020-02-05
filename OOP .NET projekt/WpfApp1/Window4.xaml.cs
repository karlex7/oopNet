using ClassLibrary.MODEL;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public StartingEleven StartingEleven { get; set; }
        public int Goals { get; set; }
        public int Yellow { get; set; }
        public Window4()
        {
            InitializeComponent();
            if (StartingEleven!=null)
            {
                loadData(0,0);
            }
        }
        public Window4(StartingEleven startingEleven, int goals,int yellow)
        {
            StartingEleven = startingEleven;
            Goals = goals;
            Yellow = yellow;
            InitializeComponent();
            loadData(0,0);
        }

        public void loadData(int golas, int yellow)
        {
            lblIme.Content = StartingEleven.Name;
            lblBroj.Content = StartingEleven.ShirtNumber;
            lblPozicija.Content = StartingEleven.Position.ToString(); ;
            lblKapetan.Content = StartingEleven.Captain;
            lblBrojGolova.Content = Goals;
            lblBrojZutih.Content = Yellow;
        }
    }
}
