﻿using BookStore.Data;
using BookStore.Services.Data.Interfaces;
using BookStore.Web.ViewModels.Category;
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

        public async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync()
        {
            return await db.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id.ToString(),
                    Name = c.Name
                }).ToListAsync();
        }
    }
}
