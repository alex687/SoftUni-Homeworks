namespace MusicSystem.Client.Models.Albums
{
    using System.Collections.Generic;

    using MusicSystem.Client.Models.Artists;
    using MusicSystem.Client.Models.Songs;

    public class AlbumModel : AlbumSmallModel
    {
        public List<SongModel> Songs { get; set; }

        public List<ArtistModel> Artists { get; set; }
    }
}