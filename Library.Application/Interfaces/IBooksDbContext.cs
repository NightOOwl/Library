using Lib.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Interfaces
{
    public interface IBooksDbContext
    {
        DbSet <Book> Books { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    } 
}
