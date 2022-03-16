using System;
using System.Linq;

namespace Booksite.Models
{
    public interface IBooksiteRepository
    {
        IQueryable<Book> Books { get; }

        public void SaveBook(Book b);
        public void CreateBook(Book b);
        public void DeleteBook(Book b);
    }
}
