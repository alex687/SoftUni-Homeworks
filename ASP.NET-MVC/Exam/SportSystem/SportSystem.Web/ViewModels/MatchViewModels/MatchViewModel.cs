namespace SportSystem.Web.ViewModels.MatchViewModels
{
    using System;

    using SportSystem.Models;
    using SportSystem.Web.Infrastructure.Mappings;

    public class MatchViewModel : IMapFrom<Match>
    {
        public int Id { get; set; }

        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }

        public DateTime StartDate { get; set; }
    }
}