using Library.Application.Interfaces;
using Library.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Persistence
{
    public class WebDbContext : DbContext, IWebDbContext
    {
        public WebDbContext( DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Human> Humans { get ; set ; }

    }
}
