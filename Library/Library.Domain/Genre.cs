using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
