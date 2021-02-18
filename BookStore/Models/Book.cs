using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int PublishYear { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public Category Category { get; set; }

        public bool IsItInOffer { get; set; }
    }
}
