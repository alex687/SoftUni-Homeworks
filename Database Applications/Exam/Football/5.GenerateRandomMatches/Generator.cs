namespace GenerateRandomMatches
{
    using System;
    using System.Globalization;
    using System.Linq;

    using ListAllTeamNames;

    public class Generator
    {
        private Random random;

        private FootballEntities context;

        public Generator(FootballEntities context)
        {
            this.random = new Random();
            this.context = context;
        }

        public void Generate(GenerateConfig generateConfig)
        {
            int totalItems;
            var query = this.context.Teams.AsQueryable();
            if (generateConfig.League != null)
            {
                query = query.Where(t => t.Leagues.Any(l => l.LeagueName == generateConfig.League));
                totalItems = query.Count();
            }
            else
            {
                totalItems = query.Count();
            }

            var time = new TimeSpan(generateConfig.StartDate.Ticks);


            for (int i = 0; i < generateConfig.GenerateCount; i++)
            {
                int randomFitstTeam = this.random.Next(0, totalItems - 1);
                var firstTeam = query.OrderBy(t => t.Id).Skip(randomFitstTeam).Take(1).First();

                int randomSecond = this.random.Next(0, totalItems - 1);
                var secondTeam = query.OrderBy(t => t.Id).Skip(randomSecond).Take(1).First();

                var randomDate = this.RandomDate(generateConfig.StartDate, generateConfig.EndDate);

                int randomFirstScore = this.random.Next(0, generateConfig.MaxGoals);
                int randomSecondScore = this.random.Next(0, generateConfig.MaxGoals - randomFirstScore);


                var match = new TeamMatch();
                match.HomeTeam = firstTeam;
                match.AwayTeam = secondTeam;
                match.HomeGoals = randomFirstScore;
                match.AwayGoals = randomSecondScore;
                match.MatchDate = randomDate;
                this.context.TeamMatches.Add(match);
                this.context.SaveChanges();

                Console.WriteLine("{0}: {1} - {2}: {3} - {4} ({5})", randomDate.ToString("dd-MMM-yyy", CultureInfo.InvariantCulture), firstTeam.TeamName, secondTeam.TeamName, randomFirstScore, randomSecondScore, generateConfig.League != null ? generateConfig.League : "no league");
            }
        }

        private DateTime RandomDate(DateTime start, DateTime end)
        {
            Random gen = new Random();

            int range = (end - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}