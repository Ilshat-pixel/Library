using MediatR;

namespace Library.Application.CQRS.Commands.PersonCommands.DeletePerson
{
    public class DeletePersonCommand : IRequest
    {
        public int Id { get; set; }

    }
}
