using FluentValidation;

namespace MyApiTrain.Application.BookOparation.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator(){
            RuleFor(command=>command.id).GreaterThan(0);
            RuleFor(command=>command.UpdatedBook.GenreId).GreaterThan(0);
            RuleFor(command=>command.UpdatedBook.PageCount).GreaterThan(0);
            RuleFor(command=>command.UpdatedBook.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command=>command.UpdatedBook.Title).NotEmpty().MinimumLength(4);


        }
        
    }
}