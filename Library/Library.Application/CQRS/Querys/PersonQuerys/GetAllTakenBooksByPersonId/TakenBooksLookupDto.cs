using AutoMapper;
using Library.Application.Interfaces;
using Library.Domain;
using System.Collections.Generic;

namespace Library.Application.CQRS.Querys.PersonQuerys.GetAllTakenBooksByPersonId
{
    public class TakenBooksLookupDto : IMapWith<Book>
    {
        public string Name { get; set; }
        public AuthorVm Author { get; set; }
        public IList<GenreLookupDto> Genres { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, TakenBooksLookupDto>()
                .ForMember(dto=>dto.Name,
                opt=>opt.MapFrom(b=>b.Name))
                .ForMember(dto => dto.Author,
                opt => opt.MapFrom(b => b.Author))
                .ForMember(dto => dto.Genres,
                opt => opt.MapFrom(b => b.Genres));
        }
    }
}
