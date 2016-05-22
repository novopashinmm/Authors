using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Authors.Models
{
    public class AuthorsContext : DbContext
    {
        public AuthorsContext() : base("Authors") { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
    }
}