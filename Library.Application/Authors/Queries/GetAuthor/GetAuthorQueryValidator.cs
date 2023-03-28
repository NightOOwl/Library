using FluentValidation;


namespace Library.Application.Authors.Queries.GetAuthor
{
    public class GetAuthorQueryValidator : AbstractValidator<GetAuthorQuery>
    {
        GetAuthorQueryValidator()
        {
            RuleFor(authot => authot.Id).NotEqual(Guid.Empty);
        }

    }
}
