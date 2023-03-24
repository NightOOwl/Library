using Lib.Domain;
using Library.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Books.Commands.CreateBook
{
    public  class CreatingBookCommandHandler
        : IRequestHandler<CreateBookCommand,Guid>
    {
        private readonly IBooksDbContext _dbContext;
        public CreatingBookCommandHandler(IBooksDbContext dbContext)=>
            _dbContext = dbContext; 
        public async Task<Guid> Handle (CreateBookCommand request,
            CancellationToken cancellationToken)
        {
            var book = new Book
            {
                AuthorId = request.AuthorId,
                Author = request.Author,
                Id = Guid.NewGuid(),
                Title = request.Title,
                CreationDate = DateTime.Now,
                EditTime = null
            };
            await _dbContext.Books.AddAsync(book,cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return book.Id;
        }
    }
}
