using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("person");
            builder.HasKey(x => x.Id).HasName("id");
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
            builder.Property(x => x.Birthday)
                .HasColumnName("birth_date");
        }
    }
}
