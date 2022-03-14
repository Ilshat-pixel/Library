using FluentValidation;

namespace Library.Application.CQRS.Commands.GenreCommands.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(createGenreCommandValidator=>createGenreCommandValidator.GenreName).NotEmpty().NotNull();
        }
    }
}
