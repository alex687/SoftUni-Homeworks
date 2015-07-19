namespace BugTracker.RestServices.Models.Comments
{
    using AutoMapper;

    using BugTracker.Data.Models;
    using BugTracker.RestServices.Infrastructure.Mapping;

    public class CommentsAllOutputModel : CommentsOutputModel, IMapFrom<Comment>, IHaveCustomMappings
    {
        public int BugId { get; set; }

        public string BugTitle { get; set; }

        public new void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentsAllOutputModel>()
                .ForMember(c => c.Author, opt => opt.MapFrom(c => c.Author.UserName))
                .ForMember(c => c.BugTitle, opt => opt.MapFrom( c => c.Bug.Title));
        }
    }
}