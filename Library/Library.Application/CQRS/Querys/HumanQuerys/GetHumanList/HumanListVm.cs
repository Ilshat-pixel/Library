using System.Collections.Generic;

namespace Library.Application.CQRS.Querys.HumanQuerys.GetHumanList
{
    public class HumanListVm
    {
        public IList<HumanLookupDto> Humans { get; set; }
    }
}
