using MediatR;

namespace Library.Application.CQRS.Querys.PersonQuerys.GetAllTakenBooksByPersonId
{
    public class GetAllTakenBooksByPersonIdCommand:IRequest<TakenBooksListVm>
    {
        public int Id { get; set; }
    }
}
