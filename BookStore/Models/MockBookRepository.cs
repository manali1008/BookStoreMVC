using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class MockBookRepository : IBookRepository
    {
        private readonly ICategoryRepository categoryRepository;
        public MockBookRepository(ICategoryRepository repository)
        {
            this.categoryRepository = repository;
        }
        public IEnumerable<Book> AllBooks => new List<Book> {
        new Book{
            BookId=201,
            Title="Brave New World",
            Author="Aldous Huxley",
            ISBN="OL6504102M",
            Price=12,
            PublishYear=1970,
            Description="This book is on fiction on social control through politics and media",
            ImageUrl=Path.Combine(Directory.GetCurrentDirectory(),@"\images\Bravenewworld.jpg"),
            Category=categoryRepository.AllCategories.ToList()[0] },
        new Book{
            BookId=202,
            Title="The Time Machine",
            Author="H.G Wells",
            ISBN="OL24331810M",
            Price=14,
            PublishYear=1985,
            Description="The Time Traveller, a dreamer obsessed with traveling through time, builds himself a time machine and, much to his surprise, travels over 800,000 years into the future.",
            ImageUrl=Path.Combine(Directory.GetCurrentDirectory(), @"\images\TheTimeMachine.jpg"),
            Category=categoryRepository.AllCategories.ToList()[0] },
        new Book{
            BookId=203,
            Title="Abraham Lincoln",
            Author="Carl Sandburg",
            ISBN="OL13439307M",
            Price=20,
            PublishYear=1975,
            Description="Biography of Abraham Lincoln",
            ImageUrl=Path.Combine(Directory.GetCurrentDirectory(),@"\images\AbrahmLincol.jpg"),
            Category=categoryRepository.AllCategories.ToList()[2] },
        new Book{
            BookId=204,
            Title="Meet Viola Desmond",
            Author="Ellzabeth Macleod",
            ISBN="OL6503902M",
            Price=15,
            PublishYear=2018,
            Description="Meet Viola Desmond, community leader and early civil rights trailblazer!",
            ImageUrl=Path.Combine(Directory.GetCurrentDirectory(),@"\images\Mmeetvioladesmond.jpg"),
            Category=categoryRepository.AllCategories.ToList()[2] },
        new Book{
            BookId=205,
            Title="The Magpie's Library",
            Author="Kate Blalr",
            ISBN="OL6505503M",
            Price=14,
            PublishYear=2012,
            Description="Silva and her family visit her grandfather, only to find his health has taken a bad turn. As they struggle with this news, Silva seeks escape in books – at the local library.",
            ImageUrl=Path.Combine(Directory.GetCurrentDirectory(),@"\images\TheMagpies.jpg"),
            Category=categoryRepository.AllCategories.ToList()[1] },
        new Book{
            BookId=206,
            Title="The Night Circus",
            Author="Erln Morgenstern",
            ISBN="OL1503106M",
            Price=12,
            PublishYear=2015,
            Description="The circus arrives without warning. No announcements precede it. It is simply there, when yesterday it was not. Within the black-and-white striped canvas tents is an utterly unique experience full of breathtaking amazements. ",
            ImageUrl=Path.Combine(Directory.GetCurrentDirectory(),@"\images\NightCircus.jpg"),
            Category=categoryRepository.AllCategories.ToList()[1] }};

        public IEnumerable<Book> OffersOfTheWeek { get; }

        public Book GetBookById(int bookId)
        {
            return AllBooks.FirstOrDefault(b => b.BookId == bookId);
        }
    }
}
