using ClassLibrary.MODEL;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class DBRepo : IRepo
    {
        RestClient client = new RestClient("http://worldcup.sfg.io/");
        public List<Country> getAllCountries()
        {
            RestRequest request = new RestRequest("teams", Method.GET);

            var content = client.Execute(request).Content;

            var countries = Country.FromJson(content);

            return countries;
        }

        public List<Match> getAllMatches()
        {
            RestRequest request = new RestRequest("matches", Method.GET);

            var content = client.Execute(request).Content;

            var matches = Match.FromJson(content);

            return matches;
        }

        public List<StartingEleven> GetGoalAndYellowStatisticForCountry(string fifa_code)
        {
            List<Match> matches = getMatchesForCountry(fifa_code);
            List<TeamEvent> events = new List<TeamEvent>();
            List<TeamEvent> temp = new List<TeamEvent>();
            foreach (var match in matches)
            {
                if (match.HomeTeam.Code.Equals(fifa_code))
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

            List<StartingEleven> startingElevens = GetStartingElevenForCountry(fifa_code);
            foreach (TeamEvent item in events)
            {
                foreach (StartingEleven s in startingElevens)
                {
                    if (item.Player.Equals(s.Name))
                    {
                        if (item.TypeOfEvent == TypeOfEvent.Goal)
                        {
                            s.Golas++;
                        }
                        if (item.TypeOfEvent == TypeOfEvent.YellowCard || item.TypeOfEvent == TypeOfEvent.YellowCardSecond)
                        {
                            s.NumerOfYellowCards++;
                        }
                    }
                }
            }
            return startingElevens;
        }

        public List<Match> getMatchesForCountry(string fifa_code)
        {
            List<Match> allMatches = getAllMatches();
            List<Match> matches = new List<Match>();

            foreach (Match m in allMatches)
            {
                if (m.HomeTeam.Code==fifa_code || m.AwayTeam.Code==fifa_code)
                {
                    matches.Add(m);
                }
            }

            //var matches = Match.FromJson(content);

            return matches;
        }

        public List<StartingEleven> GetStartingElevenForCountry(string fifa_code)
        {
            List<Match> matches = getMatchesForCountry(fifa_code);

            List<StartingEleven> startingElevens = new List<StartingEleven>();

            Match m = matches[0];
            if (m.HomeTeam.Code==fifa_code)
            {
                foreach (StartingEleven s in m.HomeTeamStatistics.StartingEleven)
                {
                    startingElevens.Add(s);
                }
                foreach (StartingEleven s in m.HomeTeamStatistics.Substitutes)
                {
                    startingElevens.Add(s);
                }
            }
            else
            {
                foreach (StartingEleven s in m.AwayTeamStatistics.StartingEleven)
                {
                    startingElevens.Add(s);
                }
                foreach (StartingEleven s in m.AwayTeamStatistics.Substitutes)
                {
                    startingElevens.Add(s);
                }
            }
            

            return startingElevens;
        }
    }
}
