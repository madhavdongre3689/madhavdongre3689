using BookEntities.BusinessEntities;
using BookService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreService.Interfaces
{
    public interface IBookService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Book GetBook(string Id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        string AddBook(Book book);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        void UpdateBook(Book book);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool DeleteBook(string Id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Book> GetAllBooks();
    
    }
}
