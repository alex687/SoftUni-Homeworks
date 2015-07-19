
namespace BlogSystem.Web.Models.Posts
{
    using System.Collections.Generic;

    using AutoMapper;

    using BlogSystem.Models;
    using BlogSystem.Web.Models.Tags;

    public class PostViewModel : PostModel
    {
        public ICollection<TagViewModel> Tags { get; set; }

        public override void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, PostViewModel>();
        }
    }
}