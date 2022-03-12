using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("book");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x=>x.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.AuthorId)
                .HasColumnName("author_id")
                .IsRequired();
            builder.HasOne(x => x.Author).WithMany(a => a.Books).HasForeignKey(x => x.AuthorId);

        }
    }
}
