using BookStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BookStore.Data.Models;
using BookStore.Web.ViewModels.Reviews;

namespace BookStore.Web.ViewModels.Book
{
    public class BookDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int AuthorId { get; set; }

        public string AuthorName { get; set; }


        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public string PhotoUrl { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
