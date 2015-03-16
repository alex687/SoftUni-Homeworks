namespace News.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using News.Model;

    public interface INewsDbContext
    {
        IDbSet<News> News { get; set; }
        
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
