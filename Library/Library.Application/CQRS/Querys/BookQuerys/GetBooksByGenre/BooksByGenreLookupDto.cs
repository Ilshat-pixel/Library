using AutoMapper;
using Library.Application.CQRS.Querys.PersonQuerys.GetAllTakenBooksByPersonId;
using Library.Application.Interfaces;
using Library.Domain;
using System.Collections.Generic;

namespace Library.Application.CQRS.Querys.BookQuerys.GetBooksByGenre
{
    public class BooksByGenreLookupDto:IMapWith<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AuthorVm Author { get; set; }
        public IList<GenreLookupDto> Genres { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BooksByGenreLookupDto>()
                .ForMember(dto => dto.Id,
                opt => opt.MapFrom(x => x.Id))
                .ForMember(dto => dto.Title,
                opt => opt.MapFrom(x => x.Name))
                .ForMember(dto => dto.Author,
                opt => opt.MapFrom(x => x.Author))
                .ForMember(dto => dto.Genres,
                opt => opt.MapFrom(x => x.Genres));

        }
    }
}
