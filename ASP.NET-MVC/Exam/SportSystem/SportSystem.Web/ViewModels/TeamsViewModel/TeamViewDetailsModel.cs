namespace SportSystem.Web.ViewModels.TeamsViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using SportSystem.Models;
    using SportSystem.Web.Infrastructure.Mappings;

    public class TeamViewDetailsModel : IMapFrom<Team>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public string NickName { get; set; }

        public DateTime DateFounded { get; set; }

        public int? Votes { get; set; }

        public bool IsVoted { get; set; }

        public IEnumerable<PlayerViewModel> Players { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Team, TeamViewDetailsModel>()
                .ForMember(tvm => tvm.Votes, opt => opt.MapFrom(t => t.Votes.Sum(v => v.VoteValue)));
        }
    }
}