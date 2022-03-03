using MediatR;

namespace Library.Application.CQRS.Commands.BookCommands.CreateBook
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Title { get; set; }
        //TODO: книга может содержать более 1 автора, пока для упрощения
        public int AuthorId { get; set; }
        public string Genre { get; set; }
    }
}
