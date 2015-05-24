using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Try426.Models
{
    public class BookDBInitializer : DropCreateDatabaseIfModelChanges<Try426BookContext>
   // public class BookDBInitializer : DropCreateDatabaseAlways<Try426BookContext>
    {
        protected override void Seed(Try426BookContext context)
        {
            context.Authors.Add(new Author {Name="John", Address="1 Glover road, Needham, MA", Age=40 });
            context.Authors.Add(new Author { Name = "Pete", Address = "100 Foster City Blvd, Foster City, CA", Age = 33 });
            context.Books.Add(new Book { Name = "Good Morning", ISBN = "1-234-443-322", LastRead = DateTime.Today, PageCount = 299, 
                Author = new Author { Name = "Smith", Address = "27 Main Street, Dallas, TX", Age = 46 } });

            base.Seed(context);
        }
    }
}