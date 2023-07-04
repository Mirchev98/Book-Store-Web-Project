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
        private IAuthorService authorService;

        public BookService(BookStoreDbContext db, AuthorService authorService)
        {
            this.db = db;
            this.authorService = authorService;
        }

        public async Task AddBook(AddBookViewModel model)
        {
            Author author = await authorService.GetAuthorByNameAsync(model.Author);
            
            Book book = new Book
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                AuthorId = author.Id,
                CategoryId = Guid.Parse(model.CategoryId),
                Price = model.Price
            };

            await db.Books.AddAsync(book);
            await db.SaveChangesAsync();
        }
    }
}
