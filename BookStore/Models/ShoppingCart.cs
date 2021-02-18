using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace BookStore.Models
{
    public class ShoppingCart
    {
        private readonly AppDBContext appDBContext;

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public static  ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services
                                .GetRequiredService<IHttpContextAccessor>()
                                .HttpContext.Session;

            string ShoppingCartId = session.GetString("ShoppingCartId") ?? Guid.NewGuid().ToString();

            session.SetString("ShoppingCartId", ShoppingCartId);

            var context = services.GetService<AppDBContext>();

            return new ShoppingCart(context) { ShoppingCartId = ShoppingCartId };
        }

        public void AddItemToCart(Book book, decimal amount)
        {
            var shoppingCartItem = appDBContext.ShoppingCartItems.SingleOrDefault(
                                    b => b.Book.BookId == book.BookId && b.ShoppingCartId == this.ShoppingCartId);

            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = this.ShoppingCartId,
                    Book = book,
                    Amount = amount
                };

                appDBContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                //do nothing as item is already in cart
            }

            appDBContext.SaveChanges();
        }

        public void RemoveItemFromCart(Book book)
        {
            var shoppingCartItem = appDBContext.ShoppingCartItems.SingleOrDefault(
                                b => b.Book.BookId == book.BookId && b.ShoppingCartId == this.ShoppingCartId);

            if(shoppingCartItem != null)
            {
                appDBContext.ShoppingCartItems.Remove(shoppingCartItem);
            }

            appDBContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            this.ShoppingCartItems = appDBContext.ShoppingCartItems.Where(
                                        c => c.ShoppingCartId == this.ShoppingCartId).Include(cart => cart.Book).ToList();

            return this.ShoppingCartItems;
        }

        public decimal GetShoppingCartTotal()
        {
            return appDBContext.ShoppingCartItems.Where(c => c.ShoppingCartId == this.ShoppingCartId).Select(c => c.Amount).Sum();
        }

        public void ClearShoppingCart()
        {
            var ShoppingCartItems = appDBContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == this.ShoppingCartId);

            appDBContext.ShoppingCartItems.RemoveRange(ShoppingCartItems);

            appDBContext.SaveChanges();
        }
    }
}
