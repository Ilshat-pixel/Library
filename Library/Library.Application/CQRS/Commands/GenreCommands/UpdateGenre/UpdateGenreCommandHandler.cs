using System.Threading;
using System.Threading.Tasks;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.CQRS.Commands.GenreCommands.UpdateGenre
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, Unit>
    {
        private readonly IWebDbContext _dbContext;

        public UpdateGenreCommandHandler(IWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _dbContext.Genres.FirstOrDefaultAsync(genre => genre.Id == request.Id, cancellationToken);
            if (genre == null)
            {
                throw new NotFoundException(nameof(Genre), request.Id);
            }
            genre.GenreName = request.Name;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
