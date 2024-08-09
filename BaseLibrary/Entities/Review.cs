namespace BaseLibrary.Entities
{
    public class Review : BaseEntity
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public float Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }


        public Book? Book { get; set; }
        public ApplicationUser? User { get; set; }

    }
}
