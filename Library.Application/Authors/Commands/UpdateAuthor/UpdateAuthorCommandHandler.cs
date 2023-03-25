using Lib.Domain;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;


namespace Library.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler
        : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IAuthorDbContext _dbContext;
        public UpdateAuthorCommandHandler(IAuthorDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(UpdateAuthorCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Authors.FirstOrDefaultAsync(author =>
                        author.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }          
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Coutry = request.Country;
            entity.BirthDate = request.BirthDate;
            entity.EditTime = DateTime.Now;
           
            await _dbContext.SaveChangesAsync(cancellationToken);
            
        }
    }
}
