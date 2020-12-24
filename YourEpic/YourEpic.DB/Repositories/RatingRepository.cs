using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YourEpic.Domain.Interfaces;
using YourEpic.Domain.Models;


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

        public IEnumerable<Domain.Models.Rating> GetMyRatings(int userId)
        {
            IEnumerable<Domain.Models.Rating> nonDB_rating;
            try
            {
                var db_rating = _context.Ratings.Include(w => w.Rater).Include(e => e.Epic);
                nonDB_rating = db_rating.Select(Mappers.RatingMapper.MapFull);
            }
            catch
            {
                return null;
            }
            return nonDB_rating;
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
            try
            {
                var db_rating = _context.Ratings.First(r => r.EpicId == rating.RatingEpic.ID && r.RaterId == rating.Rater.ID);

                db_rating.Rating1 = rating.RatingNumber;

                _context.SaveChanges();

                return true;
            }
            catch { return false; }
        }
    }
}
