using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetcoreBeta.Data.Models;
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
    public class PublisherController : ControllerBase
    {
        public PublisherServices _publishersService;
        public PublisherController(PublisherServices publishersService)
        {
            _publishersService = publishersService;
        }
        [HttpPost("add-publisher")]
        public IActionResult AddBook([FromBody] PublisherVM publisher)
        {
           var _publisher= _publishersService.AddPublisher(publisher);
            return Created(nameof(AddBook),_publisher);

        }

        [HttpGet("Get-publisher-by-id/{id}")]
        public ActionResult<Publisher> GetPublisherById(int id)
        {
            var publisher = _publishersService.getPublisherById(id);
            if(publisher != null)
            {
                return publisher;
            }
            else
            {
              return  NotFound();
            }
           

        }
        [HttpGet("Get-publisher-with-books-and-authors/{id}")]
        public IActionResult GetPublisherwithBooksandAuthors(int id)
        {
            try
            {
                var publisher = _publishersService.getPublishers(id);
                return Ok(publisher);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          

        }
        [HttpDelete("delete-publisher/{id}")]
        public IActionResult DeletePublisher(int id)
        {
            _publishersService.DeletePublisher(id);
            return Ok();

        }
    }
}
