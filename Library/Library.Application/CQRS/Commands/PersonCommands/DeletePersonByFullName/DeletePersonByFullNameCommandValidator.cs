using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.PersonCommands.DeletePersonByFullName
{
    public class DeletePersonByFullNameCommandValidator : AbstractValidator<DeletePersonByFullNameCommand>
    {
        public DeletePersonByFullNameCommandValidator()
        {
            RuleFor(deletePersonCommandByFullName => deletePersonCommandByFullName.FirstName).NotEmpty().NotNull();
            RuleFor(deletePersonCommandByFullName => deletePersonCommandByFullName.LastName).NotEmpty().NotNull();
            RuleFor(deletePersonCommandByFullName => deletePersonCommandByFullName.MiddleName).NotEmpty().NotNull();
        }
    }
}
