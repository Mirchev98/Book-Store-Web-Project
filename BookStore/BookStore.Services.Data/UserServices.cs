using BookStore.Data;
using BookStore.Data.Models;
using BookStore.Services.Data.Interfaces;
using BookStore.Web.ViewModels.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Data
{
    public class UserServices : IUserService
    {
        private BookStoreDbContext db;

        public UserServices(BookStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<ApplicationUser> GetUserById(Guid id)
        {
            return await db.Users.FindAsync(id);
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsers()
        {
            IEnumerable<ApplicationUser> users = await db.Users.ToListAsync();

            return users;
        }

    }
}
