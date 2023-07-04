using BookStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Data.Interfaces
{
    public interface IAuthorService
    {
        public Task<Author> GetAuthorByNameAsync(string name);

        public Task<bool> ValidateAuthor(string name);
    }
}
