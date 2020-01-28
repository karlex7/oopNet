using ClassLibrary;
using ClassLibrary.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DBRepo repo = new DBRepo();

            //List<Match> matches = repo.getMatchesForCountry("ARG");
            //foreach (Match m in matches)
            //{
            //    Console.WriteLine(m.AwayTeamCountry + " vs "+m.HomeTeamCountry);
            //}
            string code = "USA";
            List<Match> matches = repo.getMatchesForCountry(code);
            List<TeamEvent> events = new List<TeamEvent>();
            List<TeamEvent> temp = new List<TeamEvent>();
            foreach (var match in matches)
            {
                if (match.HomeTeam.Code.Equals(code))
                {
                    temp = match.HomeTeamEvents;
                    foreach (var item in temp)
                    {
                        events.Add(item);
                    }
                }
                else
                {
                    temp = match.AwayTeamEvents;
                    foreach (var item in temp)
                    {
                        events.Add(item);
                    }
                }
                
                
            }

            List<StartingEleven> startingElevens = repo.GetStartingElevenForCountry(code);
            foreach (TeamEvent item in events)
            {
                foreach (StartingEleven s in startingElevens)
                {
                    if (item.Player.Equals(s.Name))
                    {
                        if (item.TypeOfEvent== TypeOfEvent.Goal)
                        {
                            s.Golas++;
                        }
                        if (item.TypeOfEvent== TypeOfEvent.YellowCard || item.TypeOfEvent ==TypeOfEvent.YellowCardSecond)
                        {
                            s.NumerOfYellowCards++;
                        }
                    }
                }
            }
            foreach (StartingEleven startingEleven in startingElevens)
            {
                //Console.WriteLine(startingEleven.Name+" - Goals: "+startingEleven.Golas+" | Yellow cards: "+startingEleven.NumerOfYellowCards);
            }
            var st = repo.GetGoalAndYellowStatisticForCountry(code);

            foreach (var i in st)
            {
                //Console.WriteLine(i.Name + " - Goals: " + i.Golas + " | Yellow cards: " + i.NumerOfYellowCards);
            }


            var mat = repo.getMatchesForCountry(code);
            foreach (var item in mat)
            {
                Console.WriteLine(item.Location + " - "+item.Attendance+ " - "+item.HomeTeamCountry+ "vs"+item.AwayTeamCountry);
            }
            /*List<StartingEleven> startingElevens = repo.GetStartingElevenForCountry("FRA");
            foreach (StartingEleven s in startingElevens)
            {
                Console.WriteLine(s.Name +" - "+s.ShirtNumber+ " - "+s.NumerOfYellowCards+ " - "+s.Golas);
            }*/
        }
    }
}
