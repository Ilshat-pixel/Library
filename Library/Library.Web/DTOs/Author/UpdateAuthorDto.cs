using System.Collections.Generic;
using AutoMapper;
using Library.Application.CQRS.Commands.AuthorCommands.UpdateAuthorCommand;
using Library.Application.Interfaces;
using Library.Web.DTOs.Book;

namespace Library.Web.DTOs.Author
{
    public class UpdateAuthorDto : IMapWith<UpdateAuthorCommand>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public IList<CreateBookDto> Books { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAuthorDto, UpdateAuthorCommand>()
                .ForMember(command => command.Id,
                opt => opt.MapFrom(dto => dto.Id))
                .ForMember(command => command.FirstName,
                opt => opt.MapFrom(dto => dto.FirstName))
                .ForMember(command => command.MiddleName,
                opt => opt.MapFrom(dto => dto.MiddleName))
                .ForMember(command => command.LastName,
                opt => opt.MapFrom(dto => dto.LastName))
                .ForMember(command => command.Books,
                opt => opt.MapFrom(dto => dto.Books));

        }
    }
}
