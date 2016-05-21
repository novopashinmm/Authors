using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Authors.Models
{
    public class Author
    {
        [ScaffoldColumn(false)]
        public int AuthorID { get; set; }
        [Required, StringLength(100), Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Required, StringLength(100), Display(Name = "MiddleName")]
        public string MiddleName { get; set; }
        [Required, StringLength(100), Display(Name = "LastName")]
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public virtual ICollection<Book> Books { get; set; } 
    }
}