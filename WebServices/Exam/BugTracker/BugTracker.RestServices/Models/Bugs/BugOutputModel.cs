namespace BugTracker.RestServices.Models.Bugs
{
    using System.Collections.Generic;

    using AutoMapper;

    using BugTracker.Data.Models;
    using BugTracker.RestServices.Infrastructure.Mapping;
    using BugTracker.RestServices.Models.Comments;

    public class BugOutputModel : BugMinOutputModel, IMapFrom<Bug>, IHaveCustomMappings
    {
        public string Description { get; set; }

        public ICollection<CommentsOutputModel> Comments { get; set; }

        public new void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Bug, BugOutputModel>()
                .ForMember(b => b.Status, opt => opt.MapFrom(b => b.Status.ToString()))
                .ForMember(b => b.Author, opt => opt.MapFrom(b => b.Author.UserName));
        }
    }
}