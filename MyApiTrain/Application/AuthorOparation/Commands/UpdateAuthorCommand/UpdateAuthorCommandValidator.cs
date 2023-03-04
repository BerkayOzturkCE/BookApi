using FluentValidation;

namespace MyApiTrain.Application.AuthorOparation.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator(){
            RuleFor(command=>command.UpdatedAuthor.Name).NotEmpty().MinimumLength(3);
            RuleFor(command=>command.UpdatedAuthor.Surname).NotEmpty().MinimumLength(3);
            RuleFor(command=>command.UpdatedAuthor.Birthday).NotEmpty().LessThan(DateTime.Now.AddYears(-18));
        }
        
    }
}