using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.AuthorCommands.DeleteAuthor
{
    public class DeleteAuthorCommand:IRequest
    {
        public int Id { get; set; }
    }
}
