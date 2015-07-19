namespace Twitter.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Twitter.Data.Migrations;
    using Twitter.Models;

    public class DbContext : IdentityDbContext<User>, IDbContext
    {
        public DbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbContext, Configuration>());
        }

        public IDbSet<Tweet> Tweets { get; set; }
        
        public IDbSet<Message> Messages { get; set; }
        
        public IDbSet<Notification> Notifications { get; set; }

        public static DbContext Create()
        {
            return new DbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tweet>().HasMany<User>(t => t.FavoritedByUsers).WithMany(u => u.FavoriteTweets).Map(tu =>
            {
                tu.MapLeftKey("Tweet_TweetId");
                tu.MapRightKey("User_UserId");
                tu.ToTable("UsersFavoriteTweets");
            });

            modelBuilder.Entity<Tweet>()
                        .HasRequired<User>(t => t.User)
                        .WithMany(u => u.Tweets)
                        .HasForeignKey(t => t.UserId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Sender)
                .WithMany(s => s.SentMessages)
                .WillCascadeOnDelete(false);

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

    }
}
