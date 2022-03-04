﻿using AutoMapper;
using Library.Application.Interfaces;
using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Querys.BookQuerys.GetBookList
{
    public class BookLookupDto:IMapWith<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Human Author { get; set; }
        //TODO: думаю стоит выкинуть в отдельную таблицу жанры, пока не буду усложнять
        public string Genre { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookLookupDto>()
                .ForMember(bookDto => bookDto.Id,
                opt => opt.MapFrom(book => book.Id))
                  .ForMember(bookDto => bookDto.Title,
                opt => opt.MapFrom(book => book.Title))
                    .ForMember(bookDto => bookDto.Author,
                opt => opt.MapFrom(book => book.Author))
                      .ForMember(bookDto => bookDto.Genre,
                opt => opt.MapFrom(book => book.Genre));
        }
    }
}