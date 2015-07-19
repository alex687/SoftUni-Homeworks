namespace BugTracker.Data
{
    using System.Data.Entity;

    using BugTracker.Data.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class BugTrackerDbContext : IdentityDbContext<User>, IBugTrackerContext
    {
        public BugTrackerDbContext()
            : base("BugTracker")
        {
        }

        public static BugTrackerDbContext Create()
        {
            return new BugTrackerDbContext();
        }

        public IDbSet<Bug> Bugs { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
