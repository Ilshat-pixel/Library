using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Querys.BookQuerys.GetBooksByGenre
{
    public class BooksByGenreVm
    {
        public IList<BooksByGenreLookupDto> Books { get; set; }
    }
}
