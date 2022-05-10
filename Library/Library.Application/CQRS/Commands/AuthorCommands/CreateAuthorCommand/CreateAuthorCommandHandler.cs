using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.AuthorCommands.CreateAuthorCommand
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
    {

        private readonly IWebDbContext _dbContext;

        public CreateAuthorCommandHandler(IWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName
            };
            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
    
        }
    }
}
