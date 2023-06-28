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
            Reviews = new List<Review>();
        }

        public ICollection<UserBookBought> BoughtBooks { get; set; } = new HashSet<UserBookBought>();

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Author> FavouriteAuthors { get; set; } = new HashSet<Author>();

        public ICollection<FavoriteUserBook> FavouriteBooks { get; set; } = new HashSet<FavoriteUserBook>();
    }
}
