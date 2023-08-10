using BookStore.Data.Configurations;
using BookStore.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;
using System.Reflection;

namespace BookStore.Data
{
    public class BookStoreDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options, bool v)
            : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<Review> Reviews { get; set; } = null!;

        public DbSet<FavoriteAuthorUser> FavoriteAuthorsUsers { get; set; } = null!;

        public DbSet<FavoriteUserBook> FavoriteUsersBooks { get; set; }= null!;

        public DbSet<UserBookBought> UsersBoughtBooks { get; set; }= null!;

        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FavoriteAuthorUser>()
                .HasKey(f => new { f.UserId, f.AuthorId });

            builder.Entity<UserBookBought>()
                .HasKey(b => new { b.UserId, b.BookId });

            builder.Entity<FavoriteUserBook>()
                .HasKey(u => new {u.UserId, u.BookId });

            builder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne(c => c.Cart)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Cart)
                .WithOne(u => u.User)
                .OnDelete(DeleteBehavior.Restrict);

            EntitySeedDataConfiguration.Seed(builder);

            base.OnModelCreating(builder);
        }
    }
}