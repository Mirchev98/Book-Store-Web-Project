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

            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReviewAddFormModel model)
        {
            string? id = GetId(User);
            string? email = GetEmail(User);

            model.ReviewerId = id;
            model.ReviewerName = email;

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Invalid model!";

                return View(model);
            }

            await reviewService.Add(model);

            TempData["Success"] = "Review added succesfully!";

            return RedirectToAction("All", "Book");
        }

    }
}
