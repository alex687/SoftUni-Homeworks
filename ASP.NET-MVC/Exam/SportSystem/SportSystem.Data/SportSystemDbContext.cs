namespace SportSystem.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using SportSystem.Models;

    public class SportSystemDbContext : IdentityDbContext<User>, IDbContext
    {
        public SportSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Team> Teams { get; set; }

        public IDbSet<Player> Players { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Match> Matches { get; set; }

        public IDbSet<Bet> Bets { get; set; }

        public static SportSystemDbContext Create()
        {
            return new SportSystemDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>()
                .HasRequired(m => m.AwayTeam)
                .WithMany(t => t.AwayMatches)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                .HasRequired(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .WillCascadeOnDelete(false);
        }
    }
}
