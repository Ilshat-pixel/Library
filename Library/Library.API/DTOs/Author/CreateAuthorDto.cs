using AutoMapper;
using Library.API.DTOs.Book;
using Library.Application.CQRS.Commands.AuthorCommands.CreateAuthorCommand;
using Library.Application.Interfaces;
using System.Collections.Generic;

namespace Library.API.DTOs.Author
{
    public class CreateAuthorDto:IMapWith<CreateAuthorDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public IList<CreateBookDto> Books {get;set;}
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAuthorDto, CreateAuthorCommand>()
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
