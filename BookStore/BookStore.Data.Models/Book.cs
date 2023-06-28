using BookStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Models
{
    public class Book
    {
        public Book()
        {
            Reviews = new List<Review>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.BookTitleMaxLen)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DataConstants.BookDesMaxLen)]
        public string Description { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }

        [Required]
        public Category Category { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }

        public Author Author { get; set; } = null!;

        public ICollection<Review> Reviews { get; set; }

        [Required]
        [MaxLength(DataConstants.PhotoUrlMaxLen)]
        public string PhotoUrl { get; set; }

        public ICollection<FavoriteUserBook> FavoriteUsersBook { get; set; } = new HashSet<FavoriteUserBook>();

        public ICollection<UserBookBought> UserBoughtBooks { get; set; } = new HashSet<UserBookBought>();
    }
}
