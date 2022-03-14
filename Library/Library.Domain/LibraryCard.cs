using System;

namespace Library.Domain
{
    public class LibraryCard
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public DateTimeOffset TakeDate { get; set; }
        public bool IsReterned { get; set; }
        public DateTimeOffset? ReturnDate { get; set; }

        //public int StatusId { get; set; }
        //public virtual LibraryCardStatus Status { get; set; }
    }
}
