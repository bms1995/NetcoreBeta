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
            _publishersService.AddPublisher(publisher);
            return Ok();

        }
    }
}
