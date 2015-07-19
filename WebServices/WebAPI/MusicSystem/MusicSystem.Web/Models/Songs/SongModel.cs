namespace MusicSystem.Web.Models.Songs
{
    using MusicSystem.Models;
    using MusicSystem.Web.Infrastructure.Mapping;

    public class SongModel : IMapFrom<Song>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public int ArtistId { get; set; }
    }
}