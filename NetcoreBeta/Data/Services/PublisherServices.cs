using NetcoreBeta.Data.Models;
using NetcoreBeta.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreBeta.Data.Services
{
    public class PublisherServices
    {
        private AppDBContext _context;
        public PublisherServices(AppDBContext context)
        {
            _context = context;
        }
        public void AddPublisher(PublisherVM book)
        {
            var _publisher = new Publisher()
            {
                Name = book.Name,
             
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }
    }
}
