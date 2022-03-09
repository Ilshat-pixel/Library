using AutoMapper;
using Library.Application.CQRS.Commands.BookCommands.CreateBook;
using Library.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Library.API.Controllers.Models.Book
{
    public class CreateBookDto:IMapWith<CreateBookCommand>
    {
    
        public string Title { get; set; }
     
        public int AuthorId { get; set; }
   
        public int GenreId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBookDto, CreateBookCommand>()
                .ForMember(bookCommand => bookCommand.AuthorId,
                opt => opt.MapFrom(bookDto => bookDto.AuthorId))
                .ForMember(bookCommand => bookCommand.GenreId,
                opt => opt.MapFrom(bookDto => bookDto.GenreId))
                .ForMember(bookCommand => bookCommand.Title,
                opt => opt.MapFrom(bookDto => bookDto.Title));
             
        }
    }
}
