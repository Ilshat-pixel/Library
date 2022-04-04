using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Querys.AuhtorsQuerys.GetAuthorList
{
    public class GetAuthorListQueryHandler:IRequestHandler<GetAuthorListQuery,AuthorListVm>
    {
        private readonly IWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAuthorListQueryHandler(IWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<AuthorListVm> Handle(GetAuthorListQuery request, CancellationToken cancellationToken)
        {
            var authorQuery = await  _dbContext.Authors
                .ProjectTo<AuthorLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new AuthorListVm { Authors = authorQuery };
        }
    }
}
