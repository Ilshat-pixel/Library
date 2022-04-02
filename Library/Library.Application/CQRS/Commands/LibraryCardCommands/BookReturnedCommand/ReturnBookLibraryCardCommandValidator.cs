using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.LibraryCardCommands.BookReturnedCommand
{
    public class ReturnBookLibraryCardCommandValidator : AbstractValidator<ReturnBookLibraryCardCommand>
    {
        public ReturnBookLibraryCardCommandValidator()
        {
            RuleFor(x => x.PersonId).NotEmpty();
            RuleFor(x => x.BookTitles).NotEmpty();
        }
    }
}
