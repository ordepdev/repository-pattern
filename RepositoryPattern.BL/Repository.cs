using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace RepositoryPattern.BL
{
    public class Repository<T> : IRepository<T> where T : DL.Entity
    {
        internal DbSet<T> dbSet;
        internal DbContext dbContext;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedOn = DateTime.Now;
            entity.ModifiedOn = DateTime.Now;
            this.dbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            this.dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            entity.ModifiedOn = DateTime.Now;
        }

        public List<T> All()
        {
            return this.dbSet.ToList();
        }

        public List<T> Where(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.Where(predicate).ToList();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.FirstOrDefault(predicate);
        }

        public T FindById(Guid id)
        {
            return this.dbSet.Find(id);
        }
    }
}
