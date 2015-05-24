using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Try426.Models
{
    public class Try426BookContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Try426BookContext() : base("name=Try426BookContext")
        {
        }

        public System.Data.Entity.DbSet<Try426.Models.Book> Books { get; set; }

        public System.Data.Entity.DbSet<Try426.Models.Author> Authors { get; set; }
    
    }
}
