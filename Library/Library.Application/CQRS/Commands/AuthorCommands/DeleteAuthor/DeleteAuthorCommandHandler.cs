using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.AuthorCommands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler:IRequestHandler<DeleteAuthorCommand>
    {
        private readonly IWebDbContext _dbContext;

        public DeleteAuthorCommandHandler(IWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Authors.Include(x=>x.Books).FirstOrDefaultAsync(e=>e.Id== request.Id , cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }
            if (entity.Books.Count>0)
            {
                throw new AuthorCannotBeDeletedException(nameof(Author), request.Id);
            }
            _dbContext.Authors.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
