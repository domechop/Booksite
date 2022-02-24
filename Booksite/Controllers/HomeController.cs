using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booksite.Models;
using Booksite.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Booksite.Controllers
{
    public class HomeController : Controller
    {
        private IBooksiteRepository repo;

        public HomeController(IBooksiteRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string category, int pageNum = 1)
        {
            //make it so 10 items are listed on each page.
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == category || category == null)
                .Skip(pageNum - 1)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks =
                        (category == null
                            ? repo.Books.Count()
                            : repo.Books.Where(x => x.Category == category).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum,
                }
            };

            return View(x);
        }
    }
}
