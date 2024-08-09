namespace BaseLibrary.Entities
{
    public class ApplicationUser : BaseEntity
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public DateTime RegisteredAt { get; set; }
        public string? IsBlocked { get; set; }

        // Navigation Properties
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<BookDownload>? BookDownloads { get; set; }
    }
}
