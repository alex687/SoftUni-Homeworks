namespace MusicSystem.Client
{
    using System;
    using System.Net.Http;

    using MusicSystem.Client.Requesters;

    public class Program
    {
        public static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:56935/");
            
            var userReq = new UserRequester(httpClient);
            var token = userReq.Login("pro687@abv.bg", "123456");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);


            var aRequester = new AlbumsRequester(httpClient);

            var albums = aRequester.GetAllAlbums();

            foreach (var album in albums)
            {
                Console.WriteLine(album.Title);
            }
        }
    }
}
