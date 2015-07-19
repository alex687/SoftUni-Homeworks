namespace BugTracker.Data
{
    using System;
    using System.Collections.Generic;

    using BugTracker.Data.Models;
    using BugTracker.Data.Repositories;
   
    public class BugTrackerData : IBugTrackerData
    {
        private readonly IBugTrackerContext context;

        private readonly Dictionary<Type, object> repositories;

        public BugTrackerData(IBugTrackerContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Bug> Bugs
        {
            get
            {
                return (IGenericRepository<Bug>)this.GetRepository(typeof(GenericRepository<Bug>));
            }
        }

        public IGenericRepository<User> Users
        {
            get
            {
                return (IGenericRepository<User>)this.GetRepository(typeof(GenericRepository<User>));
            }
        }

        public IGenericRepository<Comment> Comments
        {
            get
            {
                return (IGenericRepository<Comment>)this.GetRepository(typeof(GenericRepository<Comment>));
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
