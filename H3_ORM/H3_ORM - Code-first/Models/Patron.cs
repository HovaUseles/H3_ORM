using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_ORM___Code_first.Models
{
    internal class Patron : Person
    {
        public DateTime MembershipExpiryDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
