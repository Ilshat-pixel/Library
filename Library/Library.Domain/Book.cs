using System.Collections.Generic;

namespace Library.Domain
{
    /// <summary>
    /// 1.2.2 - Анемичная модель для БД Книги
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Human Author { get; set; }
        public ICollection<LibraryCard> Cards { get; set; }
        public Genre Genre { get; set; }
    }
}
