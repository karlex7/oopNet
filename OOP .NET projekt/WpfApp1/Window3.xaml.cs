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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public List<StartingEleven> HomeTeam { get; set; }
        public List<StartingEleven> AwayTeam { get; set; }
        public Match Match { get; set; }
        //private int widthCanvas = 800;
        private int heightCanvas = 400;
        public Window3()
        {
            InitializeComponent();
        }
        public Window3(List<StartingEleven> homeTeam, List<StartingEleven> awayTeam, Match match)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Match = match;
            InitializeComponent();

            LoadUCHomeTeam();
            LoadUCAwayTeam();
        }

        private void LoadUCAwayTeam()
        {
            int homeDef = 0;
            int homeMid = 0;
            int homeFw = 0;


            foreach (StartingEleven s in AwayTeam)
            {
                if (s.Position == Position.Defender)
                {
                    homeDef++;
                }
                if (s.Position == Position.Midfield)
                {
                    homeMid++;
                }
                if (s.Position == Position.Forward)
                {
                    homeFw++;
                }
            }

            //set heights for defenders
            int HomeDefHeight = 25;
            int addD = 25;
            for (int i = 0; i < 5 - homeDef; i++)
            {
                HomeDefHeight += 20;
                addD -= 10;
            }
            int homeDefAddEachTime = (heightCanvas - 25) / homeDef;

            int HomeMidHeight = 25;
            int addM = 25;
            for (int i = 0; i < 5 - homeMid; i++)
            {
                HomeMidHeight += 20;
                addM -= 10;
            }
            int homeMidAddEachTime = (heightCanvas - 25) / homeMid;


            int HomeFwHeight = 25;
            int addF = 25;
            for (int i = 0; i < 5 - homeFw; i++)
            {
                HomeFwHeight += 20;
                addF -= 10;
            }
            int homeFwAddEachTime = (heightCanvas - 25) / homeFw;


            foreach (StartingEleven s in AwayTeam)
            {
                UCIgrac igrac = new UCIgrac(s, Match);
                igrac.btnSetAwayColor();
                igrac.MouseDoubleClick += Igrac_MouseDoubleClick;
                if (s.Position == Position.Goalie)
                {
                    canvasPlay.Children.Add(igrac);
                    Canvas.SetLeft(igrac, 750);
                    Canvas.SetTop(igrac, 175);
                }
                if (s.Position == Position.Defender)
                {
                    canvasPlay.Children.Add(igrac);
                    Canvas.SetLeft(igrac, 650);
                    Canvas.SetTop(igrac, HomeDefHeight);
                    HomeDefHeight += homeDefAddEachTime;
                }
                if (s.Position == Position.Midfield)
                {
                    canvasPlay.Children.Add(igrac);
                    Canvas.SetLeft(igrac, 550);
                    Canvas.SetTop(igrac, HomeMidHeight);
                    HomeMidHeight += homeMidAddEachTime;
                }
                if (s.Position == Position.Forward)
                {
                    canvasPlay.Children.Add(igrac);
                    Canvas.SetLeft(igrac, 450);
                    Canvas.SetTop(igrac, HomeFwHeight);
                    HomeFwHeight += homeFwAddEachTime;
                }
            }
        }

        

        private void LoadUCHomeTeam()
        {
            int homeDef = 0;
            int homeMid = 0;
            int homeFw = 0;

            
            foreach (StartingEleven s in HomeTeam)
            {
                if (s.Position==Position.Defender)
                {
                    homeDef++;
                }
                if (s.Position == Position.Midfield)
                {
                    homeMid++;
                }
                if (s.Position == Position.Forward)
                {
                    homeFw++;
                }
            }

            //set heights for defenders
            int HomeDefHeight = 25;
            int addD = 25;
            for (int i = 0; i < 5-homeDef; i++)
            {
                HomeDefHeight += 20;
                addD -= 10;
            }
            int homeDefAddEachTime = (heightCanvas - 25) / homeDef;

            int HomeMidHeight = 25;
            int addM = 25;
            for (int i = 0; i < 5 - homeMid; i++)
            {
                HomeMidHeight += addM;
                addM -= 10;
            }
            int homeMidAddEachTime = (heightCanvas - 25) / homeMid;


            int HomeFwHeight = 25;
            int addF = 25;
            for (int i = 0; i < 5 - homeFw; i++)
            {
                HomeFwHeight += 20;
                addF -= 10;
            }
            int homeFwAddEachTime = (heightCanvas - 25) / homeFw;


            foreach (StartingEleven s in HomeTeam)
            {
                UCIgrac igrac = new UCIgrac(s, Match);
                igrac.MouseDoubleClick += Igrac_MouseDoubleClick;
                igrac.btnSetHomeColor();
                if (s.Position==Position.Goalie)
                {
                    canvasPlay.Children.Add(igrac);
                    Canvas.SetLeft(igrac, 0);
                    Canvas.SetTop(igrac, 175);
                }
                if (s.Position == Position.Defender)
                {
                    canvasPlay.Children.Add(igrac);
                    Canvas.SetLeft(igrac, 100);
                    Canvas.SetTop(igrac, HomeDefHeight);
                    HomeDefHeight += homeDefAddEachTime;
                }
                if (s.Position == Position.Midfield)
                {
                    canvasPlay.Children.Add(igrac);
                    Canvas.SetLeft(igrac, 200);
                    Canvas.SetTop(igrac, HomeMidHeight);
                    HomeMidHeight += homeMidAddEachTime;
                }
                if (s.Position == Position.Forward)
                {
                    canvasPlay.Children.Add(igrac);
                    Canvas.SetLeft(igrac, 300);
                    Canvas.SetTop(igrac, HomeFwHeight);
                    HomeFwHeight += homeFwAddEachTime;
                }
            }

        }
        private void Igrac_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UCIgrac igrac = sender as UCIgrac;

            int goals = 0;
            int yellow = 0;

            foreach (var i in Match.HomeTeamEvents)
            {
                if (i.Player==igrac.Name)
                {
                    if (i.TypeOfEvent==TypeOfEvent.Goal)
                    {
                        goals++;
                    }
                    if (i.TypeOfEvent==TypeOfEvent.YellowCard)
                    {
                        yellow++;
                    }
                }
            }
            foreach (var i in Match.AwayTeamEvents)
            {
                if (i.Player == igrac.Name)
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

            //igrac.openDetails(goals,yellow);
        }
    }
}
