using Library.Application.CQRS.Commands.PersonCommands.CreatePerson;
using MediatR;
using System;

namespace Library.Application.CQRS.Commands.PersonCommands.UpdatePerson
{
    public class UpdatePersonCommand:IRequest<PersonVm>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset Birthday { get; set; }

    }
}
