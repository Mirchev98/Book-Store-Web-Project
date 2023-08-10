using BookStore.Data;
using BookStore.Services.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.dbContext = new HouseRentingDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.agentService = new AgentService(this.dbContext);
        }
    }
}
