using FluentValidation;

namespace Library.Application.CQRS.Commands.BookCommands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(updateBookCommand =>
                updateBookCommand.Title).NotEmpty().NotNull();
            RuleFor(updateBookCommand =>
                updateBookCommand.Genre).NotEmpty().NotNull();
            RuleFor(updateBookCommand =>
                updateBookCommand.AuthorId).NotEmpty().NotNull();
            RuleFor(updateBookCommnad =>
            updateBookCommnad.Id).NotEmpty().NotNull();
        }
    }
}
