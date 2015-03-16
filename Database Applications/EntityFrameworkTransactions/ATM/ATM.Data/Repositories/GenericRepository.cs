namespace ATM.Data.Repositories
{
    using System;
    using System.CodeDom;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IAtmDbContext context;

        public GenericRepository(IAtmDbContext entities)
        {
            this.context = entities;
        }

        public void Add(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Added);
        }

        public T Delete(T entity)
        {
            return this.ChangeEntityState(entity, EntityState.Deleted);
        }

        public IQueryable<T> All()
        {
            return this.context.Set<T>().AsQueryable();
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> condition)
        {
            return this.context.Set<T>().Where(condition).AsQueryable();
        }

        private T ChangeEntityState(T entity, EntityState state)
        {
            this.context.Set<T>().Attach(entity);
            this.context.Entry(entity).State = state;

            return entity;
        }
    }
}