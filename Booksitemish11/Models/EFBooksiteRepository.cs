﻿using System;
using System.Linq;

namespace Booksite.Models
{
    public class EFBooksiteRepository : IBooksiteRepository
    {
        private BookstoreContext context { get; set; }

        public EFBooksiteRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Book> Books => context.Books;

        public void SaveBook(Book b)
        {
            context.SaveChanges();
        }

        public void CreateBook(Book b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void DeleteBook(Book b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
    }
}
