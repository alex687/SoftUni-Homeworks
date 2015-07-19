namespace Bookmarks.Data
{
    using Bookmarks.Data.Repositories;
    using Bookmarks.Models;

    public interface IBookmarksData
    {
        IRepository<User> Users { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Bookmark> Bookmarks { get; }

        IRepository<Vote> Votes { get; }

        IRepository<Category> Categories { get; }

        int SaveChanges();
    }
}
