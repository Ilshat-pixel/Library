using AutoMapper;
using Library.Application.CQRS.Commands.PersonCommands.CreatePerson;
using Library.Application.Interfaces;
using System;

namespace Library.Web.DTOs.Person
{
    /// <summary>
    /// 1.2.1 Класс презентующий человека
    /// </summary>
    public class CreatePersonDto : IMapWith<CreatePersonCommand>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePersonDto, CreatePersonCommand>()
                .ForMember(humanCommand => humanCommand.Name,
                opt => opt.MapFrom(humanDto => humanDto.Name))
                .ForMember(humanCommand => humanCommand.Birthday,
                opt => opt.MapFrom(humanDto => humanDto.Birthday))
                .ForMember(humanCommand => humanCommand.Surname,
                opt => opt.MapFrom(humanDto => humanDto.Surname))
                .ForMember(humanCommand => humanCommand.Patronymic,
                opt => opt.MapFrom(humanDto => humanDto.Patronymic))
                .ForMember(humanCommand => humanCommand.Birthday,
                opt => opt.MapFrom(humanDto => humanDto.Birthday));

        }

    }
}
