using Microsoft.AspNetCore.Mvc;
using MyApiTrain.DbOparations;

namespace MyApiTrain.BookOparation.DeleteBook
{
    public class DeleteBookCommand
    {
        public int BookId { get; set; }

        private readonly BookStoreDbContext _dbcontext;
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void Handle()
        {

            var book = _dbcontext.Books.Where(book => book.id == BookId).SingleOrDefault();

            if (book is null)
            {
                throw new InvalidOperationException("Kitap Bulunamadı.");
            }

              _dbcontext.Books.Remove(book);
            _dbcontext.SaveChanges();
            return;


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