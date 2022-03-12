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
            builder.HasKey(x => new {x.HumanId,x.BookId});
            builder.Property(x=>x.BookId)
                .HasColumnName("book_id")
                .IsRequired();
            builder.Property(x => x.HumanId)
                .HasColumnName("person_id")
                .IsRequired();
            builder.Property(x => x.DateOfIssue)
                .HasColumnName("issue_date")
                .IsRequired();
            builder.HasOne(x => x.Human)
                .WithMany(h => h.LibraryCards)
                .HasForeignKey(x=>x.HumanId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x => x.Book)
                .WithMany(h => h.LibraryCards)
                .HasForeignKey(x=>x.BookId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
