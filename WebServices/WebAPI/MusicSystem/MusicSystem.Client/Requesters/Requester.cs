namespace MusicSystem.Client.Requesters
{
    using System.Net.Http;

    using Newtonsoft.Json;

    public abstract class Requester
    {
        protected Requester(HttpClient client)
        {
            this.Client = client;
        }

        protected HttpClient Client { get; set; }

        protected T Get<T>(string uri)
        {
            var response = this.Client.GetAsync(uri).Result;
            var json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(json);
        }

        protected T Post<T>(string uri, HttpContent content)
        {
            var response = this.Client.PostAsync(uri, content).Result;
            var json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(json);
        }

        protected T Put<T>(string uri, HttpContent content)
        {
            var response = this.Client.PutAsync(uri, content).Result;
            var json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(json);
        }

        protected HttpResponseMessage Delete(string uri)
        {
            var response = this.Client.DeleteAsync(uri).Result;

            return response;
        }

        protected HttpContent CreateJsonContent<T>(T data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return content;
        }
    }
}
