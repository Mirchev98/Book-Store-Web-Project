using BookStore.Common;
using BookStore.Data;
using BookStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace BookStore.Services.Tests
{
    public static class DatabaseSeeder
    {
        public static ApplicationUser ApplicationUser;
        public static Author Author;
        public static Category Category;
        public static Book Book;
        public static Review Review;
        
        public static void Seed(BookStoreDbContext context)
        {
            ApplicationUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                Email = DataConstants.AdminEmail,
                NormalizedEmail = DataConstants.AdminEmail,
                UserName = DataConstants.AdminEmail,
                NormalizedUserName = DataConstants.AdminEmail,
                PasswordHash = Crypto.HashPassword(DataConstants.AdminPass)
            };
            
            Author = new Author
            {
                Id = 1,
                FullName = "Robert Jordan",
                PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/Robert_Jordan.jpg/330px-Robert_Jordan.jpg",
                ShortBiography = "James Oliver Rigney Jr. (October 17, 1948 – September 16, 2007), better known by his pen name Robert Jordan, was an American author of epic fantasy. He is known best for his series The Wheel of Time (finished by Brandon Sanderson after Jordan's death) which comprises 14 books and a prequel novel. He is one of several writers to have written original Conan the Barbarian novels; his are considered by fans to be some of the best of the non-Robert E. Howard efforts. Jordan also published historical fiction using the pseudonym Reagan O'Neal, a western as Jackson O'Reilly, and dance criticism as Chang Lung. Jordan claimed to have ghostwritten an \"international thriller\" that is still believed to have been written by someone else."
            };

            Category = new Category
            {
                Id = 1,
                Name = "Fantasy"
            };

            Book = new Book
            {
                Id = 1,
                Title = "The Eye of the World",
                Description = "The Eye of the World is a high fantasy novel by American writer Robert Jordan, the first book of The Wheel of Time series. It was published by Tor Books and released on 15 January 1990. The unabridged audiobook is read by Michael Kramer and Kate Reading. Upon first publication, The Eye of the World consisted of one prologue and 53 chapters, with an additional prologue authored upon re-release. The book was a critical, and commercial success. Critics praised the tone, the themes, and the similarity to Lord of the Rings (although some criticized it for that). On 2 January 2002, The Eye of the World was re-released as two separate books aimed at a young adult market, with larger text and a handful of illustrations. These were From the Two Rivers and To the Blight. The former included an additional prologue entitled \"Ravens\", focusing on Egwene al'Vere. The American Library Association put The Eye of the World on its 2003 list of Popular Paperbacks for Young Adults. After the release of The Wheel of Time television series, The Eye of the World made the January 2022 The New York Times Best Seller list in the mass market category and was number one on the audio fiction list.",
                CategoryId = 1,
                AuthorId = 1,
                PhotoUrl = "https://upload.wikimedia.org/wikipedia/en/0/00/WoT01_TheEyeOfTheWorld.jpg",
                Price = 20
            };

            Review = new Review
            {
                StarRating = 5,
                ReviewerId = ApplicationUser.Id,
                ReviewerName = ApplicationUser.Email,
                ReviewText = "Very nice book I love it!",
                BookId = Book.Id
            };

            context.Users.Add(ApplicationUser);
            context.Authors.Add(Author);
            context.Categories.Add(Category);
            context.Books.Add(Book);
            context.Reviews.Add(Review);

            context.SaveChanges();
        }
    }
}
