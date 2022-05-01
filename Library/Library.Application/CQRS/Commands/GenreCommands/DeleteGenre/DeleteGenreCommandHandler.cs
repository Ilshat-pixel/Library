using System.Threading;
using System.Threading.Tasks;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.CQRS.Commands.GenreCommands.DeleteGenre
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand,Unit>
    {
        private readonly IWebDbContext _dbContext;

        public DeleteGenreCommandHandler(IWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _dbContext.Genres.FirstOrDefaultAsync(x=>x.Id==request.Id, cancellationToken);
            _dbContext.Genres.Remove(genre);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
