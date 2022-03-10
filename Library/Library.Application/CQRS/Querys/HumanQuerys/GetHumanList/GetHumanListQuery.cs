using Library.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Querys.HumanQuerys.GetHumanList
{
    public class GetHumanListQuery : IRequest<HumanListVm>, ICacheable
    {
        public bool? IsAuthor { get; set; }
        public string SearchString { get; set; }
        public string CacheKey { get; set; }
    }
}
