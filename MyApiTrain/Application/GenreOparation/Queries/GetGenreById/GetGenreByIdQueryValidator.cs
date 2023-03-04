using FluentValidation;

namespace MyApiTrain.Application.GenreOparation.Queries.GetGenreById
{
    public class GetGenreByIdQueryValidator : AbstractValidator<GetGenreByIdQuery>
    {
        public GetGenreByIdQueryValidator(){
            RuleFor(command=>command.GenreId).GreaterThan(0);



        }
        
    }
}