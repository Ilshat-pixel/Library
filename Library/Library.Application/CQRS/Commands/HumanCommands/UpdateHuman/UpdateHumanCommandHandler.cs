using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.HumanCommands.UpdateHuman
{
    public class UpdateHumanCommandHandler : IRequestHandler<UpdateHumanCommand>
    {
        private readonly IWebDbContext _webDbContext;

        public UpdateHumanCommandHandler(IWebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public async Task<Unit> Handle(UpdateHumanCommand request, CancellationToken cancellationToken)
        {
            var human = await _webDbContext.Humans.FindAsync(new object[] { request.Id },cancellationToken);
            if (human == null)
            {
                throw new NotFoundException(nameof(Human), request.Id);
            }
            human.Name = request.Name;
            human.Birthday = request.Birthday;
            human.Patronymic = request.Patronymic;
            human.Surname = request.Surname;
            await _webDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
