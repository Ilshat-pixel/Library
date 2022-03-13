using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain
{
    public class BookGenre
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public int GenreId { get; set; }
    //    public virtual Genre Genre { get; set; }
    }
}
