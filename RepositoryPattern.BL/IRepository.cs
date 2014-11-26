using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RepositoryPattern.BL
{
    public interface IRepository<T>
    {
        void Add(T entity);
        
        void Remove(T entity);

        void Update(T entity);

        List<T> All();

        List<T> Where(Expression<Func<T, bool>> predicate);
    
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        
        T FindById(Guid id);
    }
}
