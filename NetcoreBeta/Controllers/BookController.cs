using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetcoreBeta.Data.Services;
using NetcoreBeta.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreBeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BooksService _booksService;
        public BookController(BooksService bookservice)
        {
            _booksService = bookservice;
        }
        [HttpPost("add-book-with-authors")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBookwithAuthors(book);
            return Ok();

        }
        [HttpGet("Get-books")]
        public IActionResult GetBooks()
        {
            var books=_booksService.GetBooks();
            return Ok(books);

        }
        [HttpGet("Get-book-ById/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksService.GetBookById(id);
            return Ok(book);

        }
        [HttpPut("Update-book-ById/{id}")]
        public IActionResult UpdateBookById(int id,[FromBody]BookVM bookVM)
        {
            var book = _booksService.UpdateBook(id, bookVM);
            return Ok(book);

        }
        [HttpDelete("Delete-book-ById/{id}")]
        public IActionResult DeleteBookById(int id)
        {
             _booksService.DeleteBook(id);
            return Ok();

        }
    }
}
