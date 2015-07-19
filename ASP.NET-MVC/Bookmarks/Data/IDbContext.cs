
namespace Bookmarks.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Bookmarks.Models;

    public interface IDbContext
    {
        IDbSet<Bookmark> Bookmarks { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Vote> Votes { get; set; }

        IDbSet<User> Users { get; set; }

        int SaveChanges();

        DbEntityEntry Entry(object entity);
    }
}
