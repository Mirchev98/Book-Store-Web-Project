using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace BookStore.Data.Models
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        public string ShortBiography { get; set; } = null!;

        [Required]
        public string PhotoUrl { get; set; } = null!;

        public IEnumerable<Book> Books { get; set; }
    }
}