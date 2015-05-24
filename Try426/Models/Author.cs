using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Try426.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string Address { get; set; }
        public List<Book> Books { get; set; }
    }
}