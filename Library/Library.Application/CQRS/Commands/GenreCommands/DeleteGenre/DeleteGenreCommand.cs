using MediatR;

namespace Library.Application.CQRS.Commands.GenreCommands.DeleteGenre
{
    public class DeleteGenreCommand:IRequest
    {
        public int Id { get; set; }
    }
}
