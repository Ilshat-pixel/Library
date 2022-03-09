using AutoMapper;
using Library.Application.CQRS.Commands.LibraryCardCommands.CreateCommand;
using Library.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.API.Models.LibraryCard
{
    public class LibraryCardDto : IMapWith<CreateLibraryCardCommand>
    {
        public int HumanId { get; set; }
        public int BookId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<LibraryCardDto, CreateLibraryCardCommand>()
                .ForMember(cardCommand => cardCommand.HumanId,
                opt => opt.MapFrom(cardDto => cardDto.HumanId))
                .ForMember(cardCommand => cardCommand.BookId,
                opt => opt.MapFrom(cardDto => cardDto.BookId));

        }
    }
}
