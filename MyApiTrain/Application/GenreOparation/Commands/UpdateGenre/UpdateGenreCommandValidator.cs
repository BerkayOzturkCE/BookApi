using FluentValidation;

namespace MyApiTrain.Application.GenreOparation.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator(){
            RuleFor(command=>command.GenreId).GreaterThan(0);
            RuleFor(command=>command.UpdatedGenre.Name).NotEmpty().MinimumLength(4);



        }
        
    }
}