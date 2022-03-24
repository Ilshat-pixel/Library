using FluentValidation;

namespace Library.Application.CQRS.Commands.HumanCommands.DeleteHuman
{
    public class DeleteHumanCommandValidator : AbstractValidator<DeleteHumanCommand>
    {
        public DeleteHumanCommandValidator()
        {
            RuleFor(deleteHumanCommand =>
                deleteHumanCommand.Id).NotEmpty().NotNull();
        }
    }
}
