using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genre");
            builder.Property(x => x.Id)
           .HasColumnName("id");
            builder.Property(x => x.GenreName)
                .HasColumnName("genre_name")
                .IsRequired()
                .HasMaxLength(50);
            builder.HasMany(x => x.Books)
                .WithMany(x => x.Genres)
                .UsingEntity<Dictionary<string, object>>(
                "book_genre",
                x => x.HasOne<Book>().WithMany().HasForeignKey("book_id"),
                x => x.HasOne<Genre>().WithMany().HasForeignKey("genre_id"));
        }
    }
}
