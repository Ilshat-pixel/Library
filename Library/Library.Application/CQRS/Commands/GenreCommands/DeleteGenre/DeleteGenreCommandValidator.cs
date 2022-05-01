using FluentValidation;

namespace Library.Application.CQRS.Commands.GenreCommands.DeleteGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
        }
    }
}
