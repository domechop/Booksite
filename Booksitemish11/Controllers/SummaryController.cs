using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booksite.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Booksite.Controllers
{
    public class SummaryController : Controller
    {
        private ISummaryRepository repo { get; set; }

        private Basket basket { get; set; }

        public SummaryController(ISummaryRepository temp, Basket ba)
        {
            repo = temp;
            basket = ba;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Summary());
        }
        [HttpPost]
        public IActionResult Checkout(Summary summary)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                summary.Lines = basket.Items.ToArray();
                repo.SaveSummary(summary);
                basket.ClearBasket();

                return RedirectToPage("/Completion");
            }
            else
            {
                return View();
            }
        }
    }
}