using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain
{
    /// <summary>
    /// 1.2.1 - Анемичная модель человека для БД
    /// </summary>
    public class Human
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTimeOffset Birthday { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<LibraryCard> LibraryCards { get; set; }

    }
}
