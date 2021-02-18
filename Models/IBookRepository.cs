using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// creates the book repository

namespace Bookstore.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
