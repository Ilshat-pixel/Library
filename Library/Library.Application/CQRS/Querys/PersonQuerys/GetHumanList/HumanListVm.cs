using System.Collections.Generic;

namespace Library.Application.CQRS.Querys.HumanQuerys.GetHumanList
{
    public class HumanListVm
    {
        public IList<PersonLookupDto> Humans { get; set; }
    }
}
