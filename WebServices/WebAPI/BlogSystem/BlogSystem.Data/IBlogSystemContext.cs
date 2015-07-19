namespace BlogSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using BlogSystem.Models;

    public interface IBlogSystemContext
    {
        IDbSet<Post> Posts { get; set; }

        IDbSet<Tag> Tags { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}