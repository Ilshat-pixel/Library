using System.Collections.Generic;
using Library.Application.CQRS.Commands.BookCommands.CreateBook;
using MediatR;

namespace Library.Application.CQRS.Commands.AuthorCommands.UpdateAuthorCommand
{
    public class UpdateAuthorCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public IList<CreateBookCommand> Books { get; set; }
    }
}
