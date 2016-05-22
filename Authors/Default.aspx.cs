using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Authors.Models;

namespace Authors
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var _db = new AuthorsContext();
            IQueryable<Author> qAuthors = _db.Authors;

            List<Author> authors = new List<Author>();

            foreach (var a in qAuthors)
            {
                authors.Add(a);
            }

            this.SubRepeater.DataSource = authors;
            this.SubRepeater.DataBind();
        }
    }
}