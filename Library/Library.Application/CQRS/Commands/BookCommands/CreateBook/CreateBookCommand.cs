using MediatR;
using System.Collections.Generic;

namespace Library.Application.CQRS.Commands.BookCommands.CreateBook
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public IList<int> GenreId { get; set; }
    }
}
