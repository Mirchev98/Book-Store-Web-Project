using BookStore.Data;
using BookStore.Data.Models;
using BookStore.Services.Data.Interfaces;
using BookStore.Services.Data.Models;
using BookStore.Web.ViewModels.Book;
using BookStore.Web.ViewModels.Book.Enums;
using Microsoft.AspNetCore.Mvc;
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
                CategoryId = int.Parse(model.CategoryId),
                Price = model.Price,
                PhotoUrl = model.PhotoUrl
            };

            await db.Books.AddAsync(book);
            await db.SaveChangesAsync();
        }

        public async Task<AllBooksFilteredAndOrdered> AllAsync(BookAllQueryModel queryModel)
        {
            IQueryable<Book> bookQuery = this.db
                                .Books
                                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.CategoryName))
            {
                bookQuery = bookQuery
                    .Where(h => h.Category.Name == queryModel.CategoryName);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                bookQuery = bookQuery
                    .Where(h => EF.Functions.Like(h.Title, wildCard) ||
                                EF.Functions.Like(h.Author.FullName, wildCard) ||
                                EF.Functions.Like(h.Description, wildCard));
            }

            bookQuery = queryModel.BookSorting switch
            {
                BookSortEnum.AlphabeticallyAscending => bookQuery
                    .OrderBy(b => b.Title),
                BookSortEnum.AlphabeticallyDescending => bookQuery
                    .OrderByDescending(b => b.Title),
                BookSortEnum.PriceAscending => bookQuery
                    .OrderBy(b => b.Price),
                BookSortEnum.PriceDescending => bookQuery
                    .OrderByDescending(b => b.Price),
                BookSortEnum.ByAuthorDescending => bookQuery
                    .OrderByDescending (b => b.Author.FullName),
                BookSortEnum.ByAuthorAscending => bookQuery
                    .OrderBy (b => b.Author.FullName),
                _ => bookQuery
                    .OrderBy(b => b.Title)
            };

            IEnumerable<BookAllViewModel> books = await bookQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.BooksPerPage)
                .Take(queryModel.BooksPerPage)
                .Select(b => new BookAllViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    PhotoUrl = b.PhotoUrl,
                    Price = b.Price,
                    AuthorName = b.Author.FullName,
                    CategoryName = b.Category.Name
                })
                .ToArrayAsync();
            
            int totalBooksCount = bookQuery.Count();

            return new AllBooksFilteredAndOrdered()
            {
                TotalBooksCount = totalBooksCount,
                Books = books
            };
        }

        public async Task<BookDetailsViewModel> GetBookAsync(BookDetailsViewModel model, int id)
        {
            Book? book = await db.Books
                .Include(a => a.Author)
                .Include(c => c.Category)
                .Include (d => d.Reviews)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null) 
            {
                return null;
            }

            model.Id = book.Id;
            model.Title = book.Title;
            model.Description = book.Description;
            model.Price = book.Price;
            model.PhotoUrl = book.PhotoUrl;
            model.CategoryId = book.CategoryId;
            model.AuthorId = book.AuthorId;
            model.Reviews = book.Reviews;
            model.AuthorName = book.Author.FullName;
            model.CategoryName = book.Category.Name;

            return model;
        }
    }
}
