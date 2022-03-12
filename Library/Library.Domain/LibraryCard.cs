using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain
{
    public class LibraryCard
    {
        [Key]
        public int Id { get; set; }
        public int HumanId { get; set; }
        public Person Human { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTimeOffset DateOfIssue { get; set; }

    }
}
