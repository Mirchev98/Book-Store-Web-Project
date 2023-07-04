using BookStore.Common;
using BookStore.Web.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Web.ViewModels.Book
{
    public class AddBookViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.BookTitleMaxLen, MinimumLength = DataConstants.BookTitleMinLen)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.BookDesMaxLen, MinimumLength = DataConstants.BookDesMinLen)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.AuthorMaxNameLen, MinimumLength = DataConstants.AuthorMinNameLen)]
        public string Author { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Photo Link")]
        [Required]
        public string PhotoUrl { get; set; } = null!;

        public string CategoryId { get; set; } = null!;

        public IEnumerable<CategoryViewModel> Categories { get; set; } = null!;
    }
}
