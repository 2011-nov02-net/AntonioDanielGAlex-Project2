using System;
using System.Collections.Generic;
using System.Text;
using YourEpic.Domain.Interfaces;

namespace YourEpic.DB.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly YourEpicProjectTwoDatabaseContext _context;

        /// <summary>
        /// A repository managing data access for Store objects,
        /// using Entity Framework.
        /// </summary>
        public RatingRepository(YourEpicProjectTwoDatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool AddRatingForEpic(Domain.Models.Rating rating)
        {
            try
            {
                var db_rating = Mappers.RatingMapper.MapFull(rating);

                _context.Add(db_rating);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool RemoveRatingForEpic(Domain.Models.Rating rating)
        {
            try
            {
                var db_rating = _context.Ratings.Find(rating.ID);
                _context.Remove(db_rating);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool UpdateRatingForEpic(Domain.Models.Rating rating)
        {
            try { 
                Rating currentEntity = _context.Ratings.Find(rating.ID);
                Rating newEntity = Mappers.RatingMapper.MapFull(rating);

                _context.Entry(currentEntity).CurrentValues.SetValues(newEntity);

                return true;
            }
            catch { return false; }
        }
    }
}
