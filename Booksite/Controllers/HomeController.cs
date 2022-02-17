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

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Skip(pageNum - 1)
                .Take(pageSize),
                
                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum,
                }
            };

            return View(x);
        }
    }
}
