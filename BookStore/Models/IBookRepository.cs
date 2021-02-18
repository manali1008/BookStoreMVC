using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public interface IBookRepository
    {
        IEnumerable<Book> AllBooks { get;}
        IEnumerable<Book> OffersOfTheWeek { get; }
        Book GetBookById(int bookId);
    }
}
