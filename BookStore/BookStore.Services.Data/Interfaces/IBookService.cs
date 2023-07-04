﻿using BookStore.Data.Models;
using BookStore.Web.ViewModels.Book;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Data.Interfaces
{
    public interface IBookService
    {
        public Task AddBook(AddBookViewModel model, Author author);
    }
}
