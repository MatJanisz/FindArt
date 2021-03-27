using FindArt.Core.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FindArt.DataAccess.Repositories.Base
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected FindArtDbContext RepositoryContext;

        public Repository(FindArtDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
              RepositoryContext.Set<T>()
                .AsNoTracking() :
              RepositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges) =>
            !trackChanges ?
              RepositoryContext.Set<T>()
                .Where(expression)
                .AsNoTracking() :
              RepositoryContext.Set<T>()
                .Where(expression);

        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

        public void Update(T entity)
		{
            RepositoryContext.Set<T>().Attach(entity);
            RepositoryContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
    }
}
