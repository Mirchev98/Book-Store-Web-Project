using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Models
{
    public class FavoriteAuthorUser
    {
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }

        public Author Author { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
