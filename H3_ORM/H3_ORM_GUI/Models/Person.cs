using System;
using System.Collections.Generic;

namespace H3_ORM_GUI.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public int Age { get; set; }

    public string Name { get; set; } = null!;

    public virtual Author? Author { get; set; }

    public virtual Patron? Patron { get; set; }
}
