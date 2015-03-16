namespace ATM.Data
{
    using System.Data.Entity;

    using ATM.Data.Repositories;

    public interface IAtmData
    {
        IGenericRepository<CardAccount> CardAccounts { get; }

        IGenericRepository<TransactionHistory> TransactionHistory { get; }

        int SaveChanges();

        DbContextTransaction BeginTransaction();
    }
}