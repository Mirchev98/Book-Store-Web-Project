using BookStore.Data;
using BookStore.Data.Models;
using BookStore.Services.Data.Interfaces;
using BookStore.Web.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private BookStoreDbContext db;

        public CategoryService(BookStoreDbContext db)
        {
            this.db = db;
        }

        public async Task AddCategoryAsync(CategoryViewModel model)
        {
            Category category = new Category() 
            {
                Name = model.Name
            };

            await db.Categories.AddAsync(category);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<string>> AllCategoryNames()
        {
            return await db.Categories
                .Select(c => c.Name)
                .ToListAsync();
        }

        public bool CheckIfAnyBooksWithGivenCategory(int id)
        {
            if (db.Books.Any(c => c.CategoryId == id))
            {
                return true;
            }

            return false;
        }

        public async Task<bool> CheckIfCategoryExistsAsync(string name)
        {
            Category? category = await db.Categories.FirstOrDefaultAsync(c => c.Name == name);

            if (category == null) 
            {
                return false;
            }

            return true;
        }

        public async Task EditCategoryAsync(Category model)
        {
            Category? category = await db.Categories.FindAsync(model.Id);

            category.Name = model.Name;

            await db.SaveChangesAsync();
        }

        public Category FindCategory(int id)
        {
            return db.Categories
                .Where(c => c.Id == id)
                .First(c => c.Id == id);
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync()
        {
            return await db.Categories
                .Select(c => new CategoryViewModel
                {
                    CategoryId = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

        public async Task RemoveAsync(int id)
        {
            Category? category = await db.Categories.FindAsync(id);
            
            db.Categories.Remove(category);

            await db.SaveChangesAsync();
        }
    }
}
