using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RepositoryPattern.BL
{
    public class UnitOfWork : IDisposable
    {
        private DbContext dbContext;

        private bool disposed = false;

        private Hashtable repositories;

        public UnitOfWork()
        {
            this.dbContext = new DL.RepositoryPatternContext();
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        // Summary
        //      When calling unitOfWork.Repository<T>()
        //      this returns the specific <T> repository.
        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories == null)
                repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                            .MakeGenericType(typeof(T)), this.dbContext);

                repositories.Add(type, repositoryInstance);
            }

            return (IRepository<T>)repositories[type];
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
