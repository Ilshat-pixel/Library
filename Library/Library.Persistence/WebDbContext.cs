using Library.Application.Interfaces;
using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence
{
    public class WebDbContext : DbContext, IWebDbContext
    {
        public WebDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Human> Humans { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
