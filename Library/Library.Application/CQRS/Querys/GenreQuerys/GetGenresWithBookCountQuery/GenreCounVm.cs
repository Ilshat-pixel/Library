﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Querys.GenreQuerys.GetGenresWithBookCountQuery
{
    public class GenreCounVm
    {
        public IList<GenreCountDto> GenreCounts { get; set; }
    }
}