using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("book");
            builder.Property(x => x.Id)
                .HasColumnName("id");
            builder.Property(x=>x.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.AuthorId)
                .HasColumnName("author_id")
                .IsRequired();
           
            builder.HasOne(x => x.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(x => x.AuthorId);
            builder.HasMany(x => x.Genres)
                .WithMany(x => x.Books)
                .UsingEntity<Dictionary<string, object>>(
                "book_genre",
                x => x.HasOne<Genre>().WithMany().HasForeignKey("genre_id"),
                x => x.HasOne<Book>().WithMany().HasForeignKey("book_id"));
            builder.HasMany(x => x.LibraryCards)
                .WithOne(x => x.Book)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
