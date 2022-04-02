using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.LibraryCardCommands.BookReturnedCommand
{
    public class ReturnBookLibraryCardCommandHandler : IRequestHandler<ReturnBookLibraryCardCommand>
    {
        private readonly IWebDbContext _webDbContext;

        public ReturnBookLibraryCardCommandHandler(IWebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public async Task<Unit> Handle(ReturnBookLibraryCardCommand request, CancellationToken cancellationToken)
        {
            //TODO: проверка на нал
            var entity = await _webDbContext.LibraryCards
                .Include(x => x.Book)
                .Where(x => (x.Id == request.PersonId && x.IsReterned == false && request.BookTitles.Contains(x.Book.Name)))
                .ToListAsync(cancellationToken);
            //if (entity == null)
            //{
            //    throw new NotFoundException(nameof(LibraryCard), request.Id);
            //}
            foreach (var item in entity)
            {
                item.IsReterned = true;
                item.ReturnDate = DateTimeOffset.Now;
            }
            await _webDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
