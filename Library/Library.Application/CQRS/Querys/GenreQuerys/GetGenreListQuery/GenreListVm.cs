using System.Collections.Generic;

namespace Library.Application.CQRS.Querys.GenreQuerys.GetGenreListQuery
{
    public class GenreListVm
    {
        public IList<GenreLookupDto>  Genres {get;set;}
    }
}
