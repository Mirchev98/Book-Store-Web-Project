using BookStore.Common;
using BookStore.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace BookStore.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public static string? GetId(ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static string? GetEmail(ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Email);
        }

        public static bool IsAdmin(ClaimsPrincipal user) 
        {
            return user.IsInRole(DataConstants.AdminRoleName);
        }
    }
}
