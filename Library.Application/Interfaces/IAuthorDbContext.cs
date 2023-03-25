using Lib.Domain;
using Microsoft.EntityFrameworkCore;


namespace Library.Application.Interfaces
{
    public interface IAuthorDbContext
    {
        DbSet<Author> Authors { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
