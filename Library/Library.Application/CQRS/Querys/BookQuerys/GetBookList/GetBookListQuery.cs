using Library.Application.Interfaces;
using MediatR;

namespace Library.Application.CQRS.Querys.BookQuerys.GetBookList
{
    public class GetBookListQuery : IRequest<BookListVm>, ICacheable
    {
        public int? AuthorId { get; set; }
        public string BookName { get; set; }
        public string BookGenre { get; set; }
        public string CacheKey { get; set; }
    }
}
