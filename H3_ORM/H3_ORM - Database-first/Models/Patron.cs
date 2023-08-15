using System;
using System.Collections.Generic;

namespace H3_ORM___Database_first.Models;

public partial class Patron
{
    public int PersonId { get; set; }

    public DateTime? MembershipExpiryDate { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
