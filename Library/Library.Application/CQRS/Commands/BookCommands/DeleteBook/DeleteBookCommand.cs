using MediatR;

namespace Library.Application.CQRS.Commands.BookCommands.DeleteBook
{
    public class DeleteBookCommand : IRequest
    {
        public int Id { get; set; }
    }
}
