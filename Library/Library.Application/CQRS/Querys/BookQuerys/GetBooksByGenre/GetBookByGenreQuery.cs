using MediatR;

namespace Library.Application.CQRS.Querys.BookQuerys.GetBooksByGenre
{
    public class GetBookByGenreQuery:IRequest<BooksByGenreVm>
    {
        public int Id { get; set; }
    }
}
