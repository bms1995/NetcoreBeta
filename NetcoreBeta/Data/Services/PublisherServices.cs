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
        public Publisher AddPublisher(PublisherVM book)
        {
            var _publisher = new Publisher()
            {
                Name = book.Name,
             
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
            return _publisher;
        }

        public Publisher getPublisherById(int id) => _context.Publishers.FirstOrDefault(x => x.Id == id);

        public PublisherWithBooksAndAuthorsVM getPublishers(int Id)
        {
            var publisher = _context.Publishers.Where(x => x.Id == Id)
                .Select(x => new PublisherWithBooksAndAuthorsVM
                {
                    Name = x.Name,
                    BookAuthors = x.Books.Select(x => new BookAuthorVM
                    {
                        BookName = x.Title,
                        BookAuthors = x.Book_Authors.Select(x => x.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();
            return publisher;
        }

        public void DeletePublisher(int id)
        {
            var publisher = _context.Publishers.FirstOrDefault(x => x.Id == id);
            if(publisher != null)
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
        }
    }
}
