using Lib.Domain;
using Library.Application.Interfaces;
using MediatR;

namespace Library.Application.Authors.Commands.AddAuthor
{
    public class AddAuthorCommandHandler:
        IRequestHandler<AddAuthorCommand, Guid>
    {
            
        private readonly IAuthorDbContext _dbContext;
        public AddAuthorCommandHandler(IAuthorDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(AddAuthorCommand request,
            CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                Country = request.Country,
                EditTime = null

            };
            await _dbContext.Authors.AddAsync(author, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return author.Id;
        }
    }
}

