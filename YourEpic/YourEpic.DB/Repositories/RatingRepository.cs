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

        public Domain.Models.Rating GetRatingByID(int ratingID) {
            Domain.Models.Rating nonDB_rating;
            try {
                var db_rating = _context.Ratings.Include(w=>w.Rater).Include(e=>e.Epic).First(r=>r.Id == ratingID);
                nonDB_rating = Mappers.RatingMapper.MapFull(db_rating);
            }
            catch {
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
