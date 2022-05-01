using FluentValidation;

namespace Library.Application.CQRS.Commands.GenreCommands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x=>x.Name).NotEmpty();
        }
    }
}
