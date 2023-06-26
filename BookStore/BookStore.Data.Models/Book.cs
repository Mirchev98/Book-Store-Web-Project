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
            PhotosUrls = new List<string>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Category))]
        public string CategoryId { get; set; } = null!;

        [Required]
        public Category Category { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }

        public Author Author { get; set; } = null!;

        public ICollection<Review> Reviews { get; set; }

        public ICollection<string> PhotosUrls { get; set; }
    }
}
