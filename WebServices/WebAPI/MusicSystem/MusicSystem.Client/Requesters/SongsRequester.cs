namespace MusicSystem.Client.Requesters
{
    using System.Net.Http;

    using MusicSystem.Client.Models.Songs;

    using Newtonsoft.Json;

    public class SongsRequester : Requester
    {
        public SongsRequester(HttpClient client)
            : base(client)
        {
        }

        public SongModel GetSong(int id)
        {
            var album = this.Get<SongModel>("api/Albums/Get/" + id);

            return album;
        }

        public SongModel AddSong(SongModel albumSmall)
        {
            var content = this.CreateJsonContent(albumSmall);

            var song = this.Post<SongModel>("api/Songs/Add", content);
            return song;
        }

        public SongModel EditSong(int id, SongModel albumSmall)
        {
            var content = this.CreateJsonContent(albumSmall);

            var song = this.Post<SongModel>("api/Songs/Edit/" + id, content);
            return song;
        }

        public void DeleteSong(int id)
        {
            this.Delete("api/Songs/Delete/" + id);
        }
    }
}
