namespace ATM.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using ATM.Data.Repositories;

    public class AtmSystemData : IAtmData
    {
        private readonly IAtmDbContext context;

        private readonly Dictionary<Type, object> repositories; 

        public AtmSystemData()
            : this(new AtmEntities())
        {
        }

        public AtmSystemData(IAtmDbContext givenContext)
        {
            this.context = givenContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<CardAccount> CardAccounts
        {
            get
            {
                return (IGenericRepository<CardAccount>)this.GetRepository(typeof(GenericRepository<CardAccount>));
            }
        }

        public IGenericRepository<TransactionHistory> TransactionHistory
        {
            get
            {
                return (IGenericRepository<TransactionHistory>)this.GetRepository(typeof(GenericRepository<TransactionHistory>));
            }
        }

        public DbContextTransaction BeginTransaction()
        {
            return this.context.Database.BeginTransaction();
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