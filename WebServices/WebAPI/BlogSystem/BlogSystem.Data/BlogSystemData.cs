namespace BlogSystem.Data
{
    using System;
    using System.Collections.Generic;

    using BlogSystem.Data.Repositories;
    using BlogSystem.Models;

    public class BlogSystemData : IBlogSystemData
    {
        private readonly IBlogSystemContext context;

        private readonly Dictionary<Type, object> repositories;

        public BlogSystemData(IBlogSystemContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Post> Posts
        {
            get
            {
                return (IGenericRepository<Post>)this.GetRepository(typeof(GenericRepository<Post>));
            }
        }

        public IGenericRepository<ApplicationUser> Users
        {
            get
            {
                return (IGenericRepository<ApplicationUser>)this.GetRepository(typeof(GenericRepository<ApplicationUser>));
            }
        }

        public IGenericRepository<Comment> Comments
        {
            get
            {
                return (IGenericRepository<Comment>)this.GetRepository(typeof(GenericRepository<Comment>));
            }
        }

        public IGenericRepository<Tag> Tags
        {
            get
            {
                return (IGenericRepository<Tag>)this.GetRepository(typeof(GenericRepository<Tag>));
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
