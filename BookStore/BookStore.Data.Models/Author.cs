using BookStore.Common;
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
        [MaxLength(DataConstants.AuthorMaxNameLen)]
        public string FullName { get; set; } = null!;

        [Required]
        [MaxLength(DataConstants.AuthorBiographyMaxLen)]
        public string ShortBiography { get; set; } = null!;

        [Required]
        [MaxLength(DataConstants.PhotoUrlMaxLen)]
        public string PhotoUrl { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public ICollection<Book> Books { get; set; }

        public ICollection<FavoriteAuthorUser> FavoriteAuthorUsers { get; set; } = new HashSet<FavoriteAuthorUser>();
    }
}