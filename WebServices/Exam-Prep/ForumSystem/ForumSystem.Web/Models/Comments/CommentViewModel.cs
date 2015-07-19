namespace ForumSystem.Web.Models.Comments
{
    using System;

    using AutoMapper;

    using ForumSystem.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorName { get; set; }


        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>().ForMember(
                c => c.AuthorName,
                opt => opt.MapFrom(c => c.User.UserName));
        }
    }
}