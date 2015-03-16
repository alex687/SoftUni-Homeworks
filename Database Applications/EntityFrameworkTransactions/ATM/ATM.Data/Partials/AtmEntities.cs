namespace ATM.Data
{
    using System.Data.Entity;

    public partial class AtmEntities : IAtmDbContext
    {
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
