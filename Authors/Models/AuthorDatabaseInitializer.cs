using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Authors.Models
{
    public class AuthorDatabaseInitializer : DropCreateDatabaseIfModelChanges<AuthorContext>
    {
        protected override void Seed(AuthorContext context)
        {
            var books = new List<Book>
            {
                new Book() {Genre = "Programming", Name = "CLR via C#", TotalPages = 900},
                new Book() {Genre = "Programming", Name = "Asp.net 4.5", TotalPages = 900},
                new Book() {Genre = "Programming", Name = "Patterns of design", TotalPages = 900}
            };

            books.ForEach(p => context.Books.AddOrUpdate(p));
            context.SaveChanges();

        }
    }
}