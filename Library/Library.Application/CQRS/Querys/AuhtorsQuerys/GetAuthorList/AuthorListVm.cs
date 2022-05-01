using System.Collections.Generic;

namespace Library.Application.CQRS.Querys.AuhtorsQuerys
{
    public class AuthorListVm
    {
        public  IList<AuthorLookupDto> Authors { get; set; }
    }
}
