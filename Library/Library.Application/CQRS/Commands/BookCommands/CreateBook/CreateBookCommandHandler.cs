﻿using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
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
            var author = await _dbContext.Humans.FindAsync(new object[] { request.AuthorId }, cancellationToken);
            if (author == null)
            {
                throw new NotFoundException(nameof(Human), request.AuthorId);
            }
            var book = new Book
            {
                Author = author,
                Genre = request.Genre,
                Title = request.Title
            };
            await _dbContext.Books.AddAsync(book, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return book.Id;
        }
    }
}