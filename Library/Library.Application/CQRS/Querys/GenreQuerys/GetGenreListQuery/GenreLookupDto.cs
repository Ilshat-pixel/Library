using AutoMapper;
using Library.Application.Interfaces;
using Library.Domain;

namespace Library.Application.CQRS.Querys.GenreQuerys.GetGenreListQuery
{
    public class GenreLookupDto:IMapWith<Genre>
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Genre, GenreLookupDto>()
                .ForMember(x => x.Id,
                opt => opt.MapFrom(g => g.Id))
                .ForMember(d => d.GenreName,
                opt => opt.MapFrom(g => g.GenreName));
        }

    }
}
