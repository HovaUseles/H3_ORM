using System;
using System.Collections.Generic;

namespace H3_ORM___Database_first.Models;

public partial class Ebook
{
    public int BookId { get; set; }

    public string? Version { get; set; }

    public string? DownloadLink { get; set; }

    public virtual Book Book { get; set; } = null!;
}
