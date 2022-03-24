using AutoMapper;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Querys.GenreQuerys.GetGenresWithBookCountQuery
{
    //public class GetGenresWithBookCountQueryHadler : IRequestHandler<GetGenresWithBookCountQuery, GenreCounVm>
    //{
    //    private readonly IWebDbContext _dbContext;
    //    private readonly IMapper _mapper;

    //    public GetGenresWithBookCountQueryHadler(IMapper mapper, IWebDbContext dbContext )
    //    {
    //        _mapper = mapper;
    //        _dbContext = dbContext;
    //    }

    //    public async Task<GenreCounVm> Handle(GetGenresWithBookCountQuery request, CancellationToken cancellationToken)
    //    {
    //        //TODO: Понять что с этим сдеать, явно не оптимальное г.
    //        var genreCountQuery = _dbContext.Genres.Include(x => x.Books)
    //            .SelectMany(x => x.Books)
    //            .GroupBy(t => t, (k, g) => new { Book = k, BookCount = g.Count(),Genres = k.Genres});
            

    //    }
    //}
}
