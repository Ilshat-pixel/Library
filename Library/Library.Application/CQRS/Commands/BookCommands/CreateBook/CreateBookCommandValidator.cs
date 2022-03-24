using FluentValidation;

namespace Library.Application.CQRS.Commands.BookCommands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(createBookCommand =>
                createBookCommand.Title).NotEmpty().NotNull();
            RuleFor(createBookCommand =>
                createBookCommand.AuthorId).NotNull().NotEmpty();
            RuleFor(createBookCommand =>
                createBookCommand.GenreId).NotEmpty().NotNull();
        }

    }
}
