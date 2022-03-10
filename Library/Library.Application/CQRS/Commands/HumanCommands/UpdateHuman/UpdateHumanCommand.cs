using MediatR;
using System;

namespace Library.Application.CQRS.Commands.HumanCommands.UpdateHuman
{
    public class UpdateHumanCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
    }
}
