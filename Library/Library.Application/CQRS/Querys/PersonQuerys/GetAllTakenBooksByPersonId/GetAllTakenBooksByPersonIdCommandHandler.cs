﻿using AutoMapper;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Querys.PersonQuerys.GetAllTakenBooksByPersonId
{
    //public class GetAllTakenBooksByPersonIdCommandHandler:IRequestHandler<GetAllTakenBooksByPersonIdCommand,TakenBooksListVm>
    //{
    //    private readonly IWebDbContext _webDbContext;
    //    private readonly IMapper _mapper;

    //    public GetAllTakenBooksByPersonIdCommandHandler(IWebDbContext webDbContext, IMapper mapper)
    //    {
    //        _webDbContext = webDbContext;
    //        _mapper = mapper;
    //    }

    //    public Task<TakenBooksListVm> Handle(GetAllTakenBooksByPersonIdCommand request, CancellationToken cancellationToken)
    //    {
    //        //TODO: явно составлено не оптимально, спросить как выполнить правильно
    //        var books =  db
    //    }
    //}
}