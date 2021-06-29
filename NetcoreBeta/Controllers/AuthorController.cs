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
    public class AuthorController : ControllerBase
    {
        public AuthorServices _authorService;
        public AuthorController(AuthorServices authorsService)
        {
            _authorService = authorsService;
        }
        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorService.AddAuthor(author);
            return Ok();

        }
        [HttpGet("Get-author-with-books/{id}")]
        public IActionResult GetAuthorwithBooks(int id)
        {
            var author = _authorService.GetAuthorWithBooks(id);
            return Ok(author);

        }
    }
}
