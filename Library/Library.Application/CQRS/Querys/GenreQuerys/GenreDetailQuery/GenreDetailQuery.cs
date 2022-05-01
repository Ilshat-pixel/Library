using MediatR;

namespace Library.Application.CQRS.Querys.GenreQuerys.GenreDetailQuery
{
    public class GenreDetailQuery:IRequest<GenreDetailVm>
    {
        public int Id { get; set; }
    }
}
