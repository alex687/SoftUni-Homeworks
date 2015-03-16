namespace News.Data
{
    using News.Data.Repositories;

    using News.Model;

    public interface INewsData
    {
        IGenericRepository<News> News { get; }

        int SaveChanges();
    }
}

