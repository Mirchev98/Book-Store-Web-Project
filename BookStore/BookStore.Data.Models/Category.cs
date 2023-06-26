using System.ComponentModel.DataAnnotations;

namespace BookStore.Data.Models
{
    public class Category
    {
        public Category()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}