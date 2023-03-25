using MediatR;

namespace Library.Application.Books.Queries.GetBookList
{
    public class GetBookListQuery : IRequest<BookListVm>
    {
        public Guid Id { get; set; }
    }
}
