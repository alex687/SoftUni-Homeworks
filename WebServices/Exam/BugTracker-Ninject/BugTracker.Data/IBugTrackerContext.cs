namespace BugTracker.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using BugTracker.Data.Models;

    public interface IBugTrackerContext
    {
        IDbSet<Bug> Bugs { get; set; }

        IDbSet<User> Users { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}