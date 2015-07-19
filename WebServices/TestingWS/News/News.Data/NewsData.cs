namespace News.Data
{
    using System;
    using System.Collections.Generic;

    using News.Data.Repositories;
    using News.Models;

    public class NewsData : INewsData
    {
        private readonly INewsDbContext context;

        private readonly Dictionary<Type, object> repositories;

        public NewsData(INewsDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<ApplicationUser> Users
        {
            get
            {
                return (IGenericRepository<ApplicationUser>)this.GetRepository(typeof(GenericRepository<ApplicationUser>));
            }
        }

        public IGenericRepository<NewsItem> News
        {
            get
            {
                return (IGenericRepository<NewsItem>)this.GetRepository(typeof(GenericRepository<NewsItem>));
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private object GetRepository(Type repositoryType)
        {
            if (this.repositories.ContainsKey(repositoryType))
            {
                return this.repositories[repositoryType];
            }

            var newRepository = Activator.CreateInstance(repositoryType, this.context);
            this.repositories.Add(repositoryType, newRepository);

            return newRepository;
        }
    }
}
