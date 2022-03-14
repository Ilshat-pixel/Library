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
            var person = await _webDbContext.Persons.FindAsync(new object[] { request.PersonId }, cancellationToken);

            if (person == null)
            {
                throw new NotFoundException(nameof(Person), request.PersonId);
            }
            var book = await _webDbContext.Books.FindAsync(new object[] { request.BookId}, cancellationToken);

            if (person == null)
            {
                throw new NotFoundException(nameof(Book), request.BookId);
            }

            var libraryCard = new LibraryCard
            {
                TakeDate = DateTimeOffset.Now,
                Person = person,
                Book = book,
                IsReterned = false
            };

            await _webDbContext.LibraryCards.AddAsync(libraryCard, cancellationToken);
            await _webDbContext.SaveChangesAsync(cancellationToken);
            return libraryCard.Id;
        }
    }
}
