using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace H3_ORM___Database_first.Models;

public partial class LibraryManagementDataBaseFirstContext : DbContext
{

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(b => b.Navigation(b => b.Author).AutoInclude());
        modelBuilder.Entity<Book>(b => b.Navigation(b => b.Ebook).AutoInclude());
        
        //modelBuilder.Entity<Person>(b => b.Navigation(b => b.Patron).AutoInclude());
        //modelBuilder.Entity<Person>(b => b.Navigation(b => b.Author).AutoInclude());

        modelBuilder.Entity<Author>(b => b.Navigation(b => b.Books).AutoInclude());
        modelBuilder.Entity<Author>(b => b.Navigation(b => b.Person).AutoInclude());

        modelBuilder.Entity<Patron>(b => b.Navigation(b => b.Person).AutoInclude());
        modelBuilder.Entity<Patron>(b => b.Navigation(b => b.Books).AutoInclude());
    }
}
