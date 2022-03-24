using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain
{
    /// <summary>
    /// 1.2.1 - Анемичная модель человека для БД
    /// </summary>
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTimeOffset Birthday { get; set; }
        public virtual ICollection<LibraryCard> LibraryCards { get; set; }

    }
}
