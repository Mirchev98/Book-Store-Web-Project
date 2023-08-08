using BookStore.Data.Models;
using BookStore.Services.Data;
using BookStore.Services.Data.Interfaces;
using BookStore.Services.Data.Models;
using BookStore.Web.ViewModels.Book;
using BookStore.Web.ViewModels.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BookStore.Controllers
{
    public class BookController : BaseController
    {
        private IAuthorService authorService;
        private IBookService bookService;
        private ICategoryService categoryService;
        private IReviewServices reviewServices;

        public BookController(IAuthorService authorService, IBookService bookService, ICategoryService categoryService, IReviewServices reviewServices)
        {
            this.authorService = authorService;
            this.bookService = bookService;
            this.categoryService = categoryService;
            this.reviewServices = reviewServices;

        }
        
        [AllowAnonymous]
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
            if (!IsAdmin(User))
            {
                return Unauthorized();
            }

            AddBookViewModel viewModel = new AddBookViewModel();

            IEnumerable<CategoryViewModel> categories = await categoryService.GetCategoriesAsync();
            
            viewModel.Categories = categories;
            
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            if (!IsAdmin(User))
            {
                return Unauthorized();
            }

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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            BookDetailsViewModel model = new BookDetailsViewModel();

            model = await bookService.GetBookAsync(model, id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!IsAdmin(User))
            {
                return Unauthorized();
            }

            AddBookViewModel model = bookService.FindBook(id);

            IEnumerable<CategoryViewModel> categories = await categoryService.GetCategoriesAsync();

            model.Categories = categories;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddBookViewModel model)
        {
            if (!IsAdmin(User))
            {
                return Unauthorized();
            }

            await bookService.EditBook(model, id);

            TempData["Success"] = "Book edited succesfully!";

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!IsAdmin(User))
            {
                return Unauthorized();
            }

            bool result = await bookService.DeleteBook(id);

            if (result)
            {
                TempData["Success"] = "Book deleted succesfully!";

                return RedirectToAction("All");
            }

            TempData["Success"] = "Book could not be deleted!";

            return RedirectToAction("Details", new {id});
        }
    }
}
