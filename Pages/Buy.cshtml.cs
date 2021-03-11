using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Infrastructure;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore.Pages
{
    public class BuyModel : PageModel
    {
        private IBookRepository repository;

        // Constructor
        public BuyModel (IBookRepository repo)
        {
            repository = repo;
        }

        // Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        // Methods
        public void OnGet(string returnUrl)
        {
            // set this class's ReturnUrl property with passed in returnUrl string (unless it's blank, then uses "/"
            ReturnUrl = returnUrl ?? "/";
            // get cart from session, if no cart, make a new one.
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);

            // get car
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            // add item to cart
            Cart.AddItem(book, 1);

            // set json in session with updated cart
            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.RemoveLine(Cart.Lines.First(cl => cl.Book.BookId == bookId).Book);

            // set json in session with updated cart
            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
