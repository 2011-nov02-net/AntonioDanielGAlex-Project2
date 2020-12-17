using System;
using System.Collections.Generic;
using System.Text;
using YourEpic.Domain.Interfaces;

namespace YourEpic.DB.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public void AddCategory(string name)
        {
            throw new NotImplementedException();
        }

        public bool CategorizeEpic(int categoryID, int epicID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.Category> GetCategories()
        {
            throw new NotImplementedException();
        }
    }
}
