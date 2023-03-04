using Microsoft.AspNetCore.Mvc;
using MyApiTrain.DbOparations;
using AutoMapper;
using FluentValidation;
using MyApiTrain.Application.GenreOparation.Queries.GetGenres;
using MyApiTrain.Application.GenreOparation.Queries.GetGenreById;
using MyApiTrain.Application.GenreOparation.Commands.CreateGenre;
using static MyApiTrain.Application.GenreOparation.Commands.CreateGenre.CreateGenreCommand;
using static MyApiTrain.Application.GenreOparation.Commands.UpdateGenre.UpdateGenreCommand;
using MyApiTrain.Application.GenreOparation.Commands.UpdateGenre;
using MyApiTrain.Application.GenreOparation.Commands.DeleteGenre;

namespace MyApiTrain.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenresController : ControllerBase
    {


        private readonly ILogger<BooksController> _logger;
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;


        public GenresController( BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenresQuery()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreByIdQuery(int id)
        {
            GetGenreByIdQuery query = new GetGenreByIdQuery(_context, _mapper);
            query.GenreId = id;
            GetGenreByIdQueryValidator validator = new GetGenreByIdQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);


        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.model = newGenre;
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdatedGenreModel updatedGenre)
        {

               UpdateGenreCommand command = new UpdateGenreCommand(_context);
               command.GenreId = id;
               command.UpdatedGenre = updatedGenre;
               UpdateGenreCommandValidator validator=new UpdateGenreCommandValidator();
               validator.ValidateAndThrow(command);
               command.Handle();
            return Ok();


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {

             DeleteGenreCommand command = new DeleteGenreCommand(_context);
             command.GenreId = id;
             DeleteGenreCommandValidator validator=new DeleteGenreCommandValidator();
             validator.ValidateAndThrow(command);
             command.Handle();
            return Ok();

        }


    }
}