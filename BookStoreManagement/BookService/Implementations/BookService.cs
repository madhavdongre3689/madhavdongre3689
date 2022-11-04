using BookDataStore.Interfaces;
using BookEntities.BusinessEntities;
using BookStoreService.Interfaces;
using BookService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookDataStore;

namespace BookStoreService.Implementations
{
    public class BookService : IBookService
    {

        private readonly IRepository<BookDto> _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IRepository<BookDto> repository, IMapper mapper)
        {
            _bookRepository = repository;
            _mapper = mapper;
        }
        public string AddBook(Book book)
        {
            string Id = Guid.NewGuid().ToString();
            book.Id = Id;
            var bookDto = _mapper.Map<BookDto>(book);
            _bookRepository.Create(bookDto);
            return book.Id;
        }

        public bool DeleteBook(string Id)
        {
            return _bookRepository.Delete(Id);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var booksDto = _bookRepository.GetAllBooks();
            var books = _mapper.Map<IEnumerable<Book>>(booksDto);
            return books;
        }

        public Book GetBook(string Id)
        {
            var bookDto = _bookRepository.Read(Id);
            var book = _mapper.Map<Book>(bookDto);
            return book;
        }

        public void UpdateBook(Book book)
        {
            var bookDto = _mapper.Map<BookDto>(book);
            _bookRepository.Update(bookDto);
        }

    }
}
