using Microsoft.AspNetCore.Mvc;
using MyApiTrain.DbOparations;

namespace MyApiTrain.BookOparation.GetBooks
{
    public class GetBookQuery
    {
        public int BookId { get; set; }

        private readonly BookStoreDbContext _dbcontext;
        public GetBookQuery(BookStoreDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public BookViewModel Handle()
        {

            var book = _dbcontext.Books.Where(book => book.id == BookId).SingleOrDefault();

            if (book is null)
            {
                throw new InvalidOperationException("Kitap Bulunamadı.");
            }

            BookViewModel vm = new BookViewModel()
            {
                Title = book.Title,
                PageCount = book.PageCount,
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
            };

            return vm;

        }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }

}