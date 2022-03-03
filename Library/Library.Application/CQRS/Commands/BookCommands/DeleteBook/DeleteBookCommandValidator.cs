using FluentValidation;

namespace Library.Application.CQRS.Commands.BookCommands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(deleteBookCommand =>
                deleteBookCommand.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
