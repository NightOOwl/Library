

using FluentValidation;
using Library.Application.Books.Queries.GetBooks;

namespace Library.Application.Books.Queries.GetBook
{
    public class GetBookQueryValidator: AbstractValidator<GetBookQuery>
    {
        GetBookQueryValidator()
        {
            RuleFor(book => book.Id).NotEqual(Guid.Empty);
        }
        
    }
}
