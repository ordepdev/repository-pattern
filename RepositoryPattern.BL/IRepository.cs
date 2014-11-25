using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RepositoryPattern.BL
{
    // Summary
    //      This is a generic IRepository
    //      where T is DL.Entity
    public interface IRepository<T>
    {
        // Summary
        //     Adds the given entity into context.
        void Add(T entity);

        // Summary:
        //     Removes the given entity from the context.
        void Remove(T entity);

        // Summary:
        //     Updates the given entity from the context.
        void Update(T entity);

        // Summary:
        //     Returns all entities of the sequence.
        List<T> All();

        // Summary:
        //     Filters a sequence of values based on a predicate.
        List<T> Where(Expression<Func<T, bool>> predicate);

        // Summary:
        //     Returns the first element of a sequence that satisfies a specified condition
        //     or a default value if no such element is found.
        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        // Summary:
        //     Returns an entity with the given primary key value.
        T FindById(Guid id);
    }
}
