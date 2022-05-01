using AutoMapper;
using Library.Application.Interfaces;
using Library.Domain;

namespace Library.Application.CQRS.Querys.AuhtorsQuerys.AuthorDetailQuery
{
    public class AuthorDetailVm : IMapWith<Author>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorDetailVm>()
                .ForMember(x => x.Id,
                opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.FirstName,
                opt => opt.MapFrom(model => model.FirstName))
                .ForMember(x => x.LastName,
                opt => opt.MapFrom(model => model.LastName))
                .ForMember(x => x.MiddleName,
                opt => opt.MapFrom(model => model.MiddleName));
        }
    }
}
