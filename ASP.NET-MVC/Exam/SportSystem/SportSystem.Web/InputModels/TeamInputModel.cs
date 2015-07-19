namespace SportSystem.Web.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using SportSystem.Models;
    using SportSystem.Web.Infrastructure.Mappings;

    public class TeamInputModel : IMapTo<Team>, IHaveCustomMappings
    {
        [Required]
        public string Name { get; set; }

        public string NickName { get; set; }

        [DataType(DataType.Url)]
        public string Website { get; set; }

        public DateTime DateFounded { get; set; }

        public ICollection<int> Players { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<TeamInputModel, Team>().ForMember(tim => tim.Players, opt => opt.Ignore());
        }
    }
}