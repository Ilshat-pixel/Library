using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.CQRS.Querys.GenreQuerys.GenreDetailQuery
{
    public class GenreDetailQueryHandler : IRequestHandler<GenreDetailQuery, GenreDetailVm>
    {
        private readonly IWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public GenreDetailQueryHandler(IWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GenreDetailVm> Handle(GenreDetailQuery request, CancellationToken cancellationToken)
        {
            var genre = await _dbContext.Genres
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (genre == null)
            {
                throw new NotFoundException(nameof(Genre), request.Id);
            }
            return _mapper.Map<GenreDetailVm>(genre);
        }
    }
}
