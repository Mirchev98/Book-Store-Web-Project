using BookStore.Web.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync();

        public Task<IEnumerable<string>> AllCategoryNames();

        public Task<bool> CheckIfCategoryExistsAsync(string name);

        public Task AddCategoryAsync(string categoryName);

    }
}
