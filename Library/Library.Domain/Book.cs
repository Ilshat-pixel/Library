using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain
{
    /// <summary>
    /// 1.2.2 - Анемичная модель для БД Книги
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<LibraryCard> LibraryCards { get; set; }
        public virtual ICollection<BookGenre> BookGenres { get; set; }
    }
}
