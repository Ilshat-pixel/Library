using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class LibraryCardStatusConfiguration : IEntityTypeConfiguration<LibraryCardStatus>
    {
        public void Configure(EntityTypeBuilder<LibraryCardStatus> builder)
        {
            builder.ToTable("action");
            builder.Property(x => x.Id)
                .HasColumnName("id");
            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(25);
        }
    }
}
