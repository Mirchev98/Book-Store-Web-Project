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
        public IActionResult Add(int bookId)
        {
            string? id = GetId(User);
            string? email = GetEmail(User);

            if (id == null || email == null)
            {
                //Redirect to error page here
                TempData["ErrorMessage"] = "No user found!";

                return RedirectToAction("All", "Book");
            }

            ReviewAddFormModel form = new ReviewAddFormModel();

            form.ReviewerId = id;
            form.ReviewerName = email;
            form.BookId = bookId;

            return View(form);
        }

        

    }
}
