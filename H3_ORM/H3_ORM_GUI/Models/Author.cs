using System;
using System.Collections.Generic;

namespace H3_ORM_GUI.Models;

public partial class Author
{
    public int PersonId { get; set; }

    public string Genre { get; set; } = null!;

    public string? Biography { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual Person Person { get; set; } = null!;
}
