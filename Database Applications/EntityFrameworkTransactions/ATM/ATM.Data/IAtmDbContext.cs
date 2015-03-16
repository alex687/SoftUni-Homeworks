namespace ATM.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IAtmDbContext
    { 
        DbSet<CardAccount> CardAccounts { get; set; }
        
        DbSet<TransactionHistory> TransactionHistories { get; set; }

        Database Database { get; }
        
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
       
        int SaveChanges();
    }
}