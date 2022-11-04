using BookAPI.Controllers;
using BookEntities.BusinessEntities;
using BookService.ViewModels;
using BookStoreService.Interfaces;
using log4net.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookAPITests.BookControllerTests
{
    internal class BookControllerTests
    {
        private IBookService _bookService;
        public BookControllerTests(IBookService bookService)
        {
            _bookService = bookService;
        }
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetAPITestWithEmptyInputs()
        {
            //Arrange
            BookController bookController = new BookController(_bookService);

            //Act
            var result = (ObjectResult)bookController.GetBook("");

            //Assert
            Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        [Test]
        public void GetAPITestWithCorrectInputs()
        {
            //Arrange
            BookController bookController = new BookController(_bookService);
            var Id = _bookService.AddBook(new BookService.ViewModels.Book { Name = "Rich Dad Poor Dad", AuthorName = "Robert Kiosaki" });

            //Act
            var result = (ObjectResult)bookController.GetBook(Id);
            var bookResult = result.Value as Book;
            //Assert
            Assert.AreEqual(bookResult?.Name, "Rich Dad Poor Dad");
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
        }


        [Test]
        public void PostAPITestWithEmptyInputs()
        {
            //Arrange
            BookController bookController = new BookController(_bookService);

            //Act
            var result = (ObjectResult)bookController.AddBook(null);
            var bookResult = result.Value as string;
            
            //Assert
            Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        [Test]
        public void PostAPITestWithCorrectInputs()
        {
            //Arrange
            BookController bookController = new BookController(_bookService);

            //Act
            var result = (ObjectResult)bookController.AddBook(new Book { Name = "Rich Dad Poor Dad", AuthorName = "Robert Kiosaki" });
            var bookResult = result.Value as string;

            //Assert
            Assert.AreEqual(StatusCodes.Status201Created, result.StatusCode);
        }
    }
}
