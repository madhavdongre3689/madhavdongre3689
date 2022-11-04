using BookEntities.Exceptions;
using BookService.ViewModels;
using BookStoreService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BookController>? _logger;
        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

      

        /// <summary>
        /// API for fetching the book
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetBook")]
        public IActionResult GetBook(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return BadRequest("Id cannot be empty");
            }
            try
            {
                var book = _bookService.GetBook(Id);
                return Ok(book);
            }
            catch(DatabaseException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// API for Adding new book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost("AddBook")]
        public IActionResult AddBook(Book book)
        {
            if (book == null)
            {
                return BadRequest("content cannot be null");
            }
            try
            {
                var Id = _bookService.AddBook(book);
                return StatusCode(StatusCodes.Status201Created, Id);
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        /// <summary>
        /// API for updtae/mutate the existing book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut("UpdateBook")]
        public IActionResult UpdateBook(Book book)
        {
            if (book == null)
            {
                return BadRequest("content cannot be null");
            }
            try
            {
                _bookService.UpdateBook(book);
                 return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// API for fetching all the books
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _bookService.GetAllBooks();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}