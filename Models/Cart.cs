using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem (Book bk, int qty)
        {
            CartLine line = Lines
                .Where(b => b.Book.BookId == bk.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = bk,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        // remove a specific line that matches the book that's passed into the function
        public virtual void RemoveLine(Book bk) =>
            Lines.RemoveAll(x => x.Book.BookId == bk.BookId);

        // allow us to clear all lines from the cart
        public virtual void Clear() => Lines.Clear();

        // compute cart total (explicitly convert my float to a decimal
        public decimal ComputeTotalSum() => Convert.ToDecimal(Lines.Sum(e => e.Book.Price * e.Quantity));


        // define the CartLine container
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }

    }
}
