using BookStore.Data;
using BookStore.Data.Models;
using BookStore.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace BookStore.Services.Data
{
    public class AuthorService : IAuthorService
    {
        private BookStoreDbContext db;

        public AuthorService(BookStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<Author> GetAuthorByNameAsync(string name)
        {
            Author? author = await db.Authors
                            .FirstOrDefaultAsync(a => a.FullName == name);

            if (author == null)
            {
                throw new ArgumentNullException();
            }

            return author;
        }
    }
}
