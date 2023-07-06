
using BookStore.Web.ViewModels.Book.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Web.ViewModels.Book
{
    public class BookAllQueryModel
    {
        public BookAllQueryModel()
        {
            CurrentPage = 1;
            BooksPerPage = 6;

            Categories = new List<string>();
            Books = new List<BookAllViewModel>();
        }

        public string? CategoryName { get; set; }

        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Books by")]
        public BookSortEnum BookSorting { get; set; }

        public int CurrentPage { get; set; }

        public int BooksPerPage { get; set; }

        public int TotalBooks { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<BookAllViewModel> Books { get; set; }
    }
}
