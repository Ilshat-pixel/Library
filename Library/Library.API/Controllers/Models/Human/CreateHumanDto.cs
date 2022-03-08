﻿using AutoMapper;
using Library.Application.CQRS.Commands.HumanCommands.CreateHuman;
using Library.Application.Interfaces;
using System;

namespace Library.API.Controllers.Models.Human
{
    public class CreateHumanDto:IMapWith<CreateHumanCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateHumanDto, CreateHumanCommand>()
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
