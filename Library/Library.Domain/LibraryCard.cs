﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
