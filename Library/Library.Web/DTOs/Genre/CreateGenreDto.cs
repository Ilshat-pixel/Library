using AutoMapper;
using Library.Application.CQRS.Commands.GenreCommands.CreateGenre;
using Library.Application.Interfaces;

namespace Library.Web.DTOs.Genre
{
    public class CreateGenreDto : IMapWith<CreateGenreCommand>
    {
        public string GenreName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateGenreDto, CreateGenreCommand>()
                .ForMember(command => command.GenreName,
                opt => opt.MapFrom(dto => dto.GenreName));
        }
    }
}
