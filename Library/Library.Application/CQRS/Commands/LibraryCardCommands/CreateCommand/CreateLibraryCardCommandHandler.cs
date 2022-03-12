using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.LibraryCardCommands.CreateCommand
{
    public class CreateLibraryCardCommandHandler : IRequestHandler<CreateLibraryCardCommand, int>
    {
        private readonly IWebDbContext _webDbContext;

        public CreateLibraryCardCommandHandler(IWebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public async Task<int> Handle(CreateLibraryCardCommand request, CancellationToken cancellationToken)
        {
            var human = await _webDbContext.Humans.FindAsync(new object[] { request.HumanId }, cancellationToken);

            if (human == null)
            {
                throw new NotFoundException(nameof(Person), request.HumanId);
            }

            var libraryCard = new LibraryCard
            {
                DateOfIssue = DateTimeOffset.Now,
                Human = human
            };

            await _webDbContext.LibraryCards.AddAsync(libraryCard, cancellationToken);
            await _webDbContext.SaveChangesAsync(cancellationToken);

            return libraryCard.Id;
        }
    }
}
