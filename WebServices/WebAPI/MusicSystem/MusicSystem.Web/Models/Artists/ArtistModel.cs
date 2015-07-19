namespace MusicSystem.Web.Models.Artists
{
    using System;

    using MusicSystem.Models;
    using MusicSystem.Web.Infrastructure.Mapping;

    public class ArtistModel : IMapFrom<Artist>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}