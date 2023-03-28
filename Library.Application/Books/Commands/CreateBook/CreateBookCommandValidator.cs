using FluentValidation;

namespace Library.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandValidator: AbstractValidator<CreateBookCommand>
    {
        CreateBookCommandValidator()
        {
            RuleFor(createBookCommand => createBookCommand.Title)
                    .NotEmpty().MaximumLength(250);
        }
        
    }
}
