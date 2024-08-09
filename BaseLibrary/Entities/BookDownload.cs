namespace BaseLibrary.Entities
{
    public class BookDownload : BaseEntity
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateOnly DownloadedAt { get; set; }
        public Book? Book { get; set; }
        public User? User { get; set; }
    }
}
