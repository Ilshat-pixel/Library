using MediatR;

namespace Library.Application.CQRS.Commands.BookCommands.UpdateBook
{
    public class UpdateBookCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }
}
