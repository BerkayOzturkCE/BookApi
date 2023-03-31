using Microsoft.EntityFrameworkCore;
using MyApiTrain.Entities;

namespace MyApiTrain.DbOparations
{

    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(
                    new Book
                    {
                        // id = 1,
                        Title = "Lean Startup",
                        GenreId = 1,
                        AuthorId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        // id = 2,
                        Title = "Herland",
                        GenreId = 2,
                        AuthorId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 05, 23)
                    },
                    new Book
                    {
                        // id = 3,
                        Title = "Dune",
                        GenreId = 2,
                        AuthorId = 3,
                        PageCount = 540,
                        PublishDate = new DateTime(2001, 12, 21)
                    },
                    new Book
                    {
                        // id = 4,
                        Title = "Deneme",
                        GenreId = 3,
                        AuthorId = 4,
                        PageCount = 540,
                        PublishDate = new DateTime(1805, 10, 31)
                    }

                );
                context.Genres.AddRange(
                  new Genre
                  {
                      Name = "PersonalGrowth",
                  },
                    new Genre
                    {
                        Name = "ScienceFiction",
                    },
                    new Genre
                    {
                        Name = "Genre1",
                    },
                    new Genre
                    {
                        Name = "Noval",
                    },
                    new Genre
                    {
                        Name = "Historia",
                    }

                                    );


                context.Authors.AddRange(

                    new Author
                    {
                        Name = "George",
                        Surname = "Orwell",
                        Birthday = new DateTime(1903, 06, 25),
                    },
                       new Author
                       {
                           Name = "William",
                           Surname = "Shakespeare",
                           Birthday = new DateTime(1564, 04, 19),
                       },
                       new Author
                       {
                           Name = "Andy",
                           Surname = "Weir",
                           Birthday = new DateTime(1972, 06, 16),
                       },
                       new Author
                       {
                           Name = "Douglas",
                           Surname = "Adams",
                           Birthday = new DateTime(1952, 03, 11),
                       }

                );
                context.SaveChanges();
            }
        }
    }
}
