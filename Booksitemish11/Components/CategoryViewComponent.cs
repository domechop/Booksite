using System;
using System.Linq;
using Booksite.Models;
using Microsoft.AspNetCore.Mvc;

namespace Booksite.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private IBooksiteRepository repo { get; set; }

        public CategoryViewComponent (IBooksiteRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            var category = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(category);
        }
    }
}
