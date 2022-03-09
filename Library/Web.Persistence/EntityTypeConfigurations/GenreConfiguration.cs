using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey (x => x.Id);
            builder.HasIndex(x => x.Id);
            builder.HasMany(g => g.Books)
                .WithOne(b => b.Genre).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
