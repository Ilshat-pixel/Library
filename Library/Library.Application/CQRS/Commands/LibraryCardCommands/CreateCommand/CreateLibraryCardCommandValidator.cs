using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
