using BookStore.Data.Models;
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

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<AllAuthorsViewModel> model = new List<AllAuthorsViewModel>();

            model = await authorService.GetAllAuthorsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Author author = await authorService.GetAuthorByIdAsync(id);

            if (author == null)
            {
                TempData["ErrorMessage"] = "Author does not exist!";

                return RedirectToAction("All");
            }

            AddAuthorFormModel emptyModel = new AddAuthorFormModel();

            AddAuthorFormModel model = await authorService.FillModelById(emptyModel, id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddAuthorFormModel model)
        {
            Author author = await authorService.GetAuthorByIdAsync(model.Id);

            await authorService.EditAuthor(model, author);

            TempData["Success"] = "Author edited added!";

            return RedirectToAction("All");
        }
    }
}
