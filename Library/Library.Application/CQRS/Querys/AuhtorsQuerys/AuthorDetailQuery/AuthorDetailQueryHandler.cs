using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.CQRS.Querys.AuhtorsQuerys.AuthorDetailQuery
{
    public class AuthorDetailQueryHandler : IRequestHandler<AuthorDetailQuery, AuthorDetailVm>
    {
        private readonly IWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public AuthorDetailQueryHandler(IWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<AuthorDetailVm> Handle(AuthorDetailQuery request, CancellationToken cancellationToken)
        {
            var author = await _dbContext.Authors
              .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (author == null)
            {
                throw new NotFoundException(nameof(Genre), request.Id);
            }
            return _mapper.Map<AuthorDetailVm>(author);
        }
    }
}
