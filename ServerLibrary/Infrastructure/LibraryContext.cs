using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace ServerLibrary.Infrastructure
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookDownload> BookDownloads { get; set; }
        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<RefreshTokenInfo> RefreshTokenInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User Configuration
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.BookDownloads)
                .WithOne(bd => bd.User)
                .HasForeignKey(bd => bd.UserId);

            // Book Configuration
            modelBuilder.Entity<Book>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Reviews)
                .WithOne(r => r.Book)
                .HasForeignKey(r => r.BookId);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.BookDownloads)
                .WithOne(bd => bd.Book)
                .HasForeignKey(bd => bd.BookId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId);

            // Review Configuration
            modelBuilder.Entity<Review>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BookId);

            // Genre Configuration
            modelBuilder.Entity<Genre>()
                .HasKey(g => g.Id);

            modelBuilder.Entity<Genre>()
                .HasMany(g => g.Books)
                .WithOne(b => b.Genre)
                .HasForeignKey(b => b.GenreId);

            // BookDownload Configuration
            modelBuilder.Entity<BookDownload>()
                .HasKey(bd => bd.Id);

            modelBuilder.Entity<BookDownload>()
                .HasOne(bd => bd.User)
                .WithMany(u => u.BookDownloads)
                .HasForeignKey(bd => bd.UserId);

            modelBuilder.Entity<BookDownload>()
                .HasOne(bd => bd.Book)
                .WithMany(b => b.BookDownloads)
                .HasForeignKey(bd => bd.BookId);
        }
    }

}
