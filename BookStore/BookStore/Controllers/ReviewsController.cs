using BookStore.Services.Data.Interfaces;
using BookStore.Web.ViewModels.Reviews;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStore.Controllers
{
    public class ReviewsController : BaseController
    {
        private IReviewServices reviewService;

        public ReviewsController(IReviewServices reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            string? userId = GetId(User);
            string? email = GetEmail(User);

            if (userId == null || email == null)
            {
                //Redirect to error page here
                TempData["ErrorMessage"] = "No user found!";

                return RedirectToAction("All", "Book");
            }

            ReviewAddFormModel form = new ReviewAddFormModel();

            form.ReviewerId = userId;
            form.ReviewerName = email;
            form.BookId = id;

            ViewBag.Id = id;
            ViewBag.ReviewerId = userId;
            ViewBag.ReviewerName = email;

            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReviewAddFormModel form, int id)
        {

            string? userId = GetId(User);
            string? email = GetEmail(User);

            if (userId == null || email == null)
            {
                //Redirect to error page here
                TempData["ErrorMessage"] = "No user found!";

                return RedirectToAction("Details", "Book", new { id });
            }

            form.ReviewerId = userId;
            form.ReviewerName = email;
            form.BookId = id;

            await reviewService.Add(form);

            TempData["Success"] = "Review added succesfully!";

            return RedirectToAction("Details", "Book", new { id });
        }

        public async Task<IActionResult> Remove(string id)
        {
            var reviewId = Guid.Parse(id);
            
            var review = reviewService.FindReviewAsync(reviewId);

            if (review == null)
            {
                TempData["ErrorMessage"] = "No review found!";

                return RedirectToAction("All", "Book");
            }

            await reviewService.RemoveAsync(reviewId);

            TempData["Success"] = "Review removed succesfully!";

            return RedirectToAction("All", "Book");
        }

    }
}
