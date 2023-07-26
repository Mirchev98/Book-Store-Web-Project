using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Web.ViewModels.Book
{
    public class BookAllViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Display(Name = "Category")]
        public string CategoryName { get; set; } = null!;

        [Display(Name = "Author")]
        public string AuthorName { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public string PhotoUrl { get; set; }

        public decimal Price { get; set; }
    }
}
