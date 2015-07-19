namespace BlogSystem.Web.Models.Comments
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using BlogSystem.Models;
    using BlogSystem.Web.Infrastructure.Mapping;

    public class CommentsModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int? PostId { get; set; }

        [Required(ErrorMessage = "The content is required")]
        public string Content { get; set; }

        [Required(ErrorMessage = "The user is required")]
        public string UserId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentsModel>();
            configuration.CreateMap<CommentsModel, Comment>();
        }
    }
}