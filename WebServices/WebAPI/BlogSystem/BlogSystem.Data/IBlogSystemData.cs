namespace BlogSystem.Data
{
    using BlogSystem.Data.Repositories;
    using BlogSystem.Models;

    public interface IBlogSystemData
    {
        IGenericRepository<Post> Posts { get; }

        IGenericRepository<Tag> Tags { get; }

        IGenericRepository<Comment> Comments { get; }
        
        IGenericRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}

