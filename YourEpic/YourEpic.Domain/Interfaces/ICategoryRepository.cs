using System.Collections.Generic;
using YourEpic.Domain.Models;

namespace YourEpic.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        bool CategorizeEpic(IEnumerable<Category> categoriesToAdd, int epicID);

        IEnumerable<Category> GetCategories(string name = null);

        bool AddCategory(string name);
    }
}
