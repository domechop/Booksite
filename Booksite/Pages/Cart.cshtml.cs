﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booksite.Infrastructure;
using Booksite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Booksite.Pages
{
    public class CartModel : PageModel
    {
        private IBooksiteRepository repo { get; set; }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public CartModel (IBooksiteRepository temp, Basket ba)
        {
            repo = temp;
            basket = ba;
        }

    

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
      
        }
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket.AddItem(b, 1);
            
            return RedirectToPage(new { ReturnUrl = returnUrl });

        }
        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
