namespace MusicSystem.Client.Requesters
{
    using System.Collections.Generic;
    using System.Net.Http;

    using Newtonsoft.Json;

    public class UserRequester : Requester
    {
        public UserRequester(HttpClient client)
            : base(client)
        {
        }

        public string Login(string username, string password)
        {
            var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            });
            var response = this.Client.PostAsync("/Token", content).Result;


            string responseContent = response.Content.ReadAsStringAsync().Result;


            return JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent)["access_token"];
        }
    }
}
