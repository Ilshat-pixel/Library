using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Querys.BookQuerys.GetBookList
{
    public class BookListVm
    {
        public IList<BookLookupDto> Books { get; set; }    
    }
}
