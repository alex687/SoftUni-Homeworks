namespace News.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly INewsDbContext context;

        public GenericRepository(INewsDbContext context)
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

        public IQueryable<T> All()
        {
            return this.context.Set<T>().AsQueryable();
        }

        public T First()
        {
            return this.context.Set<T>().FirstOrDefault();
        }

        public void Reload(T entry)
        {
            this.context.Entry(entry).Reload();
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
