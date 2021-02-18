using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly ShoppingCart shoppingCart;

        public ShoppingCartController(IBookRepository bookRepo, ShoppingCart cart)
        {
            this.bookRepository = bookRepo;
            this.shoppingCart = cart;
        }
        public IActionResult Index()
        {
            shoppingCart.ShoppingCartItems = shoppingCart.GetShoppingCartItems();
            return View(shoppingCart);
        }

        public RedirectToActionResult AddToShoppingCart(int bookId)
        {
            var selectedBook = bookRepository.GetBookById(bookId);

            shoppingCart.AddItemToCart(selectedBook, selectedBook.Price);

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int bookId)
        {
            var selectedBook = bookRepository.GetBookById(bookId);

            shoppingCart.RemoveItemFromCart(selectedBook);

            return RedirectToAction("Index");
        }
    }
}
