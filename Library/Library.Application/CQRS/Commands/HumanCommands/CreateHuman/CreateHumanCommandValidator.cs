using FluentValidation;

namespace Library.Application.CQRS.Commands.HumanCommands.CreateHuman
{
    public class CreateHumanCommandValidator : AbstractValidator<CreateHumanCommand>
    {
        public CreateHumanCommandValidator()
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
