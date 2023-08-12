using BookStore.Data;
using BookStore.Services.Data.Interfaces;
using BookStore.Services.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Web.ViewModels.Book;
using BookStore.Services.Data.Models;
using BookStore.Data.Models;

namespace BookStore.Services.Tests
{
    public class BookServiceTests
    {
        private DbContextOptions<BookStoreDbContext> dbOptions;
        private BookStoreDbContext dbContext;

        private IBookService bookService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<BookStoreDbContext>()
                .UseInMemoryDatabase("BookStoreInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new BookStoreDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();

            //DatabaseSeeder.Seed(this.dbContext);

            this.bookService = new BookService(this.dbContext);
        }

        [Test]
        public async Task AllBook()
        {
            int count = 5;

            BookAllQueryModel query = new BookAllQueryModel();
            AllBooksFilteredAndOrdered model = new AllBooksFilteredAndOrdered();

            model = await bookService.AllAsync(query);

            Assert.That(model.Books.Count(), Is.EqualTo(count));
        }

        [Test]
        public async Task FindBook()
        {
            int bookId = 1;
            string wantedTitle = "The Eye of the World";

            var book = bookService.FindBook(bookId);

            Assert.That(book.Title, Is.EqualTo(wantedTitle));
        }
    }
}
