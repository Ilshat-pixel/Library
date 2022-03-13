using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.EntityTypeConfigurations
{
    //public class BookGenreConfiguration : IEntityTypeConfiguration<BookGenre>
    //{
    //    //public void Configure(EntityTypeBuilder<BookGenre> builder)
    //    //{
    //    //    builder.ToTable("book_genre");
    //    //    builder.HasKey(x => new { x.GenreId, x.BookId });
    //    //    builder.HasOne(x => x.Genre)
    //    //        .WithMany(g => g.BookGenres)
    //    //        .HasForeignKey(x => x.GenreId);
    //    //    builder.HasOne(x => x.Book)
    //    //        .WithMany(g => g.BookGenres)
    //    //        .HasForeignKey(x => x.BookId);
    //    //    builder.Property(x => x.GenreId)
    //    //        .HasColumnName("genre_id")
    //    //        .IsRequired();
    //    //    builder.Property(x => x.BookId)
    //    //        .HasColumnName("book_id")
    //    //        .IsRequired();

    //    //}
    //}
}
