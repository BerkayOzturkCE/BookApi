using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MyApiTrain.DbOparations;

using FluentValidation;
using MyApiTrain.Application.BookOparation.Queries.GetBooks;
using MyApiTrain.Application.BookOparation.Queries.GetBookById;
using MyApiTrain.Application.BookOparation.Commands.CreateBook;
using static MyApiTrain.Application.BookOparation.Commands.CreateBook.CreateBookCommand;
using MyApiTrain.Application.BookOparation.Commands.UpdateBook;
using MyApiTrain.Application.BookOparation.Commands.DeleteBook;
using static MyApiTrain.Application.BookOparation.Commands.UpdateBook.UpdateBookCommand;

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
        private readonly IMapper _mapper;


        public BooksController(ILogger<BooksController> logger, BookStoreDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;


        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBooksById(int id)
        {
            GetBookQuery query = new GetBookQuery(_context, _mapper);
          
                query.BookId = id;
                    GetBookByIdCommandValidator validator=new GetBookByIdCommandValidator();
                validator.ValidateAndThrow(query);
                var result = query.Handle();
                return Ok(result);
         

        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);

                command.model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();

                return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdatedBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);

           
                command.id = id;
                command.UpdatedBook = updatedBook;
                UpdateBookCommandValidator validator=new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();

           
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                DeleteBookCommandValidator validator=new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
           
        }


    }
}