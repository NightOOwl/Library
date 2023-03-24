using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Lib.Domain;

namespace Library.Persistance.EntityTypeConfigurations
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure (EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(book => book.Id);
            builder.HasIndex(book => book.Id).IsUnique();
            builder.Property(book => book.Title).HasMaxLength(250);
        }
    }
}
