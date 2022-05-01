using MediatR;

namespace Library.Application.CQRS.Commands.GenreCommands.UpdateGenre
{
    public class UpdateGenreCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
