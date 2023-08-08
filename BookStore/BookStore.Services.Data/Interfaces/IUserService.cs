using BookStore.Data.Models;
using BookStore.Web.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Data.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<ApplicationUser>> GetUsers();

        public Task<ApplicationUser> GetUserById(Guid id);
    }
}
