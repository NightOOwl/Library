using Lib.Domain;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler
        : IRequestHandler<UpdateBookCommand>
    {
        private readonly IBooksDbContext _dbContext;
        public UpdateBookCommandHandler (IBooksDbContext dbContext)=>
            _dbContext = dbContext; 
        public async Task  Handle (UpdateBookCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Books.FirstOrDefaultAsync(book => 
                        book.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }
            entity.Author= request.Author;
            entity.Title = request.Title;
            entity.EditTime = DateTime.Now;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

       
    }
}
