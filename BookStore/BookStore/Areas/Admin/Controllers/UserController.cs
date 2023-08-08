using BookStore.Common;
using BookStore.Data.Models;
using BookStore.Services.Data.Interfaces;
using BookStore.Web.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        [Route("Admin/User/All")]
        public async Task<IActionResult> All()
        {
            IEnumerable<ApplicationUser> users = await userService.GetUsers();

            foreach (ApplicationUser user in users)
            {
                if (await userManager.IsInRoleAsync(user, DataConstants.AdminRoleName))
                {
                    user.IsAdmin = true;
                }
            }

            return this.View(users);
        }

        [Route("Admin/User/Add/{id}")]
        public async Task<IActionResult> Add(Guid id)
        {
            var user = await userService.GetUserById(id);

            if (user == null)
            {
                return RedirectToAction("All", "User");
            }

            await userManager.AddToRoleAsync(user, DataConstants.AdminRoleName);

            return RedirectToAction("All", "User");
        }

        [Route("Admin/User/Remove/{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var user = await userService.GetUserById(id);

            if (user == null)
            {
                return RedirectToAction("All", "User");
            }

            await userManager.RemoveFromRoleAsync(user, DataConstants.AdminRoleName);

            return RedirectToAction("All", "User");
        }
    }
}
