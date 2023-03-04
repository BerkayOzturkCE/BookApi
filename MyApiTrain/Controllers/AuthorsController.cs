

using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MyApiTrain.Application.AuthorOparation.Commands.CreateAuthor;
using MyApiTrain.Application.AuthorOparation.Commands.DeleteAuthor;
using MyApiTrain.Application.AuthorOparation.Commands.UpdateAuthor;
using MyApiTrain.Application.AuthorOparation.Queries.GetAuthorById;
using MyApiTrain.Application.AuthorOparation.Queries.GetAuthors;
using MyApiTrain.DbOparations;
using static MyApiTrain.Application.AuthorOparation.Commands.CreateAuthor.CreateAuthorCommand;
using static MyApiTrain.Application.AuthorOparation.Commands.UpdateAuthor.UpdateAuthorCommand;
using static MyApiTrain.Application.GenreOparation.Commands.CreateGenre.CreateGenreCommand;
using static MyApiTrain.Application.GenreOparation.Commands.UpdateGenre.UpdateGenreCommand;

namespace MyApiTrain.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {


        private readonly ILogger<BooksController> _logger;
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;


        public AuthorController( BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthorsQuery()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorByIdQuery(int id)
        {
            GetAuthorByIdQuery query = new GetAuthorByIdQuery(_context, _mapper);
            query.AuthorId = id;
            GetAuthorByIdQueryValidator validator = new GetAuthorByIdQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);


        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.model = newAuthor;
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdatedAuthorModel UpdatedAuthor)
        {

            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorId = id;
            command.UpdatedAuthor = UpdatedAuthor;
            UpdateAuthorCommandValidator validator=new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {

            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;
            DeleteAuthorCommandValidator validator=new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }


    }
}