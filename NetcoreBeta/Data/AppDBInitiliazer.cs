using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NetcoreBeta.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreBeta.Data
{
    public class AppDBInitiliazer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDBContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "1st book",
                        Description = "1st boo, descroption",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 5,
                        Genre = "history",
                        CoverUrl = "https://",
                        DateAdded = DateTime.Now

                    },
                    new Book()
                    {
                        Title = "1st book",
                        Description = "1st boo, descroption",
                        IsRead = false,
                        Genre = "history",
                        CoverUrl = "https://",
                        DateAdded = DateTime.Now
                    }

                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
