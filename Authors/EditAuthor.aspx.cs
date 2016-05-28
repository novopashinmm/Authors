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

            var bookId = qAuthorBooks.Where(s=> s.AuthorID == author.AuthorID).Select(p => p.BookID);
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

            var newAuthor = new Author
            {
                FirstName = FirstName.Text,
                MiddleName = MiddleName.Text,
                LastName = LastName.Text
            };

            int newAuthorID;
            var author = _db.Authors.Select(s =>
                    s).First(p => p.FirstName == newAuthor.FirstName && p.LastName == newAuthor.LastName &&
                    p.MiddleName == newAuthor.MiddleName);
            if (author != null)
            {
                newAuthorID = author.AuthorID;
            }
            else
            {
                _db.Authors.AddOrUpdate(newAuthor);
                _db.SaveChanges();
                newAuthorID = _db.Authors.Select(s =>
                    s).First(p => p.FirstName == newAuthor.FirstName && p.LastName == newAuthor.LastName &&
                                  p.MiddleName == newAuthor.MiddleName).AuthorID;
            }

            

            bool endCycle = false;
            int i = 1;
            while (!endCycle)
            {
                var ctrlBookName = Page.Request.Form["BookName" + i].ToString();
                var ctrlGenre = Page.Request.Form["Genre" + i].ToString();
                var ctrlPages = Page.Request.Form["TotalPages" + i].ToString();
                var newBook = new Book
                {
                    Name = ctrlBookName,
                    Genre = ctrlGenre,
                    TotalPages = int.Parse(ctrlPages)
                };
                _db.Books.AddOrUpdate(newBook);
                _db.SaveChanges();

                var newAuthBook = new AuthorBook()
                {
                    AuthorID = newAuthorID,
                    BookID = newBook.BookID
                };

                _db.AuthorBooks.AddOrUpdate(newAuthBook);
                _db.SaveChanges();

                if (ctrlBookName == null && ctrlGenre == null && ctrlPages == null)
                    endCycle = true;
                i++;
            }
        }
    }
}