namespace ForumSystem.Web.Models.Tags
{
    using ForumSystem.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class TagViewModel : IMapFrom<Tag>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<TagViewModel, string>().ConvertUsing(r => r.Name);
            configuration.CreateMap<string, TagViewModel>().ConvertUsing(s => new TagViewModel() { Name = s });
        }
    }
}