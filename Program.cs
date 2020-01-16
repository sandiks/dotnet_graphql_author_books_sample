using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApp.GraphqlSample.Database;

namespace WebApp.GraphqlSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using(var db = new StoreContext()) 
            {
                var authorDbEntry = db.Authors.Add(
                    new Author
                    {
                        Name = "Stephen King",
                    }
                );

                db.SaveChanges();

                db.Books.AddRange(
                new Book
                {
                    Name = "IT",
                    Published = true,
                    AuthorId = authorDbEntry.Entity.Id,
                    Genre = "Mystery"
                },
                new Book
                {
                    Name = "The Langoleers",
                    Published = true,
                    AuthorId = authorDbEntry.Entity.Id,
                    Genre = "Mystery"
                }
                );

                db.SaveChanges();
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
