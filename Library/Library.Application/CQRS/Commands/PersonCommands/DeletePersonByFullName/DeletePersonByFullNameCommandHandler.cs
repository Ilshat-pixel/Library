using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.PersonCommands.DeletePersonByFullName
{
    public class DeletePersonByFullNameCommandHandler : IRequestHandler<DeletePersonByFullNameCommand>
    {
        private readonly IWebDbContext _dbContext;

        public DeletePersonByFullNameCommandHandler(IWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeletePersonByFullNameCommand request, CancellationToken cancellationToken)
        {
            var persons =await  _dbContext.Persons.Where(p => (p.FirstName.ToLower() == request.FirstName.ToLower()
                     && p.LastName.ToLower() == request.LastName.ToLower()
                     && p.MiddleName.ToLower() == request.MiddleName.ToLower())).ToListAsync(cancellationToken);
            if (persons.Count()==0)
            {
                throw new NotFoundException(nameof(Person), $"Name {request.FirstName} {request.MiddleName} {request.LastName}");
            }
            _dbContext.Persons.RemoveRange(persons);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
