using AutoMapper;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Querys.GenreQuerys.GetGenresWithBookCountQuery
{
    public class GetGenresWithBookCountQueryHadler : IRequestHandler<GetGenresWithBookCountQuery, GenreCountVm>
    {
        private readonly IWebDbContext _dbContext;

        public GetGenresWithBookCountQueryHadler(IWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GenreCountVm> Handle(GetGenresWithBookCountQuery request, CancellationToken cancellationToken)
        {
            //TODO: Понять что с этим сдеать, явно не оптимальное г.
            var genreCountQuery = await _dbContext.Genres
                .Include(x => x.Books)
                .Select(x => new GenreCountDto { GenreName = x.GenreName, Count = x.Books.Count() })
                .ToListAsync(cancellationToken);

            return new GenreCountVm { GenreCounts = genreCountQuery };


        }
    }
}
