namespace News.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using News.Models;

    public class NewsDbContext : IdentityDbContext<ApplicationUser>, INewsDbContext
    {
        public NewsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<NewsItem> News { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public static NewsDbContext Create()
        {
            return new NewsDbContext();
        }
    }
}
