using AutoMapper;
using Library.Application.CQRS.Commands.LibraryCardCommands.CreateCommand;
using Library.Application.Interfaces;

namespace Library.Web.DTOs.LibraryCard
{
    public class LibraryCardDto : IMapWith<CreateLibraryCardCommand>
    {
        public int HumanId { get; set; }
        public int BookId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<LibraryCardDto, CreateLibraryCardCommand>()
                .ForMember(cardCommand => cardCommand.PersonId,
                opt => opt.MapFrom(cardDto => cardDto.HumanId))
                .ForMember(cardCommand => cardCommand.BookId,
                opt => opt.MapFrom(cardDto => cardDto.BookId));

        }
    }
}
