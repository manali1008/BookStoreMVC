using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class EFBookRepository : IBookRepository
    {
        private readonly AppDBContext appDBContext;

        public EFBookRepository(AppDBContext appDB)
        {
            this.appDBContext = appDB;
        }
        public IEnumerable<Book> AllBooks{
            get
            {
                return appDBContext.Books.Include(b => b.Category);
            } 
        }

        public IEnumerable<Book> OffersOfTheWeek => throw new NotImplementedException();

        public Book GetBookById(int bookId)
        {
            return appDBContext.Books.Include(b => b.Category).FirstOrDefault(b => b.BookId == bookId);
        }
    }
}
