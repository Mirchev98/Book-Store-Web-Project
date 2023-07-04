using BookStore.Web.ViewModels.Category;
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
    }
}
