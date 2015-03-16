namespace News.Data
{
    using System.Data.Entity;

    using News.Data.Migrations;
    using News.Model;

    public class NewsDbContext : DbContext, INewsDbContext
    {
        public NewsDbContext()
            : base("News")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsDbContext, Configuration>());
        }

        public IDbSet<News> News { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
