﻿using AutoMapper;
using Library.Application.CQRS.Querys.AuhtorsQuerys;
using Library.Application.CQRS.Querys.GenreQuerys.GetGenreListQuery;
using Library.Application.Interfaces;
using Library.Domain;
using System.Collections.Generic;

namespace Library.Application.CQRS.Querys.BookQuerys.GetBookList
{
    public class BookLookupDto : IMapWith<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AuthorLookupDto Author { get; set; }
        public ICollection<GenreLookupDto> Genres { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookLookupDto>()
                  .ForMember(bookDto => bookDto.Id,
                opt => opt.MapFrom(book => book.Id))
                  .ForMember(bookDto => bookDto.Title,
                opt => opt.MapFrom(book => book.Name))
                    .ForMember(bookDto => bookDto.Author,
                opt => opt.MapFrom(book => book.Author))
                  .ForMember(bookDto => bookDto.Genres,
                opt => opt.MapFrom(book => book.Genres));
        }
    }

}
