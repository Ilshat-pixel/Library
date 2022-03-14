using MediatR;

namespace Library.Application.CQRS.Commands.LibraryCardCommands.CreateCommand
{
    public class CreateLibraryCardCommand : IRequest<int>
    {
        public int PersonId { get; set; }
        public int BookId { get; set; }
    }
}
