using EntityFramework.Tutorial.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityFramework.Tutorial.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");


            var optionBuilder = new DbContextOptionsBuilder<LibraryContext>();
            optionBuilder.UseSqlite($@"Data Source={AppDomain.CurrentDomain.BaseDirectory}\mydb.db");


            using (var context = new LibraryContext(optionBuilder.Options))
            {
                if ( context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Labraries.Any())
                {
                    var library = new LibraryEntity()
                    {
                        Name = "MyLibrary",
                        Location = "Munich"
                    };

                    context.Labraries.Add(library);

                    context.SaveChanges();

                    var author = new AuthorEntity()
                    {
                        Age = 30,
                        FirstName = "Someone",
                        LastName = "Nobody"

                    };

                    context.Autors.Add(author);

                    context.SaveChanges();

                    var book = new BookEntity()
                    {
                        Title = "Amazing",
                        Description = "It's pretty fency",
                        IsNew = true,
                        ReleaseDate = DateTime.Today.Subtract(new TimeSpan(3, 0, 0, 0, 0)),
                        Author = author,
                        Library = library
                    };

                    context.Books.Add(book);
                    context.SaveChanges();
                }


                var bookToModify = context.Books.Where(b => b.Title.StartsWith("Amaz")).ToList().FirstOrDefault();
                bookToModify.IsNew = false;
                bookToModify.Description = "Amazing Book Modified";

                context.SaveChanges();


                context.Books.Remove(bookToModify);
                context.SaveChanges();
            }
        }
    }
}
