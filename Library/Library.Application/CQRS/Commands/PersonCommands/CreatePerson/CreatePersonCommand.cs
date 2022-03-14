using Library.Application.CQRS.Commands.PersonCommands.CreatePerson;
using MediatR;
using System;

namespace Library.Application.CQRS.Commands.PersonCommands.CreatePerson
{
    public class CreatePersonCommand : IRequest<PersonVm>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
    }
}
