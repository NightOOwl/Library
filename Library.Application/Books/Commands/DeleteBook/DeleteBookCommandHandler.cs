using MediatR;
using Library.Application.Interfaces;
using Library.Application.Common.Exceptions;
using Lib.Domain;

namespace Library.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler
        :IRequestHandler<DeleteBookCommand>
    {
        private readonly IBooksDbContext _dbContext;
        public DeleteBookCommandHandler(IBooksDbContext dbContext)=>
            _dbContext = dbContext;
        public async Task Handle (DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Books
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }
            _dbContext.Books.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
