using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using YourEpic.Domain.Interfaces;
using YourEpic.Domain.Models;

namespace YourEpic.DB.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly YourEpicProjectTwoDatabaseContext _context;

        public CategoryRepository(YourEpicProjectTwoDatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// categorizes epics
        /// </summary>
        /// <param name="categoryID">Category Id</param>
        /// <param name="epicID">Epic Id</param>
        /// <returns>False if epic is already categorized or true if epic categorized successfully</returns>
        public bool CategorizeEpic(IEnumerable<Domain.Models.Category> categoriesToAdd, int epicID)
        {
            var dbEpicCatergory = _context.EpicCategories;
            if (dbEpicCatergory != null)
            {
                foreach (var category in categoriesToAdd)
                {
                    foreach (var exists in dbEpicCatergory.Where(e=>e.EpicId == epicID))
                    {
                        if (category.ID == exists.CategoryId)
                        {
                            categoriesToAdd.ToList().Remove(category);
                        }
                    }
                }
            }
            if (categoriesToAdd.Count() == 0)
            {
                return false;
            }

            foreach (var cat in categoriesToAdd)
            {

                var epicCategory = new EpicCategory
                {
                    EpicId = epicID,
                    CategoryId = cat.ID
                };

                dbEpicCatergory.Add(epicCategory);
            }

            _context.SaveChanges();

            return true;
        }


        /// <summary>
        /// Gets all categories from database
        /// </summary>
        /// <returns>List of categories or empty list no categories in database</returns>
        public IEnumerable<Domain.Models.Category> GetCategories(string name = null)
        {
            IQueryable<Category> items = _context.Categories;

            if (name != null)
            {
                items = items.Where(e => e.Name == name);
            }

            return items.Select(Mappers.CategoryMapper.Map);
        }

        /// <summary>
        /// Add new category to database
        /// </summary>
        /// <param name="name">Name of category to add</param>
        public bool AddCategory(string name)
        {
            var dbCategory = _context.Categories.FirstOrDefault(c => c.Name == name);

            if (dbCategory == null)
            {
                dbCategory = new Category
                {
                    Name = name
                };

                _context.Categories.Add(dbCategory);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
