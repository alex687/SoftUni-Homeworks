namespace MusicSystem.Web.Models.Albums
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using MusicSystem.Models;
    using MusicSystem.Web.Infrastructure.Mapping;

    public class AlbumSmallModel : IMapFrom<Album>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int Year { get; set; }

        [Required]
        public string Producer { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Album, AlbumSmallModel>();
            configuration.CreateMap<AlbumSmallModel, Album>();
        }
    }
}