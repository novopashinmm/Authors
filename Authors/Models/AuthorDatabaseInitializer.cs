using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Authors.Models
{
    public class AuthorDatabaseInitializer : DropCreateDatabaseAlways<AuthorsContext>
    {
        protected override void Seed(AuthorsContext context)
        {
            var books = new List<Book>
            {
                new Book() {Genre = "Programming", Name = "CLR via C#", TotalPages = 900},
                new Book() {Genre = "Programming", Name = "Asp.net 4.5", TotalPages = 900},
                new Book() {Genre = "Programming", Name = "Patterns of design", TotalPages = 900},
                new Book() {Genre = "Programming", Name = "New book", TotalPages = 900}
            };

            books.ForEach(p => context.Books.AddOrUpdate(p));

            var authors = new List<Author>
            {
                new Author()
                {
                    Birthday = new DateTime(1950, 5, 22),
                    FirstName = "Adam",
                    LastName = "Freeman",
                    MiddleName = "sdf"
                },
                new Author()
                {
                    Birthday = new DateTime(1950, 5, 22),
                    FirstName = "Jeffry",
                    LastName = "Richter",
                    MiddleName = "sdf"
                },
                new Author()
                {
                    Birthday = new DateTime(1950, 5, 22),
                    FirstName = "Erich",
                    LastName = "Gamma",
                    MiddleName = "sdf"
                },
                new Author()
                {
                    Birthday = new DateTime(1950, 5, 22),
                    FirstName = "Richard",
                    LastName = "Helm",
                    MiddleName = "sdf"
                },
                new Author()
                {
                    Birthday = new DateTime(1950, 5, 22),
                    FirstName = "Ralf",
                    LastName = "Jonson",
                    MiddleName = "sdf"
                },
                new Author()
                {
                    Birthday = new DateTime(1950, 5, 22),
                    FirstName = "John",
                    LastName = "Vlissidis",
                    MiddleName = "sdf"
                }
            };

            authors.ForEach(p => context.Authors.AddOrUpdate(p));
            context.SaveChanges();

            var authorBooks = new List<AuthorBook>()
            {
                new AuthorBook
                {
                    AuthorID = authors.Single(a => a.LastName == "Richter").AuthorID,
                    BookID = books.Single(b => b.Name == "CLR via C#").BookID
                },
                new AuthorBook
                {
                    AuthorID = authors.Single(a => a.LastName == "Freeman").AuthorID,
                    BookID = books.Single(b => b.Name == "Asp.net 4.5").BookID
                },
                new AuthorBook
                {
                    AuthorID = authors.Single(a => a.LastName == "Gamma").AuthorID,
                    BookID = books.Single(b => b.Name == "Patterns of design").BookID
                },
                new AuthorBook
                {
                    AuthorID = authors.Single(a => a.LastName == "Helm").AuthorID,
                    BookID = books.Single(b => b.Name == "Patterns of design").BookID
                },
                new AuthorBook
                {
                    AuthorID = authors.Single(a => a.LastName == "Jonson").AuthorID,
                    BookID = books.Single(b => b.Name == "Patterns of design").BookID
                },
                new AuthorBook
                {
                    AuthorID = authors.Single(a => a.LastName == "Vlissidis").AuthorID,
                    BookID = books.Single(b => b.Name == "Patterns of design").BookID
                }
            };

            authorBooks.ForEach(p => context.AuthorBooks.AddOrUpdate(p));
            context.SaveChanges();
        }
    }
}