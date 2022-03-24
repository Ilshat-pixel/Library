using FluentValidation;

namespace Library.Application.CQRS.Commands.LibraryCardCommands.CreateCommand
{
    public class CreateLibraryCardCommandValidator : AbstractValidator<CreateLibraryCardCommand>
    {
        public CreateLibraryCardCommandValidator()
        {
            RuleFor(createLibraryCardCommand =>
            createLibraryCardCommand.HumanId).NotEmpty().NotNull();
        }
    }
}
