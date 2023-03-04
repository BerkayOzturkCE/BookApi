using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyApiTrain.DbOparations;

namespace MyApiTrain.Application.BookOparation.Commands.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel model{get;set;}
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        { 

            var book = _dbcontext.Books.SingleOrDefault(x => x.Title == model.Title);
            if (book is not null)
            {
                throw new InvalidOperationException("Kitap zaten mevcut");
            }
            book= _mapper.Map<Book>(model); //new Book();
           // book.Title=model.Title;
           // book.PublishDate=model.PublishDate;
           // book.PageCount=model.PageCount;
           // book.GenreId=model.GenreId;
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