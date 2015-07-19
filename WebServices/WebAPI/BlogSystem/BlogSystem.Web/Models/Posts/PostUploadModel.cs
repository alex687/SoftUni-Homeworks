namespace BlogSystem.Web.Models.Posts
{
    using System.Collections.Generic;

    using AutoMapper;

    using BlogSystem.Models;
    using BlogSystem.Web.Models.Tags;

    public class PostUploadModel : PostModel
    {
        public ICollection<TagUploadModel> Tags { get; set; }

        public override void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<PostUploadModel, Post>();
        }
    }
}