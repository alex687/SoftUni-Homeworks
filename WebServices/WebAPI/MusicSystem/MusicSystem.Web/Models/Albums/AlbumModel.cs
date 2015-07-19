
namespace MusicSystem.Web.Models.Albums
{
    using System.Collections.Generic;

    using MusicSystem.Models;
    using MusicSystem.Web.Models.Artists;
    using MusicSystem.Web.Models.Songs;

    public class AlbumModel : AlbumSmallModel
    {
        public ICollection<SongModel> Songs { get; set; }

        public ICollection<ArtistModel> Artists { get; set; }
    }
}