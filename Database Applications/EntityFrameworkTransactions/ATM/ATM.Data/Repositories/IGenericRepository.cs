namespace ATM.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository<T> where T : class 
    {
        void Add(T entity);

        T Delete(T entity);

        IQueryable<T> All();

        IQueryable<T> Search(Expression<Func<T, bool>> condition);
    }
}