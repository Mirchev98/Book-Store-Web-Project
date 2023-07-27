using BookStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Web.ViewModels.Author
{
    public class AuthorDetailsViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public string ShortBiography { get; set; } = null!;

        public string PhotoUrl { get; set; } = null!;
    }
}
