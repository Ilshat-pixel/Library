using AutoMapper;
using Library.Application.CQRS.Commands.PersonCommands.CreateHuman;
using Library.Application.CQRS.Commands.PersonCommands.CreatePerson;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.PersonCommands.CreatepPerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, PersonVm>
    {
        private readonly IWebDbContext _webDbContext;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(IWebDbContext webDbContext, IMapper mapper)
        {
            _webDbContext = webDbContext;
            _mapper = mapper;
        }

        public async  Task<PersonVm> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                Birthday = request.Birthday,
                LastName = request.Patronymic,
                FirstName = request.Name,
                MiddleName = request.Surname
            };
            await _webDbContext.Persons.AddAsync(person, cancellationToken);
            await _webDbContext.SaveChangesAsync(cancellationToken);
            var personDto = _mapper.Map<PersonVm>(person);
            return personDto;
        }
    }
}
