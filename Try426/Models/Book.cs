using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Try426.Models
{
    public class Book
    {
        // Define the fields used for the database.
        public Int32 BookId { get; set; }

        public Int32 AuthorId { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage="Name is required for a book")]
        public String Name { get; set; }

        public String ISBN { get; set; }
        [Range(1, 1000)]
        public Int32 PageCount { get; set; }
        public DateTime LastRead { get; set; }

        public Author Author { get; set; }
    }
}