using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class HumanConfiguration : IEntityTypeConfiguration<Human>
    {
        public void Configure(EntityTypeBuilder<Human> builder)
        {
            builder.HasKey(h => h.Id);
            builder.HasIndex(h => h.Id);
            builder.HasMany(h => h.Books)
                .WithOne(b => b.Author).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(h => h.LibraryCards)
                .WithOne(c => c.Human).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
