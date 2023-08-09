using BookStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Data.Interfaces
{
    public interface ICartService
    {
        public Task<Cart> GetCartByUserId(string email);

        public Task EmptyCart(int id);

        public Task Add(Cart cart, int id);

        public Task Remove(Cart cart, int id);
    }
}
