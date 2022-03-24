using Library.Application.Interfaces;
using MediatR;

namespace Library.Application.CQRS.Querys.HumanQuerys.GetHumanList
{
    public class GetHumanListQuery : IRequest<HumanListVm>, ICacheable
    {
        public bool? IsAuthor { get; set; }
        public string SearchString { get; set; }
        public string CacheKey { get; set; }
    }
}
