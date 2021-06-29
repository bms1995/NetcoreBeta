using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreBeta.Data.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }
    public class AuthorVMWithBooks
    {
        public string FullName { get; set; }
        public List<string> BooksTitle { get; set; }
    }
}
