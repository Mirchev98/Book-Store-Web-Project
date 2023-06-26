using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Models
{
    public class Review
    {
        public Review()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public int StarRating { get; set; }

        [Required]
        [ForeignKey(nameof(Reviewer))]
        public string ReviewerId { get; set; } = null!;

        public ApplicationUser Reviewer { get; set; }

        [Required]
        public string ReviewText { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }

        public Book Book { get; set; } = null!;
    }
}
