using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("author");
            builder.HasKey(x => x.Id)
                .HasName("id");
            builder.Property(x => x.FirstName)
                .HasColumnName("first_name")
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.LastName)
                .HasColumnName("last_name")
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.MiddleName)
                .HasColumnName("middle_name")
                .HasMaxLength(50);
            builder.HasMany(x=>x.Books)
                .WithOne(x=>x.Author)
                .HasForeignKey(x=>x.AuthorId);
        }
    }
}
