using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Authors.Models
{
    public class AuthorContext : DbContext
    {
        public AuthorContext() : base("Authors") { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; } 
    }
}