using AutoMapper;
using Library.Application.Interfaces;
using Library.Domain;

namespace Library.Application.CQRS.Querys.PersonQuerys.GetAllTakenBooksByPersonId
{
    public  class GenreLookupDto : IMapWith<Genre>
    {
        public string GenreName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Genre,GenreLookupDto>()
                .ForMember(dto=>dto.GenreName,
                opt=>opt.MapFrom(g=>g.GenreName));
        }
    }
}