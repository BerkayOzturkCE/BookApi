    using Microsoft.AspNetCore.Mvc;
using MyApiTrain.DbOparations;

namespace MyApiTrain.BookOparation.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbcontext=dbContext;
        }

        public List<BooksViewModel> Handle(){

            var booksList=_dbcontext.Books.OrderBy(x=>x.id).ToList();
            List<BooksViewModel> vm=new List<BooksViewModel>();
            foreach (var book in booksList)
            {
                vm.Add(
                    new BooksViewModel(){
                        Title=book.Title,
                        PageCount=book.PageCount,
                        Genre=((GenreEnum)book.GenreId).ToString(),
                        PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy"),
                    }
                ); 
            }
                        return vm;

        }
    }

    public class BooksViewModel
    {
        public string Title {get;set;}
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }

}