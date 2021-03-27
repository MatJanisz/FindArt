using System;
using System.Linq;
using System.Linq.Expressions;

namespace FindArt.Core.Interfaces.Repositories.Base
{
    public interface IRepository<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
