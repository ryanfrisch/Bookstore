using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bookstore.Models;
using Bookstore.Models.ViewModels;

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookRepository _repository;


        // define the number of items per page, make it public so it's accessible
        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //Passes the database information and category into the view, make page 1 if no value is passed
        public IActionResult Index(string category, int page = 1)
        {
            // pass through our pre-packaged data in our new BookListViewModel
            return View(new BookListViewModel
                {
                    Books = _repository.Books
                        .Where(b => category == null || b.Category == category)
                        .OrderBy(b => b.BookId)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize),

                    // create new paging info object that we set up with our class and set all of its properties
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        // determine TotalNumItems based on the category
                        TotalNumItems = category == null ? _repository.Books.Count() :
                            _repository.Books.Where (x => x.Category == category).Count()
                    },
                    // specifies the category in the BooklistViewModel
                    CurrentCategory = category
                });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
