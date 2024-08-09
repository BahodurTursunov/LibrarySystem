namespace BaseLibrary.Entities
{
    public class Book : BaseEntity
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public int GenreId { get; set; }
        public DateOnly YearPublished { get; set; }
        public string? ISBN { get; set; }
        public string? Descrtiption { get; set; }
        public string? CoverImagePath { get; set; }
        public string? FilePath { get; set; }
        public float Rating { get; set; }

        // Navigation Properties
        public Genre? Genre { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<BookDownload>? BookDownloads { get; set; }
    }
}
