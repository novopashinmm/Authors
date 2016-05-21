using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Authors.Models
{
    public class Book
    {
        [ScaffoldColumn(false)]
        public int BookID { get; set; }
        [Required, StringLength(100), Display(Name = "BooksName")]
        public string Name { get; set; }
        public int? TotalPages { get; set; }
        public string Genre { get; set; }
        public virtual List<Author> Authors { get; set; } 
    }
}