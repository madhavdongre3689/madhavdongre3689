using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDataStore.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T entity);
        void Update(T entity);
        T Read(string Id);
        bool Delete(string Id);
        public IEnumerable<T> GetAllBooks();
    }
}
