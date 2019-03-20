using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace GettyWAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> DBSet;

        public Repository(DbContext dataContext)
        {
            DBSet = dataContext.Set<T>();
        }

        #region IRepository<T> MEmbers

        public void Insert(T entity)
        {
            DBSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DBSet.Remove(entity);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return DBSet.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return DBSet;
        }

        public T GetById(int id)
        {
            return DBSet.Find(id);
        }

        #endregion
    }
}