using MediatR;

namespace Library.Application.Authors.Queries.GetAuthorList
{
    public class GetAuthorListQuery : IRequest<AuthorListVm>
    {
        public Guid Id { get; set; }
    }
}
