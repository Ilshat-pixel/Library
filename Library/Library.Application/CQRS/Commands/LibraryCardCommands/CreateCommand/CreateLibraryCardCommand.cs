using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.LibraryCardCommands.CreateCommand
{
    public class CreateLibraryCardCommand:IRequest<int>
    {
        public int HumanId { get; set; }
    }
}
