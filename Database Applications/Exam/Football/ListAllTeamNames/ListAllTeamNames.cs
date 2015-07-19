namespace ListAllTeamNames
{
    using System;
    using System.Linq;

    public class ListAllTeamNames
    {
        public static void Main(string[] args)
        {
            var context = new FootballEntities();

            var teamsNames = context.Teams.Select(t => t.TeamName);
            
            foreach (var teamName in teamsNames)
            {
                Console.WriteLine(teamName);
            }
        }
    }
}
