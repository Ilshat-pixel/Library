using FluentValidation;

namespace Library.Application.CQRS.Commands.BookCommands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(updateBookCommand =>
                updateBookCommand.Name).NotEmpty().NotNull();
            RuleFor(updateBookCommand =>
                updateBookCommand.GenreId).NotEmpty().NotNull();
            RuleFor(updateBookCommand =>
                updateBookCommand.AuthorId).NotEmpty().NotNull();
            RuleFor(updateBookCommnad =>
            updateBookCommnad.Id).NotEmpty().NotNull();
        }
    }
}
