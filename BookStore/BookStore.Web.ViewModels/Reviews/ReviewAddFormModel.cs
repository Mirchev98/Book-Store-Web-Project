using BookStore.Common;
using BookStore.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Web.ViewModels.Reviews
{
    public class ReviewAddFormModel
    {
        public Guid Id { get; set; }

        [Required]

        [Range(DataConstants.ReviewStarsMin, DataConstants.ReviewStarsMax)]
        public int StarRating { get; set; }

        public string ReviewerId { get; set; }

        public string ReviewerName { get; set; }

        [Required]
        [StringLength(DataConstants.ReviewMaxLen, MinimumLength = DataConstants.ReviewMinLen)]
        public string ReviewText { get; set; } = null!;

        public int BookId { get; set; }
    }
}
