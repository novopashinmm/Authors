using System;
using System.Collections.Generic;
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

            var bookId = qAuthorBooks.Where(s=> s.AuthorID == author.AuthorID).Select(p => p.BookID);
            var listBooks = bookId.Select(id => qBooks.Single(p => p.BookID == id)).ToList();

            this.SubRepeater.DataSource = listBooks;
            this.SubRepeater.DataBind();
        }
    }
}