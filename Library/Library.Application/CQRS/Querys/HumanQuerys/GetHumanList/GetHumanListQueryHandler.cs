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

namespace Library.Application.CQRS.Querys.HumanQuerys.GetHumanList
{
    public class GetHumanListQueryHandler:IRequestHandler<GetHumanListQuery,HumanListVm>
    {
        private readonly IWebDbContext _webDbContext;
        private readonly IMapper _mapper;

        public GetHumanListQueryHandler(IMapper mapper, IWebDbContext webDbContext = null)
        {
            _mapper = mapper;
            _webDbContext = webDbContext;
        }

        public async Task<HumanListVm> Handle(GetHumanListQuery request, CancellationToken cancellationToken)
        {
            var humanQuery = await _webDbContext.Humans.Include(h=>h.Books)
                .ProjectTo<HumanLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new HumanListVm { Humans = humanQuery };
        }
    }
}
