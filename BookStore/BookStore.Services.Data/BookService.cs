using BookStore.Data;
using BookStore.Data.Models;
using BookStore.Services.Data.Interfaces;
using BookStore.Web.ViewModels.Book;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Data
{
    public class BookService : IBookService
    {
        private BookStoreDbContext db;

        public BookService(BookStoreDbContext db)
        {
            this.db = db;
        }

        public async Task AddBook(AddBookViewModel model, Author author)
        {
            
            Book book = new Book
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                AuthorId = author.Id,
                CategoryId = Guid.Parse(model.CategoryId),
                Price = model.Price,
                PhotoUrl = model.PhotoUrl
            };

            await db.Books.AddAsync(book);
            await db.SaveChangesAsync();
        }
    }
}
