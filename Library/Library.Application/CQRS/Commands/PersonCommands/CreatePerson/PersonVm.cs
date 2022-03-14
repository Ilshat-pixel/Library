using AutoMapper;
using Library.Application.Interfaces;
using Library.Domain;
using System;

namespace Library.Application.CQRS.Commands.PersonCommands.CreatePerson
{
    public class PersonVm : IMapWith<Person>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
       
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Person, PersonVm>()
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
