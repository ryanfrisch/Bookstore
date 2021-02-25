using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.ViewModels
{
    // now ready for any page that needs this info
    public class BookListViewModel
    {
        // contains books themselves
        public IEnumerable<Book> Books { get; set; }
        
        // contains the page info
        public PagingInfo PagingInfo { get; set; }
    }
}
