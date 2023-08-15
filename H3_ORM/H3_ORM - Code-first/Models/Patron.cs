namespace H3_ORM___Code_first.Models
{
    internal class Patron : Person
    {
        public DateTime? MembershipExpiryDate { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
