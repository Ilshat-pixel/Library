using AutoMapper;
using Library.Application.CQRS.Commands.BookCommands.CreateBook;
using Library.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Library.API.Controllers.Models.Book
{
    public class CreateBookDto:IMapWith<CreateBookCommand>
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public string Genre { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBookDto, CreateBookCommand>()
                .ForMember(bookCommand => bookCommand.AuthorId,
                opt => opt.MapFrom(bookDto => bookDto.AuthorId))
                .ForMember(bookCommand => bookCommand.Genre,
                opt => opt.MapFrom(bookDto => bookDto.Genre))
                .ForMember(bookCommand => bookCommand.Title,
                opt => opt.MapFrom(bookDto => bookDto.Title));
        }
    }
}
