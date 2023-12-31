﻿using BookStore.Data.Models;
using BookStore.Services.Data.Interfaces;
using BookStore.Web.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<CategoryViewModel> categories = await categoryService.GetCategoriesAsync();
            
            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            
            if (!IsAdmin(User))
            {
                return Unauthorized();
            }

            CategoryViewModel model = new CategoryViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel model)
        {
            if (!IsAdmin(User))
            {
                return Unauthorized();
            }

            await categoryService.AddCategoryAsync(model);

            TempData["Success"] = "Category added succesfully!";

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Remove(int id)
        {
            if (!IsAdmin(User))
            {
                return Unauthorized();
            }

            await categoryService.RemoveAsync(id);

            TempData["Success"] = "Category removed succesfully!";

            return RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!IsAdmin(User))
            {
                return Unauthorized();
            }

            Category model = categoryService.FindCategory(id);

            return View(model);
        }

        public async Task<IActionResult> Edit(int id, Category model)
        {
            if (!IsAdmin(User))
            {
                return Unauthorized();
            }


            model.Id = id;

            await categoryService.EditCategoryAsync(model);

            TempData["Success"] = "Category edited succesfully!";

            return RedirectToAction("All");
        }
    }
}
