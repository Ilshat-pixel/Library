using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.HumanCommands.CreateHuman
{
    public class CreateHumanCommandHandler : IRequestHandler<CreateHumanCommand, int>
    {
        private readonly IWebDbContext _webDbContext;

        public CreateHumanCommandHandler(IWebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public async Task<int> Handle(CreateHumanCommand request, CancellationToken cancellationToken)
        {
            //TODO: Если снача создаем человека, а потом в некоторых книгах добавляем его как автора, поэтому пока книги в создании не учавствуют
            var human = new Person
            {
                Birthday = request.Birthday,
                Surname = request.Surname,
                FirstName = request.Name,
                MiddleName = request.Patronymic
            };
            await _webDbContext.Humans.AddAsync(human, cancellationToken);
            await _webDbContext.SaveChangesAsync(cancellationToken);
            return human.Id;
        }
    }
}
