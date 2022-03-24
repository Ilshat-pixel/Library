using Library.Application.Interfaces;
using Library.Domain;
using Library.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence
{
    public class WebDbContext : DbContext, IWebDbContext
    {
        public WebDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<LibraryCard> LibraryCards { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Author> Authors { get; set ; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new AuthorConfiguration());
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new PersonConfiguration());
            builder.ApplyConfiguration(new LibraryCardConfiguration());
            
        }
    }
}
