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
        public bool CategorizeEpic(int categoryID, int epicID)
        {
            var dbEpicCatergory = _context.EpicCategories.FirstOrDefault(ec => ec.CategoryId == categoryID && ec.EpicId == epicID);

            if (dbEpicCatergory != null)
            {
                return false;
            }

            dbEpicCatergory = new EpicCategory
            {
                EpicId = epicID,
                CategoryId = categoryID
            };

            _context.EpicCategories.Add(dbEpicCatergory);
            _context.SaveChanges();

            return true;
        }


        /// <summary>
        /// Gets all categories from database
        /// </summary>
        /// <returns>List of categories or empty list no categories in database</returns>
        public IEnumerable<Domain.Models.Category> GetCategories()
        {
            var dbCategories = _context.Categories.ToList();

            if(dbCategories.Any())
            {
                return new List<Domain.Models.Category>();
            }

            var categories = dbCategories.Select(c => new Domain.Models.Category
            {
                ID = c.Id,
                Name = c.Name
            });

            return categories;
        }


        /// <summary>
        /// Add new category to database
        /// </summary>
        /// <param name="name">Name of category to add</param>
        public void AddCategory(string name)
        {
            var dbCategory = _context.Categories.FirstOrDefault(c => c.Name == name);
            
            if(dbCategory == null)
            {
                dbCategory = new Category
                {
                    Name = name
                };

                _context.Categories.Add(dbCategory);
                _context.SaveChanges();
            }
        }
    }
}
