using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
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

            _db.Authors.AddOrUpdate(newAuthor);

            bool endCycle = false;
            while (!endCycle)
            {
                int i = 0;
                var ctrlBookName = (Label)this.FindControl("BookName" + i);
                var ctrlGenre = (Label)this.FindControl("Genre" + i);
                var ctrlPages = (Label)this.FindControl("Pages" + i);
                var newBook = new Book
                {
                    Name = ctrlBookName.Text,
                    Genre = ctrlGenre.Text,
                    TotalPages = int.Parse(ctrlPages.Text)
                };
                _db.Books.AddOrUpdate(newBook);

                var newAuthBook = new AuthorBook()
                {
                    AuthorID = newAuthor.AuthorID,
                    BookID = newBook.BookID
                };

                _db.AuthorBooks.AddOrUpdate(newAuthBook);

                if (ctrlBookName == null && ctrlGenre == null && ctrlPages == null)
                    endCycle = true;
                i++;
            }
        }
    }
}