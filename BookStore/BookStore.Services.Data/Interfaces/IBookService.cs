using BookStore.Data.Models;
using BookStore.Services.Data.Models;
using BookStore.Web.ViewModels.Book;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Data.Interfaces
{
    public interface IBookService
    {
        public Task AddBook(AddBookViewModel model, Author author);

        public Task<AllBooksFilteredAndOrdered> AllAsync(BookAllQueryModel queryModel);

        public Task<BookDetailsViewModel> GetBookAsync(BookDetailsViewModel model, int id);

        public AddBookViewModel FindBook(int id);

        public Task EditBook(AddBookViewModel model, int id);

        public Task<bool> DeleteBook(int id);
    }
}
