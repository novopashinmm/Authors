using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Authors.Models
{
    public class AuthorBook
    {
        [ScaffoldColumn(false)]
        public int AuthorBookID { get; set; }
        public int AuthorID { get; set; }
        public int BookID { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}