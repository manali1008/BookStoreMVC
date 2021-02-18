using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories => new List<Category> { 
        new Category{
            CategoryId = 101,
            Name = "Fiction",
            Description="All books on fiction"},
        new Category {
            CategoryId = 102,
            Name = "Fantasy",
            Description="All books on fantasy"},
        new Category {
            CategoryId = 103,
            Name = "Biography",
            Description="All books on biography"},};
    }
}
