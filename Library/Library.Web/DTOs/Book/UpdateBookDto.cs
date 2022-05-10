using AutoMapper;
using Library.Application.CQRS.Commands.BookCommands.UpdateBook;
using Library.Application.Interfaces;

namespace Library.Web.DTOs.Book
{
    public class UpdateBookDto:IMapWith<UpdateBookCommand>
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int AuthorId { get; set; }

        public int GenreId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBookDto, UpdateBookCommand>()
                .ForMember(bookCommand => bookCommand.AuthorId,
                opt => opt.MapFrom(bookDto => bookDto.AuthorId))
                .ForMember(bookCommand => bookCommand.GenreId,
                opt => opt.MapFrom(bookDto => bookDto.GenreId))
                .ForMember(bookCommand => bookCommand.Name,
                opt => opt.MapFrom(bookDto => bookDto.Title))
                .ForMember(bookCommand => bookCommand.Id,
                opt => opt.MapFrom(bookDto => bookDto.Id));

        }
    }
}
