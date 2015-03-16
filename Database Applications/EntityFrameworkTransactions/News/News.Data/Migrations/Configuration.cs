namespace News.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using News.Model;
    internal sealed class Configuration : DbMigrationsConfiguration<NewsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "News.Data.NewsDbContext";
        }

        protected override void Seed(NewsDbContext context)
        {
            if (context.News.Any())
            {
              return;  
            }

            News news = new News { Content = "First News Seeded" };
            context.News.Add(news);
            context.SaveChanges();
        }
    }
}
