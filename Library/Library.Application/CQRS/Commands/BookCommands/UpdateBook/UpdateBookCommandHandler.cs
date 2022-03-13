﻿using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.BookCommands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IWebDbContext _webDbContext;

        public UpdateBookCommandHandler(IWebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _webDbContext.Books.FindAsync(new object[] { request.Id }, cancellationToken);
            if (book == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }
            //TODO: придумать что делать если автор айди не поменялся, пока что буду всегда перезаписывать 
            var author = await _webDbContext.Persons.FindAsync(new object[] { request.AuthorId }, cancellationToken);
            if (author == null)
            {
                throw new NotFoundException(nameof(Person), request.AuthorId);
            }
            //var genre =  _webDbContext.Genres.Where(x=>request.GenreId.Contains(x.Id));
            //if (genre == null)
            //{
            //    throw new NotFoundException(nameof(Genre), request.GenreId);
            //}
            //book.Author = author;
            //book.Genre = genre;
            book.Name = request.Name;
            await _webDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
