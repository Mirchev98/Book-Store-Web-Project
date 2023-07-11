using BookStore.Data.Models;
using BookStore.Services.Data;
using BookStore.Services.Data.Interfaces;
using BookStore.Services.Data.Models;
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

        public BookController(IAuthorService authorService, IBookService bookService, ICategoryService categoryService)
        {
            this.authorService = authorService;
            this.bookService = bookService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery]BookAllQueryModel query)
        {
            AllBooksFilteredAndOrdered model = await bookService.AllAsync(query);

            query.Books = model.Books;
            query.TotalBooks = model.TotalBooksCount;
            query.Categories = await categoryService.AllCategoryNames();

            return View(query);
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
            IEnumerable<CategoryViewModel> categories = await categoryService.GetCategoriesAsync();

            model.Categories = categories;

            if (!await authorService.ValidateAuthor(model.Author)) 
            {
                ModelState.AddModelError(nameof(model.Author), "Author does not exist in database! Please add the author, before the book!");

                return View(model);
            }

            if(!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Invalid boook data!";
                
                return View(model);
            }

            Author author = await authorService.GetAuthorByNameAsync(model.Author);
            await bookService.AddBook(model, author);

            TempData["Success"] = "Book added succesfully!";

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            BookDetailsViewModel model = new BookDetailsViewModel();

            model = await bookService.GetBookAsync(model, id);

            return View(model);
        }
    }
}
