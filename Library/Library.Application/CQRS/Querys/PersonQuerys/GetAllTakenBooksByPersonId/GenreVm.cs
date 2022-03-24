using System.Collections.Generic;

namespace Library.Application.CQRS.Querys.PersonQuerys.GetAllTakenBooksByPersonId
{
    public class GenreVm
    {
        public IList<GenreLookupDto> Genres { get; set; }
    }
}