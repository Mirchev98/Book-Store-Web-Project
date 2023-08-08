using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey(nameof(Cart))]
        public int CartId { get; set; }

        public Cart Cart { get; set; }

        public bool IsAdmin { get; set; }
    }
}
