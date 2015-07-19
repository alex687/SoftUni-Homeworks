namespace ImportLeaguesAndTeamsXml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    using ListAllTeamNames;

    public class Program
    {
        public static void Main(string[] args)
        {
            var xmlParrent = new Stack<string>();
            using (XmlReader reader = new XmlTextReader("../../leagues-and-teams.xml"))
            {
                var context = new FootballEntities();
                League league = null;
                int counter = 0;
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name != "team")
                        {
                            if (reader.Name == "league")
                            {
                                counter++;
                                Console.WriteLine("Processing league #{0}", counter);
                            }

                            xmlParrent.Push(reader.Name);
                        }
                        else
                        {
                            var teamName = reader.GetAttribute("name");
                            if (teamName == null)
                            {
                                Console.WriteLine("Team name is mandatory");
                            }
                            else
                            {
                                Country country = null;
                                var countryName = reader.GetAttribute("country");
                                if (countryName != null)
                                {
                                    country = GetOrCreateCountry(context, countryName);
                                }

                                CreateTeam(context, teamName, country, league);
                            }
                        }
                    }

                    if (reader.NodeType == XmlNodeType.Text)
                    {
                        if (xmlParrent.Peek() == "league-name")
                        {
                            var leagueName = reader.Value;

                            league = context.Leagues.FirstOrDefault(l => l.LeagueName == leagueName);
                            if (league != null)
                            {
                                Console.WriteLine("Existing league: {0}", league.LeagueName);
                            }
                            else
                            {
                                league = new League { LeagueName = leagueName };
                                context.SaveChanges();
                                Console.WriteLine("Created league: {0}", leagueName);
                            }
                        }
                    }

                    if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        if (reader.Name == "league")
                        {
                            league = null;
                            Console.WriteLine();
                        }

                        if (reader.Name != "team")
                        {
                            xmlParrent.Pop();
                        }
                    }
                }
            }
        }

        private static void CreateTeam(FootballEntities context, string teamName, Country country, League league)
        {
            Team team;
            if (country == null)
            {
                team = context.Teams.FirstOrDefault(t => (t.Country == null) && t.TeamName == teamName);
            }
            else
            {
                team = context.Teams.FirstOrDefault(
                    t => t.Country.CountryName == country.CountryName && t.TeamName == teamName);
            }

            if (team == null)
            {
                team = new Team { TeamName = teamName, Country = country };

                context.Teams.Add(team);
                context.SaveChanges();
                Console.WriteLine(
                    "Created team: {0} ({1})",
                    team.TeamName,
                    country != null ? team.Country.CountryName : "no country");

                if (league != null)
                {
                    team.Leagues.Add(league);
                    context.SaveChanges();
                    Console.WriteLine("Added team to league: {0}", league.LeagueName);
                }
            }
            else
            {
                Console.WriteLine(
                   "Existing team: {0} ({1})",
                   team.TeamName,
                   country != null ? team.Country.CountryName : "no country");

                if (league != null)
                {
                    if (!team.Leagues.Any(l => l.LeagueName == league.LeagueName))
                    {
                        team.Leagues.Add(league);
                        context.SaveChanges();
                        Console.WriteLine("Added team to league: {0}", league.LeagueName);
                    }
                    else
                    {
                        Console.WriteLine("Existing team in league: {0}", league.LeagueName);
                    }
                }
            }
        }

        private static Country GetOrCreateCountry(FootballEntities context, string countryName)
        {
            var country = context.Countries.FirstOrDefault(c => c.CountryName == countryName);
            if (country == null)
            {
                country = new Country { CountryName = countryName };
            }

            return country;
        }
    }
}

