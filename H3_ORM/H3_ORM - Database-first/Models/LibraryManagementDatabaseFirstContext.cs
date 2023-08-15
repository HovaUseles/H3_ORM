using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace H3_ORM___Database_first.Models;

public partial class LibraryManagementDataBaseFirstContext : DbContext
{
    public LibraryManagementDataBaseFirstContext()
    {
    }

    public LibraryManagementDataBaseFirstContext(DbContextOptions<LibraryManagementDataBaseFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Ebook> Ebooks { get; set; }

    public virtual DbSet<Patron> Patrons { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.PersonId);

            entity.Property(e => e.PersonId).ValueGeneratedNever();
            entity.Property(e => e.Biography).HasMaxLength(500);
            entity.Property(e => e.Genre).HasMaxLength(25);

            entity.HasOne(d => d.Person).WithOne(p => p.Author)
                .HasForeignKey<Author>(d => d.PersonId)
                .HasConstraintName("FK_Authors_Persons");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.Genre).HasMaxLength(25);
            entity.Property(e => e.ReleaseDate).HasColumnType("date");
            entity.Property(e => e.Title).HasMaxLength(75);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Books_Author");

            entity.HasMany(d => d.Patrons).WithMany(p => p.Books)
                .UsingEntity<Dictionary<string, object>>(
                    "PatronsBook",
                    r => r.HasOne<Patron>().WithMany()
                        .HasForeignKey("PatronId")
                        .HasConstraintName("FK_Patrons"),
                    l => l.HasOne<Book>().WithMany()
                        .HasForeignKey("BookId")
                        .HasConstraintName("FK_Books"),
                    j =>
                    {
                        j.HasKey("BookId", "PatronId").HasName("PK_PatronsBookS");
                        j.ToTable("Patrons_Books");
                    });
        });

        modelBuilder.Entity<Ebook>(entity =>
        {
            entity.HasKey(e => e.BookId);

            entity.ToTable("EBooks");

            entity.Property(e => e.BookId).ValueGeneratedNever();
            entity.Property(e => e.DownloadLink).HasMaxLength(200);
            entity.Property(e => e.Version).HasMaxLength(5);

            entity.HasOne(d => d.Book).WithOne(p => p.Ebook)
                .HasForeignKey<Ebook>(d => d.BookId)
                .HasConstraintName("FK_EBooks_Books");
        });

        modelBuilder.Entity<Patron>(entity =>
        {
            entity.HasKey(e => e.PersonId);

            entity.Property(e => e.PersonId).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.MembershipExpiryDate).HasColumnType("date");
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);

            entity.HasOne(d => d.Person).WithOne(p => p.Patron)
                .HasForeignKey<Patron>(d => d.PersonId)
                .HasConstraintName("FK_Patrons_Persons");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.Name).HasMaxLength(75);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
