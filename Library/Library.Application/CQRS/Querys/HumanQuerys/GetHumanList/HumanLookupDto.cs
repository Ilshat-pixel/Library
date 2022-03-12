using AutoMapper;
using Library.Application.Interfaces;
using Library.Domain;
using System;
using System.Collections.Generic;

namespace Library.Application.CQRS.Querys.HumanQuerys.GetHumanList
{
    public class HumanLookupDto : IMapWith<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<Book> Books { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Person, HumanLookupDto>()
                .ForMember(humanDto => humanDto.Id,
                opt => opt.MapFrom(human => human.Id))
                .ForMember(humanDto => humanDto.Name,
                opt => opt.MapFrom(human => human.FirstName))
                .ForMember(humanDto => humanDto.Birthday,
                opt => opt.MapFrom(human => human.Birthday))
                .ForMember(humanDto => humanDto.Patronymic,
                opt => opt.MapFrom(human => human.MiddleName))
                .ForMember(humanDto => humanDto.Surname,
                opt => opt.MapFrom(human => human.Surname))
                .ForMember(humanDto => humanDto.Books,
                opt => opt.MapFrom(human => human.Books));
        }
    }
}
