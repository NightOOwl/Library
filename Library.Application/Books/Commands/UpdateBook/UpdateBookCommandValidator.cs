using FluentValidation;

namespace Library.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandValidator: AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(updateBookCommand => updateBookCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateBookCommand => updateBookCommand.Title)
                .NotEmpty().MaximumLength(250);
        }
    }
}
