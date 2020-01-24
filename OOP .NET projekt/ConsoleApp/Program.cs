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

            List<StartingEleven> startingElevens = repo.GetStartingElevenForCountry("FRA");
            foreach (StartingEleven s in startingElevens)
            {
                Console.WriteLine(s.Name +" - "+s.ShirtNumber);
            }
        }
    }
}
