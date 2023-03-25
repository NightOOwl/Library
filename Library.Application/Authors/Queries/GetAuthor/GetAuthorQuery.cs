using MediatR;


namespace Library.Application.Authors.Queries.GetAuthor
{
    public class GetAuthorQuery: IRequest <AuthorVm>
    {
        public Guid Id { get; set; }
    }
}
