using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
