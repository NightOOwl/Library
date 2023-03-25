using Lib.Domain;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;


namespace Library.Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler :
        IRequestHandler<DeleteAuthorCommand>
    {
        private readonly IAuthorDbContext _dbContext;
        public DeleteAuthorCommandHandler(IAuthorDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Authors
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }
            _dbContext.Authors.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
