using AutoMapper;
using Library.Application.CQRS.Commands.BookCommands.CreateBook;
using Library.Application.Interfaces;
using System.Collections.Generic;

namespace Library.API.DTOs.Book
{
    /// <summary>
    /// 1.2.2 Класс презентующий книгу
    /// </summary>
    public class CreateBookDto : IMapWith<CreateBookCommand>
    {

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public IList<int> GenreIds { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBookDto, CreateBookCommand>()
                .ForMember(bookCommand => bookCommand.AuthorId,
                opt => opt.MapFrom(bookDto => bookDto.AuthorId))
                .ForMember(bookCommand => bookCommand.GenreIds,
                opt => opt.MapFrom(bookDto => bookDto.GenreIds))
                .ForMember(bookCommand => bookCommand.Title,
                opt => opt.MapFrom(bookDto => bookDto.Title));

        }
    }
}
