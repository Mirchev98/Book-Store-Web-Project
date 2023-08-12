using BookStore.Common;
using BookStore.Data;
using BookStore.Data.Models;
using BookStore.Services.Data;
using BookStore.Services.Data.Interfaces;
using BookStore.Web.ViewModels.Author;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookStore.Services.Tests
{
    public class AuthorServiceTests
    {
        private DbContextOptions<BookStoreDbContext> dbOptions;
        private BookStoreDbContext dbContext;

        private IAuthorService authorService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<BookStoreDbContext>()
                .UseInMemoryDatabase("BookStoreInMemory" + Guid.NewGuid().ToString())
                .Options;
            
            this.dbContext = new BookStoreDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            
            //DatabaseSeeder.Seed(this.dbContext);

            this.authorService = new AuthorService(this.dbContext);
        }

        [Test]
        public async Task GetAuthorByName()
        {
            string name = "Robert Jordan";
            int wantedId = 1;

            Author author = await authorService.GetAuthorByNameAsync(name);

            Assert.That(author.Id, Is.EqualTo(wantedId));
        }

        [Test]
        public async Task GetAuthorById()
        {
            string name = "Robert Jordan";
            int wantedId = 1;

            Author author = await authorService.GetAuthorByIdAsync(wantedId);

            Assert.That(author.FullName, Is.EqualTo(name));
        }

        [Test]
        public async Task ValidateAuthor()
        {
            string name = "Robert Jordan";

            bool result = await authorService.ValidateAuthor(name);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task FillModelById()
        {
            string wantedName = "Robert Jordan";
            int authorId = 1;

            AuthorDetailsViewModel model = new AuthorDetailsViewModel();

            await authorService.FillModelById(model, authorId);

            Assert.That(model.FullName, Is.EqualTo(wantedName));
        }

        [Test]
        public async Task GetAllAuthors()
        {
            int wantedCount = 4;

            IEnumerable<AllAuthorsViewModel> authors = await authorService.GetAllAuthorsAsync();

            Assert.That(authors.Count(), Is.EqualTo(wantedCount));
        }

        [Test]
        public async Task FillModelForEdit()
        {
            string wantedName = "Robert Jordan";
            int authorId = 1;
            
            AddAuthorFormModel model = new AddAuthorFormModel();

            await authorService.FillModelById(model, authorId);

            Assert.That(model.FullName, Is.EqualTo(wantedName));
        }
    }
}
