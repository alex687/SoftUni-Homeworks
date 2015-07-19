namespace BugTracker.RestServices.Models.Bugs
{
    using System;

    using AutoMapper;

    using BugTracker.Data.Models;
    using BugTracker.RestServices.Infrastructure.Mapping;

    public class BugMinOutputModel : IMapFrom<Bug>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Bug, BugMinOutputModel>()
                .ForMember(b => b.Status, opt => opt.MapFrom(b => b.Status.ToString()))
                .ForMember(b => b.Author, opt => opt.MapFrom(b => b.Author.UserName));
        }
    }
}