namespace ExportLeaguesAndTeamsToJson
{
    using System;
    using System.Data;
    using System.IO;
    using System.Linq;

    using ListAllTeamNames;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new FootballEntities();

            var leaguesWithTeams  = context.Leagues
                .OrderBy(l => l.LeagueName)
                .Select(l => new { l.LeagueName, Teams = l.Teams.OrderBy(t => t.TeamName).Select(t => t.TeamName) });

            var json = JsonConvert.SerializeObject(leaguesWithTeams, Formatting.None, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            File.WriteAllText("../../leagues-and-teams.json", json);
            Console.WriteLine("See the project's folder - leagues-and-teams.json");
        }
    }
}
