using System;
using System.Collections.Generic;

namespace H3_ORM_GUI.Models;

public partial class Ebook
{
    public int BookId { get; set; }

    public string? Version { get; set; }

    public string? DownloadLink { get; set; }

    public virtual Book Book { get; set; } = null!;
}
