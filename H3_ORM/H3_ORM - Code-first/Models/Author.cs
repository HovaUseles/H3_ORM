namespace H3_ORM___Code_first.Models
{
    internal class Author : Person
    {
        public string Biography { get; set; } = null!;
        public string Genre { get; set; } = null!;
    }
}
