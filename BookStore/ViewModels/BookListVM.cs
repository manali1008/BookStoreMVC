using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
namespace BookStore.ViewModels
{
    public class BookListVM
    {
        public IEnumerable<Book> Books { get; set; }
        public string SelectedCategory { get; set; }
    }
}
