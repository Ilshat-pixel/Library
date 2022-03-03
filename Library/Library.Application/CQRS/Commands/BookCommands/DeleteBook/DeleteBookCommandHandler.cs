using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.BookCommands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IWebDbContext _webDbContext;

        public DeleteBookCommandHandler(IWebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _webDbContext.Books.FindAsync(new object[] { request.Id }, cancellationToken);
            if (book == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);

            }
            _webDbContext.Books.Remove(book);
            await _webDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
