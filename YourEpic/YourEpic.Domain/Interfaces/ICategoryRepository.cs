using System;
using System.Collections.Generic;
using YourEpic.Domain.Models;

namespace YourEpic.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        bool CategorizeEpic(int categoryID, int epicID);

        IEnumerable<Category> GetCategories();

        void AddCategory(string name);
    }
}
