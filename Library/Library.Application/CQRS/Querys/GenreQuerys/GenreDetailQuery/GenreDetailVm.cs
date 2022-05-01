using AutoMapper;
using Library.Application.Interfaces;
using Library.Domain;

namespace Library.Application.CQRS.Querys.GenreQuerys.GenreDetailQuery
{
    public class GenreDetailVm:IMapWith<Genre>
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Genre, GenreDetailVm>()
                .ForMember(x => x.Id,
                opt => opt.MapFrom(model => model.Id))
                .ForMember(x => x.GenreName,
                opt => opt.MapFrom(model => model.GenreName));
        }
    }
}
