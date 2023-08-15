using System.ComponentModel.DataAnnotations;

namespace H3_ORM___Code_first.Models
{
    internal class Book
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(75)]
        public string Title { get; set; } = null!;

        [MaxLength(25)]
        public string Genre { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        public Author Author { get; set; } = null!;

        public Patron? Patron { get; set; }
    }
}
