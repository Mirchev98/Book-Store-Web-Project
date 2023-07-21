using BookStore.Common;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Web.ViewModels.Category
{
    public class CategoryViewModel
    {
        public string CategoryId { get; set; } = null!;

        [StringLength(DataConstants.CategoryMaxNameLen, MinimumLength = DataConstants.CategoryMinNameLen)]
        public string Name { get; set; } = null!;
    }
}
