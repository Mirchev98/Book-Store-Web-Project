using BookStore.Data.Models;
using BookStore.Web.ViewModels.Author;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Data.Interfaces
{
    public interface IAuthorService
    {
        public Task<Author> GetAuthorByNameAsync(string name);

        public Task<bool> ValidateAuthor(string name);

        public Task AddAuthorAsync(AddAuthorFormModel model);

        public Task<IEnumerable<AllAuthorsViewModel>> GetAllAuthorsAsync();

        public Task<AddAuthorFormModel> FillModelById(AddAuthorFormModel model, int id);

        public Task<AuthorDetailsViewModel> FillModelById(AuthorDetailsViewModel model, int id);

        public Task<Author> GetAuthorByIdAsync(int id);

        public Task EditAuthor(AddAuthorFormModel model, Author author);
        
        public Task Delete(int id);
    }
}
