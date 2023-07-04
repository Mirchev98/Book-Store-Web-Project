using BookStore.Web.ViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Data.Models
{
    public class AllBooksFilteredAndOrdered
    {
        public AllBooksFilteredAndOrdered()
        {
            Books = new List<BookAllViewModel>();
        }

        public int TotalBooksCount { get; set; }

        public IEnumerable<BookAllViewModel> Books { get; set; }
    }
}
