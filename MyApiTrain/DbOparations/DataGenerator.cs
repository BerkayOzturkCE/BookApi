using Microsoft.EntityFrameworkCore;

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
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        // id = 2,
                        Title = "Herland",
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 05, 23)
                    },
                    new Book
                    {
                        // id = 3,
                        Title = "Dune",
                        GenreId = 2,
                        PageCount = 540,
                        PublishDate = new DateTime(2001, 12, 21)
                    },
                    new Book
                    {
                        // id = 4,
                        Title = "Harry Potter Chamber of Secrets",
                        GenreId = 3,
                        PageCount = 540,
                        PublishDate = new DateTime(2002, 10, 31)
                    }
);
                context.SaveChanges();
            }
        }
    }
}