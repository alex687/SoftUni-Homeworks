namespace BlogSystem.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IBlogSystemContext context;

        public GenericRepository(IBlogSystemContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        public T Delete(T entity)
        {
           return this.ChangeEntityState(entity, EntityState.Deleted);
        }

        public void Detach(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Detached);
        }

        public IQueryable<T> All()
        {
            return this.context.Set<T>().AsQueryable();
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> condition)
        {
            return this.context.Set<T>().Where(condition);
        }

        private T ChangeEntityState(T entity, EntityState state)
        {
            this.context.Set<T>().Attach(entity);
            this.context.Entry(entity).State = state;

            return entity;
        }
    }
}
