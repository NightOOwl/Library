using AutoMapper;
using Lib.Domain;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Authors.Queries.GetAuthor
{
    public class GetAuthorQueryHandler
        : IRequestHandler<GetAuthorQuery, AuthorVm>
    {
        private readonly IAuthorDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorQueryHandler(IAuthorDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<AuthorVm> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Authors
                   .FirstOrDefaultAsync(author =>
                   author.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }
            return _mapper.Map<AuthorVm>(entity);
        }
    }
}
