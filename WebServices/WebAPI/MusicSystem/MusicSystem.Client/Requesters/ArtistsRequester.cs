namespace MusicSystem.Client.Requesters
{
    using System.Collections.Generic;
    using System.Net.Http;

    using MusicSystem.Client.Models.Albums;
    using MusicSystem.Client.Models.Artists;

    using Newtonsoft.Json;

    public class ArtistsRequester : Requester
    {
        public ArtistsRequester(HttpClient client)
            : base(client)
        {
        }

        public ArtistModel GetArtist(int id)
        {
            var artist = this.Get<ArtistModel>("api/Artists/Get/" + id);
            return artist;
        }

        public ArtistModel CreateArtist(ArtistModel artistModel)
        {
            var content = this.CreateJsonContent(artistModel);

            var artist = this.Post<ArtistModel>("api/Artists/Add", content);
            return artist;
        }

        public ArtistModel EditArtist(int id, ArtistModel artistModel)
        {
            var content = this.CreateJsonContent(artistModel);

            var albums = this.Put<ArtistModel>("api/Artists/Edit/" + id, content);
            return albums;
        }

        public void DeleteArtist(int id)
        {
            this.Delete("api/Artists/Delete/" + id);
        }
    }
}
