using NetcoreBeta.Data.Models;
using NetcoreBeta.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreBeta.Data.Services
{
    public class BooksService
    {
        private AppDBContext _context;
        public BooksService(AppDBContext context)
        {
            _context = context;
        }
        public void AddBookwithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded=DateTime.Now,
                PublisherId=book.PublisherId
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
            foreach(var id in book.AuthorsIds)
            {
                var _author_book = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id,
                };
                _context.Books_Authors.Add(_author_book);
                _context.SaveChanges();
            }
        }
        public List<Book> GetBooks() => _context.Books.ToList();
        public Book GetBookById(int bookId) => _context.Books.FirstOrDefault(x=>x.Id == bookId);
        public Book UpdateBook(int bookId,BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id == bookId);
            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;
                _context.SaveChanges();
            }
            return _book;
        }
        public void DeleteBook(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id == bookId);
            if(_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();

            }
        }
    }
    
}
