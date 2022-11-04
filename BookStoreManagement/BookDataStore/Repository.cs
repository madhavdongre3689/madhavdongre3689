using BookDataStore.Interfaces;
using BookEntities.BusinessEntities;
using BookEntities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDataStore
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext dbContext;
        public Repository(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new DatabaseException("Entity cannot be empty");
            }
            dbContext.Set<T>().Add(entity);
        }

        public virtual bool Delete(string Id)
        {
            var entity = dbContext.Set<T>().Find(Id);
            if (entity == null)
            {
                throw new DatabaseException("Entity not found");
            }
            dbContext.Set<T>().Remove(entity);
            return true;
        }

        public virtual T Read(string Id)
        {
            var entity = dbContext.Set<T>().Find(Id);
            if (entity == null)
            {
                throw new DatabaseException("Entity not found");
            }
            return entity;
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new DatabaseException("Entity cannot be empty");
            }

            dbContext.Set<T>().Update(entity);
        }

        public virtual IEnumerable<T> GetAllBooks()
        {
            return dbContext.Set<T>().ToList();
        }
    }
}
