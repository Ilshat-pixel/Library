using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Querys.GenreQuerys.GetGenreListQuery
{
    public class GetGenreListQueryHandler : IRequestHandler<GetGenreListQuery, GenreListVm>
    {
        private readonly IWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenreListQueryHandler(IWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GenreListVm> Handle(GetGenreListQuery request, CancellationToken cancellationToken)
        {
            var genreQuery = await _dbContext.Genres
                .ProjectTo<GenreLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new GenreListVm { Genres = genreQuery };
        }
    }
}
