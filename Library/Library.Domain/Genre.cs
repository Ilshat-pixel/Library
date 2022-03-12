using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string GenreName { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
