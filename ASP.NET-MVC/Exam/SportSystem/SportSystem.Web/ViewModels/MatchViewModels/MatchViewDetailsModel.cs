namespace SportSystem.Web.ViewModels.MatchViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using SportSystem.Models;
    using SportSystem.Web.Infrastructure.Mappings;

    public class MatchViewDetailsModel : IMapFrom<Match>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string HomeTeamName { get; set; }

        public int HomeTeamId { get; set; }

        public string AwayTeamName { get; set; }

        public int AwayTeamId { get; set; }

        public DateTime StartDate { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public double? HomeBetsAmmount { get; set; }

        public double? AwayBetsAmmount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Match, MatchViewDetailsModel>()
             .ForMember(mvdm => mvdm.HomeBetsAmmount, opt => opt.MapFrom(m => m.Bets.Where(b => b.TeamId == m.HomeTeamId && b.MatchId == m.Id).Sum(b => b.Ammount)))
            .ForMember(mvdm => mvdm.AwayBetsAmmount, opt => opt.MapFrom(m => m.Bets.Where(b => b.TeamId == m.AwayTeamId && b.MatchId == m.Id).Sum(b => b.Ammount)));
        }
    }
}