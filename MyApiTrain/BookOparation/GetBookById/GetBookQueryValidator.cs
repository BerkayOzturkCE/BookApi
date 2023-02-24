using FluentValidation;

namespace MyApiTrain.BookOparation.GetBookById
{
    public class GetBookByIdCommandValidator : AbstractValidator<GetBookQuery>
    {
        public GetBookByIdCommandValidator(){
            RuleFor(command=>command.BookId).GreaterThan(0);



        }
        
    }
}