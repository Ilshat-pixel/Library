using MediatR;
using System;

namespace Library.Application.CQRS.Commands.HumanCommands.CreateHuman
{
    public class CreateHumanCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
    }
}
