using BookStore.Data;
using BookStore.Data.Models;
using BookStore.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Data
{
    public class CartService : ICartService
    {
        private readonly BookStoreDbContext db;

        public CartService(BookStoreDbContext db)
        {
            this.db = db;
        }

        public async Task Add(Cart cart, int id)
        {
            var book = await db.Books.FindAsync(id);

            cart.Books.Add(book);

            await db.SaveChangesAsync();
        }

        public async Task EmptyCart(int id)
        {
            Cart cart = await db.Carts.FindAsync(id);

            cart.Books = new List<Book>();

            await db.SaveChangesAsync();
        }

        public async Task<Cart> GetCartByUserId(string email)
        {
            Cart result = new Cart();

            result = await db.Carts.Include(x => x.Books).Where(c =>  c.User.Email == email).FirstOrDefaultAsync();

            if(result == null) 
            {
                result = new Cart();
                
                var user = db.Users.FirstOrDefault(u => u.Email == email);
                
                user.Cart = result;
                
                db.Carts.Add(result);
                
                await db.SaveChangesAsync();
                
                return result;
            }
            
            return result;
        }

        public async Task Remove(Cart cart, int id)
        {
            var book = await db.Books.FindAsync(id);

            cart.Books
                .Remove(book);

            await db.SaveChangesAsync();
        }
    }
}
