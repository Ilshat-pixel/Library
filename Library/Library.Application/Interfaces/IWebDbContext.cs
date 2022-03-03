using Library.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface IWebDbContext
    {

        DbSet<Book> Books { get; set; }
        DbSet<Human> Humans { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
