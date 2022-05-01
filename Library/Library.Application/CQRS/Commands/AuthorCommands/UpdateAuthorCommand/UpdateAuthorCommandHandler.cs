using System;
using System.Threading;
using System.Threading.Tasks;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.CQRS.Commands.AuthorCommands.UpdateAuthorCommand
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IWebDbContext _dbContext;

        public UpdateAuthorCommandHandler(IWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _dbContext.Authors.FirstOrDefaultAsync(genre => genre.Id == request.Id, cancellationToken);
            if (author == null)
            {
                throw new NotFoundException(nameof(Genre), request.Id);
            }
            author.FirstName = request.FirstName;
            author.LastName = request.LastName;
            author.MiddleName = request.MiddleName;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
