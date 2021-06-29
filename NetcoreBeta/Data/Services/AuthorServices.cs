using NetcoreBeta.Data.Models;
using NetcoreBeta.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreBeta.Data.Services
{
    public class AuthorServices
    {
        private AppDBContext _context;
        public AuthorServices(AppDBContext context)
        {
            _context = context;
        }
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName,

            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorVMWithBooks GetAuthorWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(x => x.Id == authorId).Select(n => new AuthorVMWithBooks()
            {
                FullName = n.FullName,
                BooksTitle = n.Book_Authors.Select(x => x.Book.Title).ToList(),
            }).FirstOrDefault();
            return _author;
        }
    }
}
