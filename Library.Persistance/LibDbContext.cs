using Lib.Domain;
using Library.Application.Interfaces;
using Library.Persistance.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistance
{
    public class LibDbContext : DbContext, IBooksDbContext,IAuthorDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public LibDbContext (DbContextOptions <LibDbContext> options)
            : base (options) { }
        protected override void OnModelCreating ( ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new AuthorConfiguration());
            base.OnModelCreating (builder);
        }
    }
}
