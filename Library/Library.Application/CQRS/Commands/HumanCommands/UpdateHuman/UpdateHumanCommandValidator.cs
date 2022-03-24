using FluentValidation;

namespace Library.Application.CQRS.Commands.HumanCommands.UpdateHuman
{
    public class UpdateHumanCommandValidator : AbstractValidator<UpdateHumanCommand>
    {
        public UpdateHumanCommandValidator()
        {
            RuleFor(udpateHumanCommand =>
            udpateHumanCommand.Name).NotEmpty().NotNull();
            RuleFor(udpateHumanCommand =>
           udpateHumanCommand.Surname).NotEmpty().NotNull();
            RuleFor(udpateHumanCommand =>
           udpateHumanCommand.Birthday).NotEmpty().NotNull();
            RuleFor(udpateHumanCommand =>
           udpateHumanCommand.Patronymic).NotEmpty().NotNull();
        }
    }
}
