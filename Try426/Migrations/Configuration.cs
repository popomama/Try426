namespace Try426.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Try426.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Try426.Models.Try426BookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Try426.Models.Try426BookContext";
        }

        protected override void Seed(Try426.Models.Try426BookContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            context.Authors.AddOrUpdate(a=>a.Name, new Author { Name = "John", Address = "1 Glover road, Needham, MA", Age = 40 });
            context.Authors.AddOrUpdate(a => a.Name, new Author { Name = "Jin", Address = "1 Microsoft Way, Redmond, WA", Age = 53 });
            context.Authors.AddOrUpdate(a => a.Name, new Author { Name = "Smith", Address = "937 Main Street, New YOrk, NY", Age = 64 });
            context.Authors.AddOrUpdate(a => a.Name, new Author { Name = "Xian", Address = "99 Main street, Foster City, CA", Age = 73 });
            //context.Books.AddOrUpdate(b => b.Name, new Book
            //{
            //    Name = "Good Morning",
            //    ISBN = "1-234-443-322",
            //    LastRead = DateTime.Today,
            //    PageCount = 299,
            //    Author = new Author { Name = "Smith3", Address = "27 Main Street, Dallas, TX", Age = 46 }
            //});

            ////add a bunch of books.
            for (int i = 0; i < 500; i++)
            {
                Random r = new Random();
                context.Books.AddOrUpdate(
                            b => b.Name,
                            new Book
                            {

                                Name = "Good Morning" + i,
                                ISBN = "1-234-443-322" + "-" + r.Next(20),
                                LastRead = DateTime.Now.AddDays(-r.Next(100)).AddMinutes(r.Next(59)),
                                PageCount = 99 + r.Next(1, 400) ,
                                AuthorId = r.Next(1, 8)
                            }
               );
            }
        }
    }
}
