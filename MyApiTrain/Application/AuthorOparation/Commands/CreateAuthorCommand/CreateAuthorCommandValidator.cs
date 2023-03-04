using FluentValidation;

namespace MyApiTrain.Application.AuthorOparation.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator(){

            RuleFor(command=>command.model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command=>command.model.Surname).NotEmpty().MinimumLength(3);
            RuleFor(command=>command.model.Birthday).NotEmpty().LessThan(DateTime.Now.AddYears(-18));

        }
        
    }
}