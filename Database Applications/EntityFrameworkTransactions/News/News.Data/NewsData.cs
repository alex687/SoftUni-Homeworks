namespace News.Data
{
    using System;
    using System.Collections.Generic;

    using News.Data.Repositories;
    using News.Model;

    public class NewsData : INewsData
    {
        private readonly INewsDbContext context;

        private readonly Dictionary<Type, object> repositories;

        public NewsData()
            : this(new NewsDbContext())
        {
        }

        public NewsData(INewsDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<News> News
        {
            get
            {
                return (IGenericRepository<News>)this.GetRepository(typeof(GenericRepository<News>));
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
