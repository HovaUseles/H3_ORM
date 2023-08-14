using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_ORM___Code_first.Models
{
    internal class EBook : Book
    {
        public string Version { get; set; }
        public string DownloadLink { get; set; }
    }
}
