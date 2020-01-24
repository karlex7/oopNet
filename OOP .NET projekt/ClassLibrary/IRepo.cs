using ClassLibrary.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IRepo
    {
        List<Country> getAllCountries();
        List<Match> getAllMatches();
        List<Match> getMatchesForCountry(string fifa_code);
        List<StartingEleven> GetStartingElevenForCountry(string fifa_code);
        
    }
}
