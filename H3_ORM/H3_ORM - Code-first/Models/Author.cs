using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_ORM___Code_first.Models
{
    internal class Author : Person
    {
        public string Biography { get; set; }
        public string Genre { get; set; }
    }
}
