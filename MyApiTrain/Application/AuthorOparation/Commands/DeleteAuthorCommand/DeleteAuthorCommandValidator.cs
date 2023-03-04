using FluentValidation;

namespace MyApiTrain.Application.AuthorOparation.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator(){
            RuleFor(command=>command.AuthorId).GreaterThan(0);



        }
        
    }
}