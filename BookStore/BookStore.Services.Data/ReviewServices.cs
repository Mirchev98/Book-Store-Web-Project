using BookStore.Data;
using BookStore.Data.Models;
using BookStore.Services.Data.Interfaces;
using BookStore.Web.ViewModels.Reviews;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Data
{
    public class ReviewServices : IReviewServices
    {
        private BookStoreDbContext db;

        public ReviewServices(BookStoreDbContext db)
        {
            this.db = db;
        }

        public async Task Add(ReviewAddFormModel model)
        {
            Review newReview = new Review();

            newReview.Id = model.Id;
            newReview.ReviewerId = Guid.Parse(model.ReviewerId);
            newReview.BookId = model.BookId;
            newReview.ReviewText = model.ReviewText;
            newReview.StarRating = model.StarRating;
            newReview.ReviewerName = model.ReviewerName;

            await db.Reviews.AddAsync(newReview);
            await db.SaveChangesAsync();
        }

        public async Task<Review> FindReviewAsync(Guid id)
        {
            var review = await db.Reviews
                .FindAsync(id);

            return review;
        }

        public async Task RemoveAsync(Guid id)
        {
            var review = await db.Reviews.FindAsync(id);

            db.Reviews.Remove(review);

            await db.SaveChangesAsync();
        }
    }
}
