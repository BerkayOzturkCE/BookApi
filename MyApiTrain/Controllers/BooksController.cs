using Microsoft.AspNetCore.Mvc;
using MyApiTrain.BookOparation.CreateBook;
using MyApiTrain.BookOparation.DeleteBook;
using MyApiTrain.BookOparation.GetBooks;
using MyApiTrain.DbOparations;
using static MyApiTrain.BookOparation.CreateBook.CreateBookCommand;
using static MyApiTrain.BookOparation.CreateBook.UpdateBookCommand;

namespace MyApiTrain.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {

        /* private static List<Book> BookList = new List<Book>(){
             new Book{
                 id=1,
                 Title="Lean Startup",
                 GenreId=1,
                 PageCount=200,
                 PublishDate=new DateTime(2001,06,12)
             },
             new Book{
                 id=2,
                 Title="Herland",
                 GenreId=2,
                 PageCount=250,
                 PublishDate=new DateTime(2010,05,23)
             },
                  new Book{
                 id=3,
                 Title="Dune",
                 GenreId=2,
                 PageCount=540,
                 PublishDate=new DateTime(2001,12,21)
             },

         };*/


        private readonly ILogger<BooksController> _logger;
        private readonly BookStoreDbContext _context;


        public BooksController(ILogger<BooksController> logger, BookStoreDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBooksById(int id)
        {
            GetBookQuery query = new GetBookQuery(_context);
            try
            {
                query.BookId = id;
                var result = query.Handle();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);

            try
            {
                command.model = newBook;
                command.Handle();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdatedBookModel updatedBook)
        {
                        UpdateBookCommand command = new UpdateBookCommand(_context);

           try
           {
            command.id=id;
            command.UpdatedBook=updatedBook;
            command.Handle();
                        return Ok();

           }
           catch (Exception ex)
           {

                return BadRequest(ex.Message);
            
           }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command=new DeleteBookCommand(_context);
                command.BookId=id;
                command.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                
               return BadRequest(ex.Message);
                
            }
        }


    }
}