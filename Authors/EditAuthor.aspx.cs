using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.UI;
using Authors.Models;

namespace Authors
{
    public partial class EditAuthor : Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            var authId = Request["AuthId"];
            if (authId == null)
            {
                return;
            }
            FirstName.Text = authId;

            int intAuthId;
            int.TryParse(authId, out intAuthId);

            var db = new AuthorsContext();
            IList<Author> qAuthors = db.Authors.Select(p => p).ToList();
            IList<Book> qBooks = db.Books.Select(p => p).ToList();
            IList<AuthorBook> qAuthorBooks = db.AuthorBooks.Select(p => p).ToList();

            var author = qAuthors.Single(p => p.AuthorID == intAuthId);
            FirstName.Text = author.FirstName;
            MiddleName.Text = author.MiddleName;
            LastName.Text = author.LastName;
            AuthorID.Text = author.AuthorID.ToString();

            var bookId = qAuthorBooks.Where(s => s.AuthorID == author.AuthorID).Select(p => p.BookID);
            var listBooks = bookId.Select(id => qBooks.Single(p => p.BookID == id)).ToList();

            this.SubRepeater.DataSource = listBooks;
            this.SubRepeater.DataBind();
        }

        protected void Save_OnClick(object sender, EventArgs e)
        {
            var db = new AuthorsContext();

            int newAuthorID;
            var authors = db.Authors.Select(s =>
                    s).ToList();
            var author = authors.FirstOrDefault(p => p.FirstName == FirstName.Text && p.LastName == LastName.Text &&
                    p.MiddleName == MiddleName.Text);
            if (author != null)
            {
                newAuthorID = author.AuthorID;
            }
            else
            {
                author = new Author
                {
                    FirstName = FirstName.Text,
                    LastName = LastName.Text,
                    MiddleName = MiddleName.Text,
                    Birthday = new DateTime(1950, 5, 5)
                };
                db.Authors.AddOrUpdate(author);
                db.SaveChanges();
                newAuthorID = db.Authors.Select(s =>
                    s).First(p => p.FirstName == author.FirstName && p.LastName == author.LastName &&
                                  p.MiddleName == author.MiddleName).AuthorID;
            }


            int i = 0;
            for(;;)
            {
                i++;
                var ctrlBookName = Page.Request.Form["BookName" + i];
                var ctrlGenre = Page.Request.Form["Genre" + i];
                int ctrlPages;
                int.TryParse((Page.Request.Form["TotalPages" + i]), out ctrlPages);

                if (ctrlBookName == null &&
                    ctrlGenre == null &&
                    ctrlPages == 0)
                {
                    Response.Redirect("Default.aspx");
                    return;
                }

                int newBookID;
                var books = db.Books.Select(s =>
                    s).ToList();
                var book = books.FirstOrDefault(p => p.Name == ctrlBookName && p.Genre == ctrlGenre && p.TotalPages == ctrlPages);
                if (book != null)
                {
                    newBookID = book.BookID;
                }
                else
                {
                    book = new Book
                    {
                        Name = ctrlBookName,
                        Genre = ctrlGenre,
                        TotalPages = ctrlPages
                    };
                    db.Books.AddOrUpdate(book);
                    db.SaveChanges();
                    newBookID =
                        db.Books.Select(s => s)
                            .First(
                                p =>
                                    p.Name == ctrlBookName && p.Genre == ctrlGenre &&
                                    p.TotalPages == ctrlPages)
                            .BookID;
                }

                var newAuthBooks = db.AuthorBooks.Select(s =>
                    s).ToList();
                var newAuthBook = newAuthBooks.FirstOrDefault(p => p.AuthorID == newAuthorID && p.BookID == newBookID);
                if (newAuthBook == null)
                {
                    newAuthBook = new AuthorBook
                    {
                        AuthorID = author.AuthorID,
                        BookID = book.BookID
                    };
                    db.AuthorBooks.AddOrUpdate(newAuthBook);
                    db.SaveChanges();
                }
            }

        }
    }
}