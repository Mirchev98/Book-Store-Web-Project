using BookStore.Services.Data.Interfaces;
using BookStore.Web.ViewModels.Author;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AuthorController : BaseController
    {
        private IAuthorService authorService;

        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet]
        public IActionResult Add() 
        {
            AddAuthorFormModel model = new AddAuthorFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAuthorFormModel model)
        {
            if (await authorService.ValidateAuthor(model.FullName))
            {
                TempData["ErrorMessage"] = "Author already added!";

                return View(model);
            }
            
            if (!ModelState.IsValid) 
            {
                TempData["ErrorMessage"] = "Invalid author information!";
                
                return View(model);
            }

            await authorService.AddAuthorAsync(model);

            TempData["Success"] = "Author succsefully added!";

            return RedirectToAction("All", "Book");
        }
    }
}
