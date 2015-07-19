namespace BlogSystem.Web.Models.Posts
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using BlogSystem.Models;
    using BlogSystem.Web.Infrastructure.Mapping;

    public abstract class PostModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The content is required")]
        public string Content { get; set; }

        public string UserId { get; set; }
        
        public abstract void CreateMappings(IConfiguration configuration);
    }
}