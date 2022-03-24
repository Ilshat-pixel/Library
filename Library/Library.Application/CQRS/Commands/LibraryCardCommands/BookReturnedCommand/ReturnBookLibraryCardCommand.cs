﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.LibraryCardCommands.BookReturnedCommand
{
    public class ReturnBookLibraryCardCommand : IRequest
    {
        public int Id { get; set; }
    }
}