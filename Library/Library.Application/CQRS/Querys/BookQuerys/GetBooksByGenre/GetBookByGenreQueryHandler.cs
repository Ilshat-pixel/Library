using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Querys.BookQuerys.GetBooksByGenre
{
    public class GetBookByGenreQueryHandler : IRequestHandler<GetBookByGenreQuery, BooksByGenreVm>
    {
        private readonly IWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBookByGenreQueryHandler(IWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async  Task<BooksByGenreVm> Handle(GetBookByGenreQuery request, CancellationToken cancellationToken)
        {
            var books = await _dbContext.Books
                .Where(x => x.Genres.Any(g => g.Id == request.Id))
                .ProjectTo<BooksByGenreLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new BooksByGenreVm { Books = books };
        }
    }
}
