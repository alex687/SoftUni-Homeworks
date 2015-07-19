namespace BlogSystem.Web.Models.Tags
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using BlogSystem.Models;
    using BlogSystem.Web.Infrastructure.Mapping;

    public abstract class TagModel : IMapFrom<Tag>, IHaveCustomMappings
    {
        [Required(ErrorMessage = "The Name is required")]
        [MinLength(1)]
        [MaxLength(150)]
        public string Name { get; set; }

        public abstract void CreateMappings(IConfiguration configuration);
    }
}