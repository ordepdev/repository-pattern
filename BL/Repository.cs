using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using RepositoryPattern.DL;

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
            entity.CreatedBy = HttpContext.Current.User.Identity.Name;
            entity.CreatedOn = DateTime.Now;
            entity.ModifiedBy = HttpContext.Current.User.Identity.Name;
            entity.ModifiedOn = DateTime.Now;
            this.dbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            this.dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            entity.ModifiedBy = HttpContext.Current.User.Identity.Name;
            entity.ModifiedOn = DateTime.Now;
        }

        public IEnumerable<T> All()
        {
            return this.dbSet.AsEnumerable();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.Where(predicate);
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