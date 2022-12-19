using Microsoft.AspNetCore.Mvc;
using MyApiTrain.DbOparations;

namespace MyApiTrain.BookOparation.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel model{get;set;}
        private readonly BookStoreDbContext _dbcontext;
        public CreateBookCommand(BookStoreDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void Handle()
        { 

            var book = _dbcontext.Books.SingleOrDefault(x => x.Title == model.Title);
            if (book is not null)
            {
                throw new InvalidOperationException("Kitap zaten mevcut");
            }
            book=new Book();
            book.Title=model.Title;
            book.PublishDate=model.PublishDate;
            book.PageCount=model.PageCount;
            book.GenreId=model.GenreId;
            _dbcontext.Books.Add(book);
            _dbcontext.SaveChanges();
        }


        public class CreateBookModel
        {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        }
    }


}