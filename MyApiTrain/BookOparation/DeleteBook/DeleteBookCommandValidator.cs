using FluentValidation;

namespace MyApiTrain.BookOparation.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator(){
            RuleFor(command=>command.BookId).GreaterThan(0);



        }
        
    }
}