using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.HumanCommands.DeleteHuman
{
    public class DeleteHumanCommandHandler : IRequestHandler<DeleteHumanCommand>
    {
        private readonly IWebDbContext _webDbContext;

        public DeleteHumanCommandHandler(IWebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public async Task<Unit> Handle(DeleteHumanCommand request, CancellationToken cancellationToken)
        {
            var human = await _webDbContext.Persons.FindAsync(new object[] { request.Id }, cancellationToken);
            if (human == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);

            }
            _webDbContext.Persons.Remove(human);
            await _webDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
