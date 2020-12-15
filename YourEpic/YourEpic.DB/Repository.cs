using System;
using System.Linq;
using YourEpic.Domain;

namespace YourEpic.DB
{
    public class Repository : IRepository
    {
        private readonly YourEpicProjectTwoDatabaseContext _context;

        /// <summary>
        /// A repository managing data access for Store objects,
        /// using Entity Framework.
        /// </summary>
        public Repository(YourEpicProjectTwoDatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddGenre()
        {
            var category = new Category { Name = "Fantasy" };
            _context.Add(category);
            _context.SaveChanges();
            Console.Write(_context.Categories.First()); ;
        }
    }
}
