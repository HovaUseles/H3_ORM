using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_ORM___Code_first.Models
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<EBook> EBooks { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Patron> Patrons { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
