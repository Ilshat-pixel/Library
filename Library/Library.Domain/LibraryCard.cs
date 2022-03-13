using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain
{
    public class LibraryCard
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public DateTimeOffset Date { get; set; }
        public int StatusId { get; set; }
        public virtual LibraryCardStatus Status { get; set; }
    }
}
