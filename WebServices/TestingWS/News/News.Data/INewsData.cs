namespace News.Data
{
    using News.Data.Repositories;
    using News.Models;

    public interface INewsData
    {
        IGenericRepository<NewsItem> News { get; }
        
        IGenericRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}

