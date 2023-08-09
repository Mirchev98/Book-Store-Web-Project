using BookStore.Data.Models;
using BookStore.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Web.Helpers;

namespace BookStore.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICartService service;

        public CartController(ICartService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Details()
        {
            Cart cart = new Cart();

            var email = GetEmail(this.User);

            if(email == null) 
            {
                TempData["Error"] = "No user found!";

                return RedirectToAction("Index", "Home");
            }

            cart = await service.GetCartByUserId(email);

            return View(cart);
        }

        public async Task<IActionResult> Purchase(int id)
        {
            var email = GetEmail(this.User);

            if (email == null)
            {
                TempData["Error"] = "No user found!";

                return RedirectToAction("Index", "Home");
            }

            Cart cart = await service.GetCartByUserId(email);

            await service.Add(cart, id);

            TempData["Success"] = "Book added to cart!";

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var email = GetEmail(this.User);

            if (email == null)
            {
                TempData["Error"] = "No user found!";

                return RedirectToAction("Index", "Home");
            }

            Cart cart = await service.GetCartByUserId(email);

            await service.Remove(cart, id);

            return RedirectToAction("Details");
        }

        public async Task<IActionResult> Finalise(int id)
        {
            var email = GetEmail(this.User);

            if (email == null)
            {
                TempData["Error"] = "No user found!";

                return RedirectToAction("Index", "Home");
            }

            Cart cart = await service.GetCartByUserId(email);

            if (cart.Books.Count == 0)
            {
                TempData["Error"] = "No items in cart!";

                return RedirectToAction("Index", "Home");
            }

            await service.EmptyCart(cart.Id);

            return View();
        }
    }
}
