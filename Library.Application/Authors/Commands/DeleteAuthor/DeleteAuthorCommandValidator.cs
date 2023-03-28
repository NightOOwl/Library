using FluentValidation;


namespace Library.Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidator: AbstractValidator<DeleteAuthorCommand>
    {
        DeleteAuthorCommandValidator()
        {
            RuleFor(deleteAuthorCommand => deleteAuthorCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
