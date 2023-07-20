using BookStore.Web.ViewModels.Reviews;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Data.Interfaces
{
    public interface IReviewServices
    {
        public Task Add(ReviewAddFormModel model);
    }
}
