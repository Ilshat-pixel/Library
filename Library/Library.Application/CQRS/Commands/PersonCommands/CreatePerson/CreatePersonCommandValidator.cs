using FluentValidation;

namespace Library.Application.CQRS.Commands.PersonCommands.CreatePerson
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(createHumanCommand =>
                createHumanCommand.Surname).NotEmpty().NotNull();

            RuleFor(createHumanCommand =>
                createHumanCommand.Name).NotEmpty().NotNull();

            RuleFor(createHumanCommand =>
                createHumanCommand.Patronymic).NotEmpty().NotNull();

            RuleFor(createHumanCommand =>
                createHumanCommand.Birthday).NotEmpty().NotNull();
        }
    }
}
