namespace ProcessingJson
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using ProcessingJson.POCO;

    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new WebClient();
            client.DownloadFile("https://softuni.bg/Feed/News", "news.xml");

            XDocument news = XDocument.Load("news.xml");
            var json = JsonConvert.SerializeXNode(news.Root.Element("channel"), Formatting.Indented);
            File.WriteAllText("news.json", json);


            var jsonObj = JObject.Parse(json);
            var titles = jsonObj["channel"]["item"].ToList();
            foreach (var title in titles.Select(n => n["title"]))
            {
                Console.WriteLine(title);
            }
        
            var newsPoco = titles.Select(item => JsonConvert.DeserializeObject<NewsPoco>(item.ToString())).ToList();

            var result = new StringBuilder();
            result.Append("<!DOCTYPE html><html><head></head><body>");
            foreach (var jsonToPoco in newsPoco)
            {
                result.Append(jsonToPoco.ToString());
            }

            result.Append("</body></html>");
            File.WriteAllText("view.html", result.ToString());
        }
    }
}
