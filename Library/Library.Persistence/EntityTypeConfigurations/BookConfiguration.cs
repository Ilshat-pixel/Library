using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);
            builder.HasMany(b => b.Cards)
                .WithOne(c => c.Book).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(b => b.Author)
               .WithMany(c => c.Books).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(b => b.Genre)
               .WithMany(c => c.Books).OnDelete(DeleteBehavior.SetNull);

        }
    }
}
