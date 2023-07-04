using BookStore.Data.Models;
using BookStore.Services.Data;
using BookStore.Services.Data.Interfaces;
using BookStore.Web.ViewModels.Book;
using BookStore.Web.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private IAuthorService authorService;
        private IBookService bookService;
        private ICategoryService categoryService;

        public BookController(AuthorService authorService, BookService bookService, CategoryService categoryService)
        {
            this.authorService = authorService;
            this.bookService = bookService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddBookViewModel viewModel = new AddBookViewModel();

            IEnumerable<CategoryViewModel> categories = await categoryService.GetCategoriesAsync();
            
            viewModel.Categories = categories;
            
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            if (!await authorService.ValidateAuthor(model.Author)) 
            {
                ModelState.AddModelError(nameof(model.Author), "Author does not exist in database! Please add the author, before the book!");
            }

            if (ModelState.IsValid)
            {
                await bookService.AddBook(model);
            }

            return RedirectToAction("Home", "Index");
        }
    }
}
