﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.GenreCommands.CreateGenre
{
    public class CreateGenreCommand:IRequest<int>
    {
        public string GenreName { get; set; }
    }
}
