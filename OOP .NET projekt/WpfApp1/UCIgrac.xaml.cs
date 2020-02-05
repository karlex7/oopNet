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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for UCIgrac.xaml
    /// </summary>
    public partial class UCIgrac : UserControl
    {
        public StartingEleven StartingEleven { get; set; }
        public Match Match { get; set; }
        public UCIgrac()
        {
            InitializeComponent();
        }
        public UCIgrac( StartingEleven startingEleven,Match match)
        {
            StartingEleven = startingEleven;
            InitializeComponent();
            tbIme.Text = startingEleven.Name;
            Match = match;
        }
        public void loadData()
        {
            tbIme.Text = StartingEleven.Name;
        }
        public void btnSetHomeColor()
        {
            btnPlayer.Background = Brushes.Blue;
        }
        public void btnSetAwayColor()
        {
            btnPlayer.Background = Brushes.Red;
        }

        public void openDetails(int goals, int yellow)
        {
            Window4 w4 = new Window4(StartingEleven,goals,yellow);
            w4.Show();
        }

        private void btnPlayer_Click(object sender, RoutedEventArgs e)
        {
            int goals = 0;
            int yellow = 0;
            foreach (var i in Match.HomeTeamEvents)
            {
                if (i.Player == StartingEleven.Name)
                {
                    if (i.TypeOfEvent == TypeOfEvent.Goal)
                    {
                        goals++;
                    }
                    if (i.TypeOfEvent == TypeOfEvent.YellowCard)
                    {
                        yellow++;
                    }
                }
            }
            foreach (var i in Match.AwayTeamEvents)
            {
                if (i.Player == StartingEleven.Name)
                {
                    if (i.TypeOfEvent == TypeOfEvent.Goal)
                    {
                        goals++;
                    }
                    if (i.TypeOfEvent == TypeOfEvent.YellowCard)
                    {
                        yellow++;
                    }
                }
            }
            openDetails( goals,yellow);
        }
    }
}
