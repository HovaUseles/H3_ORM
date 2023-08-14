using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace H3_ORM___Database_first.Models;

public partial class LibraryManagementDatabaseFirstContext : DbContext
{
    public LibraryManagementDatabaseFirstContext()
    {
    }

    public LibraryManagementDatabaseFirstContext(DbContextOptions<LibraryManagementDatabaseFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Ebook> Ebooks { get; set; }

    public virtual DbSet<Patron> Patrons { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Library_Management_Database-first");

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
