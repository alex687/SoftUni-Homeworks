namespace BlogSystem.Data
{
    using System.Data.Entity;

    using BlogSystem.Data.Migrations;
    using BlogSystem.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class BlogSystemContext : IdentityDbContext<ApplicationUser>, IBlogSystemContext
    {
        public BlogSystemContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogSystemContext, Configuration>());
        }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public IDbSet<Comment> Comments { get; set; }
        
        public static BlogSystemContext Create()
        {
            return new BlogSystemContext();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

    }
}