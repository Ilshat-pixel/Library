using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Library.Persistence.EntityTypeConfigurations
{
    public class LibraryCardConfiguration : IEntityTypeConfiguration<LibraryCard>
    {
        public void Configure(EntityTypeBuilder<LibraryCard> builder)
        {
            builder.ToTable("library_card");
            builder.Property(x=>x.Id)
                .HasColumnName("id");
            builder.Property(x=>x.BookId)
                .HasColumnName("book_id")
                .IsRequired();
            builder.Property(x => x.PersonId)
                .HasColumnName("person_id")
                .IsRequired();
            builder.Property(x => x.Date)
                .HasColumnName("date")
                .IsRequired();
            builder.HasOne(x => x.Status)
                .WithMany(c => c.LibraryCards)
                .HasForeignKey(x => x.StatusId);
            builder.HasOne(x => x.Person)
                .WithMany(h => h.LibraryCards)
                .HasForeignKey(x=>x.PersonId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x => x.Book)
                .WithMany(h => h.LibraryCards)
                .HasForeignKey(x=>x.BookId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
