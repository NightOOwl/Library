using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Library.Application.Books.Queries.GetBookList
{
    public class GetBookListQueryHandler
        :IRequestHandler<GetBookListQuery,BookListVm>
    {
        private readonly IBooksDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBookListQueryHandler(IBooksDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper) ;
        public async Task<BookListVm> Handle (GetBookListQuery request,
            CancellationToken cancellationToken)
        {
            var booksQuery = await _dbContext.Books
                .Where(book => book.Id == request.Id)
                .ProjectTo<BookLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new BookListVm { Books = booksQuery };
        }
    }
}
