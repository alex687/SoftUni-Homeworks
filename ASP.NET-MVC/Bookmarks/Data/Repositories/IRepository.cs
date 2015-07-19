namespace Bookmarks.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        T Find(object id);

        IQueryable<T> Search(Expression<Func<T, bool>> predicate);

        T Add(T entity);

        void Update(T entity);

        void Update(object id);

        T Delete(object id);

        T Delete(T entity);

        void Detach(T entity);

        void Attach(T entity);

        int SaveChanges();
    }
}
