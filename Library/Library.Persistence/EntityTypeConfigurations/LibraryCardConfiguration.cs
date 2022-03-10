using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Library.Persistence.EntityTypeConfigurations
{
    public class LibraryCardConfiguration : IEntityTypeConfiguration<LibraryCard>
    {
        public void Configure(EntityTypeBuilder<LibraryCard> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);
            builder.HasOne(x => x.Human)
                .WithMany(h => h.LibraryCards).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x => x.Book)
                .WithMany(h => h.Cards).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
