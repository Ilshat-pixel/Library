using FluentValidation;
using Library.Application.CQRS.Commands.PersonCommands.DeletePerson;
using Library.Application.Interfaces;

namespace Library.Application.CQRS.Commands.HumanCommands.DeleteHuman
{
    public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
    {

        public DeletePersonCommandValidator()
        {
            RuleFor(deleteHumanCommand =>
                deleteHumanCommand.Id).NotEmpty().NotNull();
        }
    }
}
