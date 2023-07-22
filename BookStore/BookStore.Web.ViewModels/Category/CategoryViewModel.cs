using BookStore.Common;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Web.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }

        [StringLength(DataConstants.CategoryMaxNameLen, MinimumLength = DataConstants.CategoryMinNameLen)]
        public string Name { get; set; } = null!;
    }
}
