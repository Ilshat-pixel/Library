using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.BookCommands.CreateBook
{
    /// <summary>
    /// Hadler for create a new book
    /// </summary>
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IWebDbContext _dbContext;

        public CreateBookCommandHandler(IWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var author = await _dbContext.Authors.FindAsync(new object[] { request.AuthorId }, cancellationToken);
            if (author == null)
            {
                throw new NotFoundException(nameof(Person), request.AuthorId);
            }
            var genre = await _dbContext.Genres.Where(x => request.GenreIds.Contains(x.Id)).ToListAsync(cancellationToken);
            if (genre == null)
            {
                throw new NotFoundException(nameof(Genre), request.GenreIds);
            }
            var book = new Book
            {
                Author = author,
                Genres = genre,
                Name = request.Title
            };
            await _dbContext.Books.AddAsync(book, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return book.Id;
        }
    }
}
