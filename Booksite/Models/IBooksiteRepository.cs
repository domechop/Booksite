using System;
using System.Linq;

namespace Booksite.Models
{
    public interface IBooksiteRepository
    {
        IQueryable<Book> Books { get; }
    }
}
