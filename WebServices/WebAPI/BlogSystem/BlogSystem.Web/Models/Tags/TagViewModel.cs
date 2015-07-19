namespace BlogSystem.Web.Models.Tags
{
    using AutoMapper;

    using BlogSystem.Models;

    public class TagViewModel : TagModel
    {
        public int Id { get; set; }

        public override void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Tag, TagViewModel>();
        }
    }
}