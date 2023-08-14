using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_ORM___Code_first.Models
{
    internal class Book
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(75)]
        public string Title { get; set; }

        [MaxLength(25)]
        public string Genre { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
