namespace Twitter.Data
{
    using System.Data.Entity;

    using Twitter.Models;

    public interface IDbContext
    {
        IDbSet<Tweet> Tweets { get; set; }

        IDbSet<Message> Messages { get; set; }

        IDbSet<Notification> Notifications { get; set; }

        int SaveChanges();
    }
}
