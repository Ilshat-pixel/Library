using System.Collections.Generic;

namespace Library.Application.CQRS.Querys.BookQuerys.GetBookList
{
    public class BookListVm
    {
        public IList<BookLookupDto> Books { get; set; }
    }
}
