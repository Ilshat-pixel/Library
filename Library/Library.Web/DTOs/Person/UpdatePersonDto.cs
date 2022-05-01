using AutoMapper;
using Library.Application.CQRS.Commands.PersonCommands.UpdatePerson;
using Library.Application.Interfaces;
using System;

namespace Library.Web.DTOs.Person
{
    public class UpdatePersonDto : IMapWith<UpdatePersonCommand>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset Birthday { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePersonDto, UpdatePersonCommand>()
                .ForMember(dto => dto.Id,
                opt => opt.MapFrom(p => p.Id))
                .ForMember(dto => dto.FirstName,
                opt => opt.MapFrom(p => p.FirstName))
                .ForMember(dto => dto.LastName,
                opt => opt.MapFrom(p => p.LastName))
                .ForMember(dto => dto.MiddleName,
                opt => opt.MapFrom(p => p.MiddleName))
                .ForMember(dto => dto.Birthday,
                opt => opt.MapFrom(p => p.Birthday));

        }
    }
}
