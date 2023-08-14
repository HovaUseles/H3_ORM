using System;
using System.Collections.Generic;

namespace H3_ORM_Data___Database_first.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string? Title { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public string? Genre { get; set; }

    public int? AuthorId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual Ebook? Ebook { get; set; }
}
