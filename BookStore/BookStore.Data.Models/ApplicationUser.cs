using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
            Books = new List<Book>();
            Reviews = new List<Review>();
            FavouriteAuthors = new List<Author>();
            FavouriteBooks = new List<Book>();
        }

        public ICollection<Book> Books { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Author> FavouriteAuthors { get; set; }

        public ICollection<Book> FavouriteBooks { get; set; }
    }
}
