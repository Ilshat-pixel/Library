using MediatR;

namespace Library.Application.CQRS.Querys.AuhtorsQuerys.AuthorDetailQuery
{
    public class AuthorDetailQuery:IRequest<AuthorDetailVm>
    {
        public int Id { get; set; }
    }
}
