using FluentValidation;

namespace MyApiTrain.Application.GenreOparation.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator(){
            RuleFor(command=>command.GenreId).GreaterThan(0);



        }
        
    }
}