using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain
{
    public class LibraryCard
    {
        public int Id { get; set; }
        public Human Human { get; set; }
        public string DateOfIssue { get; set; }
    }
}
