namespace SportSystem.Web.ViewModels.TeamsViewModel
{
    using System.Linq;

    using AutoMapper;

    using SportSystem.Models;
    using SportSystem.Web.Infrastructure.Mappings;

    public class TeamViewModel : IMapFrom<Team>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public int? Votes { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Team, TeamViewModel>()
                .ForMember(tvm => tvm.Votes, opt => opt.MapFrom(t => t.Votes.Sum(v => v.VoteValue)));
        }
    }
}