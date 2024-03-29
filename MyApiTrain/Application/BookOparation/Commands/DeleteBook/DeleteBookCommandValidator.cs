using FluentValidation;

namespace MyApiTrain.Application.BookOparation.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator(){
            RuleFor(command=>command.BookId).GreaterThan(0);
        }
        
    }
}