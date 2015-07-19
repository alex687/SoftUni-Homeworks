namespace SportSystem.Data.Migrations
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using SportSystem.Models;

    #endregion

    public sealed class Configuration : DbMigrationsConfiguration<SportSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SportSystemDbContext context)
        {
            if (!context.Teams.Any())
            {
                var teams = this.SeedTeams(context);
                var matches = this.SeedMatches(context, teams);

                this.SeedPlayers(context, teams);

                var users = this.SeedUsers(context);

                this.SeedComments(context, matches, users);

                this.SeedBets(context, matches, users);

                this.SeedVotes(context, teams, users);
            }

            // This method will be called after migrating to the latest version.

            // You can use the DbSet<T>.AddOrUpdate() helper extension method 
            // to avoid creating duplicate seed data. E.g.
            // context.People.AddOrUpdate(
            // p => p.FullName,
            // new Person { FullName = "Andrew Peters" },
            // new Person { FullName = "Brice Lambson" },
            // new Person { FullName = "Rowan Miller" }
            // );
        }

        private Dictionary<string, Team> SeedTeams(SportSystemDbContext context)
        {
            var teams = new Dictionary<string, Team>();

            teams.Add(
                "Manchester United",
                new Team
                    {
                        Name = "Manchester United F.C.",
                        Website = "http://www.manutd.com",
                        DateFounded = new DateTime(1878, 6, 1),
                        NickName = "The Red Devils"
                    });

            teams.Add(
                "Real Madrid",
                new Team
                    {
                        Name = "Real Madrid",
                        Website = "http://www.realmadrid.com",
                        DateFounded = new DateTime(1902, 3, 6),
                        NickName = "The Whites"
                    });

            teams.Add(
                "FC Barcelona",
                new Team
                    {
                        Name = "FC Barcelona",
                        Website = "http://www.fcbarcelona.com",
                        DateFounded = new DateTime(1899, 11, 18),
                        NickName = "Barca"
                    });

            teams.Add(
                "Bayern Munich",
                new Team
                    {
                        Name = "Bayern Munich",
                        Website = "http://www.fcbayern.de",
                        DateFounded = new DateTime(1900, 2, 13),
                        NickName = "The Bavarians"
                    });

            teams.Add(
                "Manchester City",
                new Team
                    {
                        Name = "Manchester City",
                        Website = "http://www.mcfc.com",
                        DateFounded = new DateTime(1880, 5, 1),
                        NickName = "The Citizens"
                    });

            teams.Add(
                "Chelsea",
                new Team
                    {
                        Name = "Chelsea",
                        Website = "https://www.chelseafc.com",
                        DateFounded = new DateTime(1905, 3, 10),
                        NickName = "The Pensioners"
                    });

            teams.Add(
                "Arsenal",
                new Team
                    {
                        Name = "Arsenal",
                        Website = "http://www.arsenal.com",
                        DateFounded = new DateTime(1886, 9, 1),
                        NickName = "The Gunners"
                    });

            foreach (var team in teams)
            {
                context.Teams.Add(team.Value);
            }

            context.SaveChanges();

            return teams;
        }

        private Dictionary<string, Match> SeedMatches(SportSystemDbContext context, Dictionary<string, Team> teams)
        {
            var matches = new Dictionary<string, Match>();
            matches.Add(
                "Real Madrid-Manchester United",
                new Match
                    {
                        HomeTeamId = teams["Real Madrid"].Id,
                        AwayTeamId = teams["Manchester United"].Id,
                        StartDate = new DateTime(2015, 6, 13)
                    });
            matches.Add(
                "Bayern Munich-Manchester United",
                new Match
                    {
                        HomeTeamId = teams["Bayern Munich"].Id,
                        AwayTeamId = teams["Manchester United"].Id,
                        StartDate = new DateTime(2015, 6, 14)
                    });
            matches.Add(
                "FC Barcelona-Manchester City",
                new Match
                    {
                        HomeTeamId = teams["FC Barcelona"].Id,
                        AwayTeamId = teams["Manchester City"].Id,
                        StartDate = new DateTime(2015, 6, 15)
                    });
            matches.Add(
                "Chelsea-FC Barcelona",
                new Match
                    {
                        HomeTeamId = teams["Chelsea"].Id,
                        AwayTeamId = teams["FC Barcelona"].Id,
                        StartDate = new DateTime(2015, 6, 16)
                    });
            matches.Add(
                "Real Madrid-Manchester City",
                new Match
                    {
                        HomeTeamId = teams["Real Madrid"].Id,
                        AwayTeamId = teams["Manchester City"].Id,
                        StartDate = new DateTime(2015, 6, 17)
                    });
            matches.Add(
                "Manchester United-Chelsea",
                new Match
                    {
                        HomeTeamId = teams["Manchester United"].Id,
                        AwayTeamId = teams["Chelsea"].Id,
                        StartDate = new DateTime(2015, 6, 18)
                    });
            matches.Add(
                "Arsenal-Bayern Munich",
                new Match
                    {
                        HomeTeamId = teams["Arsenal"].Id,
                        AwayTeamId = teams["Bayern Munich"].Id,
                        StartDate = new DateTime(2015, 6, 12)
                    });
            matches.Add(
                "Chelsea-Real Madrid",
                new Match
                    {
                        HomeTeamId = teams["Chelsea"].Id,
                        AwayTeamId = teams["Real Madrid"].Id,
                        StartDate = new DateTime(2015, 6, 11)
                    });
            matches.Add(
                "Chelsea-Manchester City",
                new Match
                    {
                        HomeTeamId = teams["Chelsea"].Id,
                        AwayTeamId = teams["Manchester City"].Id,
                        StartDate = new DateTime(2015, 6, 10)
                    });
            matches.Add(
                "Chelsea-Arsenal",
                new Match
                    {
                        HomeTeamId = teams["Chelsea"].Id,
                        AwayTeamId = teams["Arsenal"].Id,
                        StartDate = new DateTime(2015, 6, 19)
                    });
            matches.Add(
                "Arsenal-FC Barcelona",
                new Match
                    {
                        HomeTeamId = teams["Arsenal"].Id,
                        AwayTeamId = teams["FC Barcelona"].Id,
                        StartDate = new DateTime(2015, 6, 20)
                    });

            foreach (var match in matches)
            {
                context.Matches.Add(match.Value);
            }

            context.SaveChanges();

            return matches;
        }

        private void SeedPlayers(SportSystemDbContext context, Dictionary<string, Team> teams)
        {
            var alexisSanchez = new Player
                                    {
                                        Name = "Alexis Sanchez",
                                        BirthDate = new DateTime(1982, 1, 3),
                                        Height = 1.65,
                                        TeamId = teams["FC Barcelona"].Id
                                    };
            var arjenRobben = new Player
                                  {
                                      Name = "Arjen Robben",
                                      BirthDate = new DateTime(1982, 1, 3),
                                      Height = 1.65,
                                      TeamId = teams["Real Madrid"].Id
                                  };
            var frankRibery = new Player
                                  {
                                      Name = "Franck Ribery",
                                      BirthDate = new DateTime(1982, 1, 3),
                                      Height = 1.65,
                                      TeamId = teams["Manchester United"].Id
                                  };
            var wayneRooney = new Player
                                  {
                                      Name = "Wayne Rooney",
                                      BirthDate = new DateTime(1982, 1, 3),
                                      Height = 1.65,
                                      TeamId = teams["Manchester United"].Id
                                  };
            var lionelMessi = new Player { Name = "Lionel Messi", BirthDate = new DateTime(1982, 1, 13), Height = 1.65 };
            var theoWalcott = new Player { Name = "Theo Walcott", BirthDate = new DateTime(1983, 2, 17), Height = 1.75 };
            var cristianoRonaldo = new Player
                                       {
                                           Name = "Cristiano Ronaldo",
                                           BirthDate = new DateTime(1984, 3, 16),
                                           Height = 1.85
                                       };
            var aaronLennon = new Player { Name = "Aaron Lennon", BirthDate = new DateTime(1985, 4, 15), Height = 1.95 };
            var garethBale = new Player { Name = "Gareth Bale", BirthDate = new DateTime(1986, 5, 14), Height = 1.90 };
            var antonioValencia = new Player
                                      {
                                          Name = "Antonio Valencia",
                                          BirthDate = new DateTime(1987, 5, 23),
                                          Height = 1.82
                                      };
            var robinVanPersie = new Player
                                     {
                                         Name = "Robin van Persie",
                                         BirthDate = new DateTime(1988, 6, 13),
                                         Height = 1.84
                                     };
            var ronaldinho = new Player { Name = "Ronaldinho", BirthDate = new DateTime(1989, 7, 30), Height = 1.87 };

            context.Players.Add(alexisSanchez);
            context.Players.Add(arjenRobben);
            context.Players.Add(frankRibery);
            context.Players.Add(wayneRooney);
            context.Players.Add(lionelMessi);
            context.Players.Add(theoWalcott);
            context.Players.Add(cristianoRonaldo);
            context.Players.Add(aaronLennon);
            context.Players.Add(garethBale);
            context.Players.Add(antonioValencia);
            context.Players.Add(robinVanPersie);
            context.Players.Add(ronaldinho);
            context.SaveChanges();
        }

        private Dictionary<string, User> SeedUsers(SportSystemDbContext context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));

            var alex = new User { UserName = "alex@usa.net", Email = "alex@usa.net" };
            userManager.Create(alex, "12qw!@QW");

            var tanya = new User { UserName = "tanya@gmail.com", Email = "tanya@gmail.com" };
            userManager.Create(tanya, "P@ssW0RD!123");

            var users = new Dictionary<string, User>();
            users.Add("alex@usa.net", alex);
            users.Add("tanya@gmail.com", tanya);

            context.SaveChanges();
            return users;
        }

        private void SeedComments(
            SportSystemDbContext context,
            Dictionary<string, Match> matches,
            Dictionary<string, User> users)
        {
            matches["Bayern Munich-Manchester United"].Comments.Add(
                new Comment { Content = "The best match this summer!", AuthorId = users["alex@usa.net"].Id, CreatedOn = DateTime.Now });
            matches["Bayern Munich-Manchester United"].Comments.Add(
                new Comment { Content = "The good football this evening.", AuthorId = users["tanya@gmail.com"].Id, CreatedOn = DateTime.Now });

            matches["FC Barcelona-Manchester City"].Comments.Add(
                new Comment { Content = "Barca!", AuthorId = users["tanya@gmail.com"].Id, CreatedOn = DateTime.Now });

            matches["Real Madrid-Manchester City"].Comments.Add(
                new Comment { Content = "Real forever!", AuthorId = users["alex@usa.net"].Id, CreatedOn = DateTime.Now });
            matches["Real Madrid-Manchester City"].Comments.Add(
                new Comment { Content = "Real, real, real", AuthorId = users["alex@usa.net"].Id, CreatedOn = DateTime.Now });
            matches["Real Madrid-Manchester City"].Comments.Add(
                new Comment { Content = "Real again :)", AuthorId = users["alex@usa.net"].Id, CreatedOn = DateTime.Now });

            matches["Chelsea-Real Madrid"].Comments.Add(
                new Comment { Content = "Chelsea champion!", AuthorId = users["tanya@gmail.com"].Id, CreatedOn = DateTime.Now });

            context.SaveChanges();
        }

        private void SeedBets(
            SportSystemDbContext context,
            Dictionary<string, Match> matches,
            Dictionary<string, User> users)
        {
            context.Bets.Add(
                new Bet
                    {
                        MatchId = matches["Chelsea-FC Barcelona"].Id,
                        Ammount = 30,
                        TeamId = matches["Chelsea-FC Barcelona"].HomeTeamId,
                        UserId = users["alex@usa.net"].Id
                    });

            context.Bets.Add(
                new Bet
                    {
                        MatchId = matches["Chelsea-FC Barcelona"].Id,
                        Ammount = 50,
                        TeamId = matches["Chelsea-FC Barcelona"].AwayTeamId,
                        UserId = users["alex@usa.net"].Id
                    });

            context.Bets.Add(
                new Bet
                    {
                        MatchId = matches["Chelsea-FC Barcelona"].Id,
                        Ammount = 120,
                        TeamId = matches["Chelsea-FC Barcelona"].AwayTeamId,
                        UserId = users["alex@usa.net"].Id
                    });

            context.Bets.Add(
                new Bet
                    {
                        MatchId = matches["Chelsea-FC Barcelona"].Id,
                        Ammount = 220,
                        TeamId = matches["Chelsea-FC Barcelona"].AwayTeamId,
                        UserId = users["tanya@gmail.com"].Id
                    });

            context.Bets.Add(
                new Bet
                    {
                        MatchId = matches["FC Barcelona-Manchester City"].Id,
                        Ammount = 120,
                        TeamId = matches["Chelsea-FC Barcelona"].HomeTeamId,
                        UserId = users["alex@usa.net"].Id
                    });

            context.Bets.Add(
                new Bet
                    {
                        MatchId = matches["Bayern Munich-Manchester United"].Id,
                        Ammount = 500,
                        TeamId = matches["Chelsea-FC Barcelona"].HomeTeamId,
                        UserId = users["alex@usa.net"].Id
                    });

            context.Bets.Add(
                new Bet
                    {
                        MatchId = matches["Bayern Munich-Manchester United"].Id,
                        Ammount = 50,
                        TeamId = matches["Chelsea-FC Barcelona"].HomeTeamId,
                        UserId = users["tanya@gmail.com"].Id
                    });
            context.Bets.Add(
                new Bet
                    {
                        MatchId = matches["Bayern Munich-Manchester United"].Id,
                        Ammount = 20,
                        TeamId = matches["Chelsea-FC Barcelona"].AwayTeamId,
                        UserId = users["tanya@gmail.com"].Id
                    });

            context.SaveChanges();
        }

        private void SeedVotes(
            SportSystemDbContext context,
            Dictionary<string, Team> teams,
            Dictionary<string, User> users)
        {
            context.Votes.Add(
                new Vote { TeamId = teams["Bayern Munich"].Id, VoteValue = 1, UserId = users["tanya@gmail.com"].Id });
            context.Votes.Add(
                new Vote { TeamId = teams["Real Madrid"].Id, VoteValue = 1, UserId = users["tanya@gmail.com"].Id });

            context.Votes.Add(
                new Vote { TeamId = teams["Bayern Munich"].Id, VoteValue = 1, UserId = users["alex@usa.net"].Id });
            context.SaveChanges();
        }
    }
}