using System.Collections.Generic;

namespace Library.Application.CQRS.Querys.AuhtorsQuerys.GetAuthorList
{
    public class GetAuthorListQueryVm
    {
        public  IList<AuthorLookupDto> Authors { get; set; }
    }
}
