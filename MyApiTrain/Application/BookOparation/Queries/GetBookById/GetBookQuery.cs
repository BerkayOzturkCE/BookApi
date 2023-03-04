using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApiTrain.DbOparations;

namespace MyApiTrain.Application.BookOparation.Queries.GetBookById
{
    public class GetBookQuery
    {
        public int BookId { get; set; }

        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetBookQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public BookViewModel Handle()
        {

            var book = _dbcontext.Books.Include(x=>x.Genre).Include(y=>y.Author).Where(book => book.id == BookId).SingleOrDefault();

            if (book is null)
            {
                throw new InvalidOperationException("Kitap Bulunamadı.");
            }

            BookViewModel vm =_mapper.Map<BookViewModel>(book);  //new BookViewModel()
           // {
           //     Title = book.Title,
           //     PageCount = book.PageCount,
           //     Genre = ((GenreEnum)book.GenreId).ToString(),
           //     PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
           // };

            return vm;

        }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }

    }

}