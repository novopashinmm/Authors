using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Authors.Models;

namespace Authors
{
    public partial class EditAuthor : System.Web.UI.Page
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

            var _db = new AuthorsContext();
            IList<Author> qAuthors = _db.Authors.Select(p => p).ToList();
            IList<Book> qBooks = _db.Books.Select(p => p).ToList();
            IList<AuthorBook> qAuthorBooks = _db.AuthorBooks.Select(p => p).ToList();

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
            var _db = new AuthorsContext();
            IList<Author> qAuthors = _db.Authors.Select(p => p).ToList();
            IList<Book> qBooks = _db.Books.Select(p => p).ToList();
            IList<AuthorBook> qAuthorBooks = _db.AuthorBooks.Select(p => p).ToList();

            int newAuthorID;
            var authors = _db.Authors.Select(s =>
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
                _db.Authors.AddOrUpdate(author);
                _db.SaveChanges();
                newAuthorID = _db.Authors.Select(s =>
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
                var ctrlPagesReq = int.TryParse((Page.Request.Form["TotalPages" + i]), out ctrlPages);

                if (ctrlBookName == null &&
                    ctrlGenre == null &&
                    ctrlPages == 0)
                {
                    Response.Redirect("Default.aspx");
                    return;
                }

                int newBookID;
                var books = _db.Books.Select(s =>
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
                    _db.Books.AddOrUpdate(book);
                    _db.SaveChanges();
                    newBookID =
                        _db.Books.Select(s => s)
                            .First(
                                p =>
                                    p.Name == ctrlBookName && p.Genre == ctrlGenre &&
                                    p.TotalPages == ctrlPages)
                            .BookID;
                }

                var newAuthBooks = _db.AuthorBooks.Select(s =>
                    s).ToList();
                var newAuthBook = newAuthBooks.FirstOrDefault(p => p.AuthorID == newAuthorID && p.BookID == newBookID);
                if (newAuthBook == null)
                {
                    newAuthBook = new AuthorBook
                    {
                        AuthorID = author.AuthorID,
                        BookID = book.BookID
                    };
                    _db.AuthorBooks.AddOrUpdate(newAuthBook);
                    _db.SaveChanges();
                }
            }

        }
    }
}