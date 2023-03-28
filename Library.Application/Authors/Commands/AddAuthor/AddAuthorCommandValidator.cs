using FluentValidation;


namespace Library.Application.Authors.Commands.AddAuthor
{
    public class AddAuthorCommandValidator: AbstractValidator<AddAuthorCommand>
    {
        AddAuthorCommandValidator()
        {
            RuleFor(addAuthorCommand => addAuthorCommand.FirstName)
                .NotEmpty().MaximumLength(30);
            RuleFor(addAuthorCommand => addAuthorCommand.LastName)
                .NotEmpty().MaximumLength(30);
            RuleFor(addAuthorCommand => addAuthorCommand.Country).NotEmpty();
        }
    }
}
