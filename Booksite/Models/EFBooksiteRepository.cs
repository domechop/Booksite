using System;
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
    }
}
