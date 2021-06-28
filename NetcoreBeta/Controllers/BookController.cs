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
        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBook(book);
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
    }
}
