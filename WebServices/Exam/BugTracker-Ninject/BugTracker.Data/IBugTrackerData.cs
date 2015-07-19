namespace BugTracker.Data
{
    using BugTracker.Data.Models;
    using BugTracker.Data.Repositories;

    public interface IBugTrackerData
    {
        IGenericRepository<Bug> Bugs { get; }

        IGenericRepository<Comment> Comments { get; }

        IGenericRepository<User> Users { get; }

        int SaveChanges();
    }
}

