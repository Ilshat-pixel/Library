using Library.Application.CQRS.Commands.BookCommands.CreateBook;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.AuthorCommands.CreateAuthorCommand
{
    public class CreateAuthorCommand:IRequest<IList<int>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public IList<CreateBookCommand> Books { get; set; }
    }
}
