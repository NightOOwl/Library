using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Authors.Queries.GetAuthorList
{
    public class GetAuthorListQueryHandler
         : IRequestHandler<GetAuthorListQuery, AuthorListVm>
    {
        private readonly IAuthorDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorListQueryHandler(IAuthorDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<AuthorListVm> Handle(GetAuthorListQuery request,
            CancellationToken cancellationToken)
        {
            var authorQuery = await _dbContext.Authors
                .Where(author => author.Id == request.Id)
                .ProjectTo<AuthorLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new AuthorListVm { Authors = authorQuery };
        }
    }
}
