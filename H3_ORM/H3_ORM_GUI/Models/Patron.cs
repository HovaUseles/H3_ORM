using System;
using System.Collections.Generic;

namespace H3_ORM_GUI.Models;

public partial class Patron
{
    public int PersonId { get; set; }

    public DateTime? MembershipExpiryDate { get; set; }

    public int PhoneNumber { get; set; }

    public string Address { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
