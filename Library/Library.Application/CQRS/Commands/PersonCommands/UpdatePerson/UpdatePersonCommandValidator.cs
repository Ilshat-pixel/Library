using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.PersonCommands.UpdatePerson
{
    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(updatePersonCommand=>updatePersonCommand.Id).NotEmpty();
            RuleFor(updatePersonCommand => updatePersonCommand.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(updatePersonCommand => updatePersonCommand.LastName).NotEmpty().MaximumLength(50);
            RuleFor(updatePersonCommand => updatePersonCommand.MiddleName).NotEmpty().MaximumLength(50);
            RuleFor(updatePersonCommand => updatePersonCommand.Birthday).NotEmpty();
        }
    }
}
