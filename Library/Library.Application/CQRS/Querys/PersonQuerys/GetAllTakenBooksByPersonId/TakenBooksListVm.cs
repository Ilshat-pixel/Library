﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Querys.PersonQuerys.GetAllTakenBooksByPersonId
{
    public class TakenBooksListVm
    {
        public IList<TakenBooksLookupDto>Books { get; set; }
    }
}
