using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Library.Application.CQRS.Commands.GenreCommands.UpdateGenre;
using Library.Application.Interfaces;

namespace Library.Web.DTOs.Genre
{
    public class UpdateGenreDto : IMapWith<UpdateGenreCommand>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateGenreDto, UpdateGenreCommand>()
                .ForMember(command => command.Id,
                opt => opt.MapFrom(dto => dto.Id))
                .ForMember(command => command.Name,
                opt => opt.MapFrom(dto => dto.Name));
        }
    }
}
