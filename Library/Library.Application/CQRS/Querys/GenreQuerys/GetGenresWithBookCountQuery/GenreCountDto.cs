using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Querys.GenreQuerys.GetGenresWithBookCountQuery
{
    public class GenreCountDto
    {
        public string GenreName { get; set; }
        public int Count { get; set; }
    }
}
