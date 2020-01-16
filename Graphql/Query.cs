using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WebApp.GraphqlSample.Database;
using GraphQL;

namespace WebApp.GraphqlSample.Graphql
{
    public class Query
    {

        [GraphQLMetadata("books")]
        public IEnumerable<Book> GetBooks()
        {
            using (var db = new StoreContext())
            {
                return db.Books
                .Include(b => b.Author)
                .ToList();
            }
        }

        [GraphQLMetadata("authors")]
        public IEnumerable<Author> GetAuthors()
        {
            using (var db = new StoreContext())
            {
                return db.Authors
                .Include(a => a.Books)
                .ToList();
            }
        }

        [GraphQLMetadata("author")]
        public Author GetAuthor(int id)
        {
            using (var db = new StoreContext())
            {
                return db.Authors
                .Include(a => a.Books)
                .SingleOrDefault(a => a.Id == id);
            }
        }

    }
}