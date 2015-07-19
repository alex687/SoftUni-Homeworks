namespace News.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using News.Models;
    
    public interface INewsDbContext
    {
        IDbSet<NewsItem> News { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}