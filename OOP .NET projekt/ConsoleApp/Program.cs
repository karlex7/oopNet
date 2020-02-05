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
            IRepo repo = RepoFactory.getRepo();
            Country c = repo.getStatisticForCountry("FRA");
            Console.WriteLine("Golas: "+c.Goals);
            Console.WriteLine("Golas recived: " + c.GoalsReceived);
            Console.WriteLine("Wins: " + c.GamesWins);
            Console.WriteLine("Loses: " + c.GamesLoses);
            Console.WriteLine("Draw: " + c.GamesDraw);
        }
    }
}
