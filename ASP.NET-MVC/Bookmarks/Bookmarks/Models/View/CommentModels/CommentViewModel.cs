namespace Bookmarks.Models.View.CommentModels
{
    using AutoMapper;

    using Bookmarks.Common.Mappings;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string User { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(bvm => bvm.User, opt => opt.MapFrom(b => b.Author.UserName));
        }
    }
}