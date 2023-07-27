using BookStore.Data;
using BookStore.Data.Models;
using BookStore.Services.Data.Interfaces;
using BookStore.Web.ViewModels.Author;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BookStore.Services.Data
{
    public class AuthorService : IAuthorService
    {
        private BookStoreDbContext db;

        public AuthorService(BookStoreDbContext db)
        {
            this.db = db;
        }

        public async Task AddAuthorAsync(AddAuthorFormModel model)
        {
            Author author = new Author
            {
                Id = model.Id,
                FullName = model.FullName,
                ShortBiography = model.ShortBiography,
                PhotoUrl = model.PhotoUrl
            };

            await db.Authors
                .AddAsync(author);

            await db.SaveChangesAsync();
        }

        public async Task EditAuthor(AddAuthorFormModel model, Author author)
        {
            author.FullName = model.FullName;
            author.ShortBiography = model.ShortBiography;
            author.PhotoUrl = model.PhotoUrl;

            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllAuthorsViewModel>> GetAllAuthorsAsync()
        {
            IEnumerable<AllAuthorsViewModel> result = await db.Authors
                .Select(a => new AllAuthorsViewModel 
                { 
                    Id = a.Id,
                    Name = a.FullName
                }).ToListAsync();

            return result;
        }

        public async Task<AddAuthorFormModel> FillModelById(AddAuthorFormModel model, int id)
        {
            Author? author = await db.Authors.FindAsync(id);

            if (author == null) 
            {
                return null;            
            }

            model.Id = author.Id; 
            model.FullName = author.FullName;
            model.ShortBiography = author.ShortBiography;
            model.PhotoUrl = author.PhotoUrl;
            
            return model;
        }

        public async Task<Author> GetAuthorByNameAsync(string name)
        {
            Author? author = await db.Authors
                            .FirstAsync(a => a.FullName == name);

            return author;
        }

        public async Task<bool> ValidateAuthor(string name)
        {
            Author? author = await db.Authors
                .FirstOrDefaultAsync(a => a.FullName == name);

            if (author == null)
            {
                return false;
            }

            return true;
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            Author author = await db.Authors.FindAsync(id);

            if (author == null) 
            {
                return null;
            }

            return author;
        }
    }
}
