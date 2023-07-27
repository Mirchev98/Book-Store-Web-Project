using BookStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Web.ViewModels.Author
{
    public class AddAuthorFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.AuthorMaxNameLen, MinimumLength = DataConstants.AuthorMinNameLen)]
        public string FullName { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.AuthorBiographyMaxLen, MinimumLength = DataConstants.AuthorBiographyMinLen)]
        public string ShortBiography { get; set; } = null!;

        [Required]
        [MaxLength(DataConstants.PhotoUrlMaxLen)]
        public string PhotoUrl { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
