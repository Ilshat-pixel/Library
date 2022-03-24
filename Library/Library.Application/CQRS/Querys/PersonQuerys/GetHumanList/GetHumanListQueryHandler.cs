using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Querys.HumanQuerys.GetHumanList
{
    public class GetHumanListQueryHandler : IRequestHandler<GetHumanListQuery, HumanListVm>
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
            var humanQuery = await _webDbContext.Persons
                .ProjectTo<PersonLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (!String.IsNullOrEmpty(request.SearchString))
            {
                humanQuery = humanQuery.Where(h => (h.FirstName.ToLower() + h.MiddleName.ToLower() + h.LastName.ToLower()).Contains(request.SearchString.ToLower())).ToList();
            }
            return new HumanListVm { Humans = humanQuery };
        }
    }
}
