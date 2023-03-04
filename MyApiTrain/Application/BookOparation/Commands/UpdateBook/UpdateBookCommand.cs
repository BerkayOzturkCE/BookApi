using MyApiTrain.DbOparations;

namespace MyApiTrain.Application.BookOparation.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdatedBookModel UpdatedBook{get;set;}
                public int id{get;set;}

        private readonly BookStoreDbContext _dbcontext;
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void Handle()
        { 

            var book = _dbcontext.Books.SingleOrDefault(x => x.id == id);
            if (book is null)
            {
                throw new InvalidOperationException("Kitap Bulunamadı.");
            }
           book.Title = UpdatedBook.Title != default ? UpdatedBook.Title : book.Title;
            book.GenreId = UpdatedBook.GenreId != default ? UpdatedBook.GenreId : book.GenreId;
            book.PageCount = UpdatedBook.PageCount != default ? UpdatedBook.PageCount : book.PageCount;
            book.PublishDate = UpdatedBook.PublishDate != default ? UpdatedBook.PublishDate : book.PublishDate;
            _dbcontext.SaveChanges();
        }


        public class UpdatedBookModel
        {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        }
    }


}