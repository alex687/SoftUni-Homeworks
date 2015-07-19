namespace MusicSystem.Client.Requesters
{
    using System.Collections.Generic;
    using System.Net.Http;

    using MusicSystem.Client.Models.Albums;

    using Newtonsoft.Json;

    public class AlbumsRequester : Requester
    {
        public AlbumsRequester(HttpClient client)
            : base(client)
        {
        }

        public List<AlbumSmallModel> GetAllAlbums()
        {
            var albums = this.Get<List<AlbumSmallModel>>("api/Albums/GetAllAlbums");
            return albums;
        }

        public AlbumModel GetAlbum(int id)
        {
            var album = this.Get<AlbumModel>("api/Albums/Get/" + id);
            return album;
        }

        public AlbumSmallModel CreateAlbum(AlbumSmallModel albumSmall)
        {
            var content = this.CreateJsonContent(albumSmall);

            var albums = this.Post<AlbumSmallModel>("api/Albums/Add", content);
            return albums;
        }

        public AlbumSmallModel EditAlbum(int id, AlbumSmallModel albumSmall)
        {
            var content = this.CreateJsonContent(albumSmall);

            var albums = this.Put<AlbumSmallModel>("api/Albums/Edit/" + id, content);
            return albums;
        }

        public void DeleteAlbum(int id)
        {
            this.Delete("api/Albums/Delete/" + id);
        }
    }
}
