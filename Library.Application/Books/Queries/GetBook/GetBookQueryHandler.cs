using AutoMapper;
using Lib.Domain;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Queries.GetBooks
{
    public class GetBookQueryHandler
        : IRequestHandler<GetBookQuery,BookVm>
    {
        private readonly IBooksDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBookQueryHandler(IBooksDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        public async Task <BookVm> Handle (GetBookQuery request,CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Books
                   .FirstOrDefaultAsync (book => 
                   book.Id == request.Id, cancellationToken);
            if(entity == null)
            {
                throw new NotFoundException(nameof(Book),request.Id);
            }
            return _mapper.Map<BookVm>(entity); 
        }
    }
}
