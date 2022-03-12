using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genre");
            builder.HasKey(x => x.Id)
                .HasName("id");
            builder.Property(x => x.GenreName)
                .HasColumnName("genre_name")
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
