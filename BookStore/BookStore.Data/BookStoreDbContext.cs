using BookStore.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookStore.Data
{
    public class BookStoreDbContext : IdentityDbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<Review> Reviews { get; set; } = null!;
    }
}