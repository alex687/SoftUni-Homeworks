namespace BlogSystem.Web.Models.Tags
{
    using AutoMapper;

    using BlogSystem.Models;
    using BlogSystem.Web.Infrastructure.Mapping;

    public class TagUploadModel : TagModel
    {
        public override void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Tag, TagUploadModel>();
            configuration.CreateMap<TagUploadModel, Tag>();
        }
    }
}