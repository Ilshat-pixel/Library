using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var entity = await _webDbContext.LibraryCards.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(LibraryCard), request.Id);
            }
            entity.IsReterned = true;
            entity.ReturnDate = DateTimeOffset.Now;
            await  _webDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
