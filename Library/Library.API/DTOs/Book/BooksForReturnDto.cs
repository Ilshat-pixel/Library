using AutoMapper;
using Library.Application.CQRS.Commands.LibraryCardCommands.BookReturnedCommand;
using Library.Application.Interfaces;
using System.Collections.Generic;

namespace Library.API.DTOs.Book
{
    public class BooksForReturnDto:IMapWith<ReturnBookLibraryCardCommand>
    {
        public int PersonId { get; set; }
        public IList<string> BooksNames { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<BooksForReturnDto, ReturnBookLibraryCardCommand>()
                .ForMember(command => command.PersonId,
                opt => opt.MapFrom(dto => dto.PersonId))
                .ForMember(command => command.BookTitles,
                opt => opt.MapFrom(dto => dto.BooksNames));
        }
    }
}
