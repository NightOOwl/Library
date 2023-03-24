using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
