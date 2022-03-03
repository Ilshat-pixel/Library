using MediatR;

namespace Library.Application.CQRS.Commands.HumanCommands.DeleteHuman
{
    public class DeleteHumanCommand : IRequest
    {
        public int Id { get; set; }

    }
}
