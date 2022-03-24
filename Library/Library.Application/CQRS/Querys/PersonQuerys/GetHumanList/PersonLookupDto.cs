using AutoMapper;
using Library.Application.Interfaces;
using Library.Domain;
using System;
using System.Collections.Generic;

namespace Library.Application.CQRS.Querys.HumanQuerys.GetHumanList
{
    public class PersonLookupDto : IMapWith<Person>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Person, PersonLookupDto>()
                .ForMember(humanDto => humanDto.Id,
                opt => opt.MapFrom(human => human.Id))
                .ForMember(humanDto => humanDto.FirstName,
                opt => opt.MapFrom(human => human.FirstName))
                .ForMember(humanDto => humanDto.Birthday,
                opt => opt.MapFrom(human => human.Birthday))
                .ForMember(humanDto => humanDto.LastName,
                opt => opt.MapFrom(human => human.MiddleName))
                .ForMember(humanDto => humanDto.MiddleName,
                opt => opt.MapFrom(human => human.MiddleName));
               
        }
    }
}
