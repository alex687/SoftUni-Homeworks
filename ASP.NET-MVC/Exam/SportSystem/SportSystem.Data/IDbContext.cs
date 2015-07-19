namespace SportSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using SportSystem.Models;

    public interface IDbContext
    {
        IDbSet<Team> Teams { get; set; }

        IDbSet<Player> Players { get; set; }

        IDbSet<Vote> Votes { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Match> Matches { get; set; }

        IDbSet<Bet> Bets { get; set; }
        

        IDbSet<User> Users { get; set; }

        int SaveChanges();

        DbEntityEntry Entry(object entity);
    }
}
