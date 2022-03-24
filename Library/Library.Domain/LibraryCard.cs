using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain
{
    public class LibraryCard
    {
        [Key]
        public int Id { get; set; }
        public Human Human { get; set; }
        public Book Book { get; set; }
        public DateTimeOffset DateOfIssue { get; set; }

    }
}
