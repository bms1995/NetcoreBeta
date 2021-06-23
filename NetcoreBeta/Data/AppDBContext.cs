using Microsoft.EntityFrameworkCore;
using NetcoreBeta.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreBeta.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {

        }
        public DbSet<Book> Books { set; get; }
    }
}
