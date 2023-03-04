using FluentValidation;

namespace MyApiTrain.Application.AuthorOparation.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryValidator : AbstractValidator<GetAuthorByIdQuery>
    {
        public GetAuthorByIdQueryValidator(){
            RuleFor(command=>command.AuthorId).GreaterThan(0);



        }
        
    }
}