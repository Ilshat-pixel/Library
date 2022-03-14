using AutoMapper;
using Library.Application.Common.Exceptions;
using Library.Application.CQRS.Commands.PersonCommands.CreatePerson;
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

namespace Library.Application.CQRS.Commands.PersonCommands.UpdatePerson
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, PersonVm>
    {
        private readonly IWebDbContext _webDbContext;
        private readonly IMapper _mapper;

        public UpdatePersonCommandHandler(IWebDbContext webDbContext, IMapper mapper)
        {
            _webDbContext = webDbContext;
            _mapper = mapper;
        }

      
        public async Task<PersonVm> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _webDbContext.Persons.FirstOrDefaultAsync(person => person.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.MiddleName = request.MiddleName;
            entity.Birthday = request.Birthday;
            await _webDbContext.SaveChangesAsync(cancellationToken);
            var personVm = _mapper.Map<PersonVm>(entity);
            return personVm;

        }
    }
}
