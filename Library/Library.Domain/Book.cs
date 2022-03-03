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
        //TODO: думаю стоит выкинуть в отдельную таблицу жанры, пока не буду усложнять
        public string Genre { get; set; }
    }
}
