
namespace DistanceCalculatorRestClient
{
    using System;
    using System.Net.Http;

    using RestSharp;

    public class Program
    {

        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:28670/") };

        public static void Main()
        {
            var client = new RestClient("http://localhost:1144/");

            var request = new RestRequest("api/DistanceCalculator", Method.POST);
            var points = new Points() { Start = new Point() { X = 9, Y = 7 }, End = new Point() { X = 3, Y = 2 } };
            request.AddJsonBody(points);
            
            var response = client.Execute(request);
            Console.WriteLine(response.Content);

        }
    }
}
