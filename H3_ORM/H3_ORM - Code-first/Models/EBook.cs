namespace H3_ORM___Code_first.Models
{
    internal class EBook : Book
    {
        public string Version { get; set; } = null!;
        public string DownloadLink { get; set; } = null!;
    }
}
