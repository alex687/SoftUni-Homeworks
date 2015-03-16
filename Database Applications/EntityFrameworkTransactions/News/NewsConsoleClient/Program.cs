
namespace NewsConsoleClient
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.IO;
    using System.Linq;
    using System.Text;

    using News.Data;
    using News.Model;

    public class Program
    {
        private static readonly NewsData NewsData = new NewsData();

        public static void Main(string[] args)
        {
            var news = NewsData.News.First();

            Console.WriteLine(news.Content);
            Console.WriteLine("Enter a new news text");

            try
            {
                news.Content = ReadText(Console.In);
                NewsData.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                NewsConcurrencyUpdateHandle(news);
            }
        }

        private static string ReadText(TextReader textStream)
        {
            string line;
            var text = new StringBuilder();
            while ((line = textStream.ReadLine()) != null)
            {
                text.Append(line);
            }

            return text.ToString();
        }

        private static void NewsConcurrencyUpdateHandle(News news)
        {
            try
            {
                NewsData.News.Reload(news);
                Console.WriteLine("Conflict! The text was upradet before you.The new version :");
                Console.WriteLine(news.Content);
                Console.WriteLine("Enter a new news text");

                news.Content = ReadText(Console.In);
                NewsData.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                NewsConcurrencyUpdateHandle(news);                
            } 
        }
    }
}
