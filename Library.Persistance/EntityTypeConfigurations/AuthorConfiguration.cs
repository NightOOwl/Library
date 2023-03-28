using Lib.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistance.EntityTypeConfigurations
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(author => author.Id);
            builder.HasIndex(author => author.Id).IsUnique();
            builder.Property(author => author.FirstName).HasMaxLength(30);
            builder.Property(author => author.LastName).HasMaxLength(30);
        }
    }
}
