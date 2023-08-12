using BookStore.Data;
using BookStore.Services.Data.Interfaces;
using BookStore.Services.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Web.ViewModels.Category;

namespace BookStore.Services.Tests
{
    public class CategoryServiceTests
    {
        private DbContextOptions<BookStoreDbContext> dbOptions;
        private BookStoreDbContext dbContext;

        private ICategoryService categoryService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<BookStoreDbContext>()
                .UseInMemoryDatabase("BookStoreInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new BookStoreDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();

            //DatabaseSeeder.Seed(this.dbContext);

            this.categoryService = new CategoryService(this.dbContext);
        }

        [Test]
        public async Task GetAllCategoryNames()
        {
            int wantedCategories = 5;

            IEnumerable<string> categoriesNames = await categoryService.AllCategoryNames();

            Assert.That(categoriesNames.Count(), Is.EqualTo(wantedCategories));
        }
    }
}
