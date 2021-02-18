using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext appDBContext;

        public EFCategoryRepository(AppDBContext appDB)
        {
            this.appDBContext = appDB;
        }

        public IEnumerable<Category> AllCategories => appDBContext.Categories;
    }
}
