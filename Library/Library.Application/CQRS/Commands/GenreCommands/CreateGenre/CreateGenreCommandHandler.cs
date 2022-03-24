using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.GenreCommands.CreateGenre
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, int>
    {
        private readonly IWebDbContext _dbContext;

        public CreateGenreCommandHandler(IWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre
            {
                GenreName = request.GenreName
            };
            await _dbContext.Genres.AddAsync(genre,cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return genre.Id;
        }
    }
}
