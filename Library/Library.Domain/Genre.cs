using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
